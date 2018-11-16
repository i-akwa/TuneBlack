using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneBlack.Data;
using TuneBlack.Models;

namespace TuneBlack.Services.TrackRepository
{
    public class TrackRepo : ITrackRepository
    {
        private ApplicationDbContext _context;
        public TrackRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTrack(Track_Members track)
        {
           // var alb = (from a in _context.Albums where a.AlbumId == track.AlbumId select a).First();
                
            Album_Members alb = _context.Albums.SingleOrDefault(a => a.AlbumId == track.AlbumId);
            
            if(alb==null)
            {
                alb = new Album_Members();
                alb.AlbumId = Guid.NewGuid();
                alb.AlbumName = "Single";
                alb.ArtistId = track.ArtistId;
                _context.Albums.Add(alb);
            }
            track.TrackId = Guid.NewGuid();
            track.AlbumId = alb.AlbumId;
            track.UploadDate = System.DateTime.UtcNow;
            
            _context.Tracks.Add(track);
        }

        public void DeleteTrack(Track_Members track)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track_Members> GetAllTrack()
        {
            return _context.Tracks
                .OrderBy(t => t.UploadDate)
                .ThenBy(t => t.Artist_Members.StageName)
                .ToList();
        }

        public Track_Members GetSingleTrack(Guid id)
        {
            return _context.Tracks.FirstOrDefault(t => t.TrackId == id);
        }

        public IEnumerable<Track_Members> GetTrack(Guid ArtistId)
        {
            return _context.Tracks
                .Where(t => t.ArtistId == ArtistId).OrderBy(t => t.TrackName).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool TrackExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public void TrackUpdate(Track_Members track)
        {
            throw new NotImplementedException();
        }
    }
}
