using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuneBlack.Data;
using TuneBlack.Dtos.TrackDtos;
using TuneBlack.Models;
using TuneBlack.Services.TrackRepository;

namespace TuneBlack.Controllers
{
    public class TracksController : Controller
    {
        private ApplicationDbContext _con;
        private ITrackRepository _trackRepo;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;
        private string stringId;
        public TracksController(ITrackRepository trackRepo, IHostingEnvironment environment, ApplicationDbContext con, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _con            = con;
            _trackRepo      = trackRepo;
            _userManager    = userManager;
            stringId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult AddTrack()
        {
            var track = new TrackForCreationDto();
            return View(track);
        }

        [HttpPost]
        public  IActionResult AddTrack([FromForm]TrackForCreationDto track)
        {
            if(ModelState.IsValid)
            {
                if(track==null)
                {
                    return BadRequest();
                }
                var trackEntity = Mapper.Map<Track_Members>(track);

                var artistId = (from a in _con.Artists where a.ApplicationUserId == stringId select a.Id).First();

                trackEntity.ArtistId = artistId;
                trackEntity.TrackPathUrl = Upload(artistId);

                _trackRepo.AddTrack(trackEntity);

                if(!_trackRepo.Save())
                {
                    ViewBag.Notification("No User Created");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetTracks()
        {
            var tracks = _trackRepo.GetAllTrack();
            var trackDto = Mapper.Map<IEnumerable<TrackDto>>(tracks);

            #region GetArtistName
            foreach(var t in trackDto)
            {
                var stageName = (from a in _con.Artists
                                  where a.Id == t.ArtistId
                                  select a.StageName).Single();
                t.ArtistName = stageName;
            }
            #endregion
            return View("~/Views/Home/Index.cshtml", trackDto);
        }

        public string Upload(Guid id)
        {

            var newFileName = string.Empty;
            if (HttpContext.Request.Form.Files != null)
            {
                string PathDB = string.Empty;
                var fileName = string.Empty;
                var OriginalFIleName = string.Empty;
                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    // var upload = Path.Combine(_environment.WebRootPath, "images");
                    if (file.Length > 0)
                    {
                        OriginalFIleName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = id;

                        var FileExtension = Path.GetExtension(OriginalFIleName);
                        newFileName = myUniqueFileName + OriginalFIleName;
                        fileName = Path.Combine(_environment.WebRootPath, "Tracks") + $@"\{newFileName.Replace(" ", "")}";

                        PathDB = "Tracks/" + newFileName.Replace(" ", "");
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
                return PathDB;
            }
            return string.Empty;
        }

    }
}