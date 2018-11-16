using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuneBlack.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TuneBlack.Models;
using TuneBlack.Utility;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Routing;
using TuneBlack.Dtos.ArtistDtos;
using TuneBlack.Areas.Identity.Pages;
using TuneBlack.Areas.Identity.Pages.Account;
using TuneBlack.Services.ArtistRepository;
using TuneBlack.Services.TrackRepository;
using TuneBlack.Dtos.TrackDtos;
using TuneBlack.Dtos.AlbumDtos;

namespace TuneBlack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<ITrackRepository, TrackRepo>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , IServiceProvider serviceProvider
            , IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterModel.InputModel, Artist_Members>();
                cfg.CreateMap<Track_Members, TrackDto>();
                cfg.CreateMap<TrackForCreationDto, Track_Members>();

                cfg.CreateMap<AlbumForCreationDto, Album_Members>();
            });
            app.UseHttpsRedirection();

            ServeFromDirectory(app, env, "node_modules");
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);

            var _context = serviceProvider.GetService<ApplicationDbContext>();
            _context.Database.Migrate();
            CreateUserRoles(serviceProvider).Wait();
            CreateDefaultUsers(serviceProvider, configuration).Wait();
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
               "api_v1",
                template: "api/v1/{controller}/{action}/{id?}");
        }
        public void ServeFromDirectory(IApplicationBuilder app, IHostingEnvironment env, string path)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, path)
                ),
                RequestPath = "/" + path
            });
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            IdentityResult roleResult;

            var adminRoleCheck = await roleManager.RoleExistsAsync(Roles.Administrator);
            var artistRoleCheck = await roleManager.RoleExistsAsync(Roles.Artist);

            if (!adminRoleCheck)
                roleResult = await roleManager.CreateAsync(new IdentityRole(Roles.Administrator));
            if (!artistRoleCheck)
                roleResult = await roleManager.CreateAsync(new IdentityRole(Roles.Artist));
        }

        private async Task CreateDefaultUsers(IServiceProvider serviceProvider, IConfiguration _configuration)
        {
            var AdminEmail = _configuration[Constants.AdminEmail];
            var AdminPassword = _configuration[Constants.AdminPassword];
            var AdminName = _configuration[Constants.AdminName];
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var adminUser = new ApplicationUser
            {
                Email = AdminEmail,
                UserName = AdminEmail,
                EmailConfirmed = true
            };

            var result = await _userManager.FindByEmailAsync(AdminEmail);
            if (result == null)
            {
                await _userManager.CreateAsync(adminUser, AdminPassword);
                await _userManager.AddToRoleAsync(adminUser, Roles.Administrator);
            }

        }
    }
}
