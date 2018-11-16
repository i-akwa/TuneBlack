using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneBlack.Data;
using TuneBlack.Models;

namespace TuneBlack.Services.AlbumRepository
{
    public class AlbumRepo : IAlbumRepo
    {
        private ApplicationDbContext _context;
        public AlbumRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void AddTrack(Album_Members album)
        {
            album.AlbumId = Guid.NewGuid();
            album.CreationDate = System.DateTime.UtcNow;
            _context.Albums.Add(album);
            Save();
        }

        public bool AlbumExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AlbumUpdate(Album_Members track)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrack(Album_Members track)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album_Members> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public Album_Members GetTrack(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
