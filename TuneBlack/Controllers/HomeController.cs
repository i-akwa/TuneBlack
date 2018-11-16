using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TuneBlack.Data;
using TuneBlack.Dtos.TrackDtos;
using TuneBlack.Models;
using TuneBlack.Services.TrackRepository;

namespace TuneBlack.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _con;
        private ITrackRepository _trackRepo;
        public HomeController(ITrackRepository trackRepo, ApplicationDbContext con)
        {
            _con = con;
            _trackRepo = trackRepo;
        }
        public IActionResult Index()
        {
            var tracks = _trackRepo.GetAllTrack();
            var trackDto = Mapper.Map<IEnumerable<TrackDto>>(tracks);

            #region GetArtistNameAndAlbumName
            foreach (var t in trackDto)
            {
                var stageName = (from a in _con.Artists
                                 where a.Id == t.ArtistId
                                 select a.StageName).Single();
                t.ArtistName = stageName;

                var albumName = (from a in _con.Albums
                                 where a.AlbumId == t.AlbumId
                                 select a.AlbumName).Single();
                t.AlbumName = albumName;
            }
            #endregion
            return View(trackDto);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
