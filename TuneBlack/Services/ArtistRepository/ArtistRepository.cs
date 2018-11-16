using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneBlack.Data;
using TuneBlack.Models;

namespace TuneBlack.Services.ArtistRepository
{
    public class ArtistRepository : IArtistRepository
    {
        private ApplicationDbContext _context;
        public ArtistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddArtist(Artist_Members artist)
        {
            artist.Id = new Guid();
            artist.CreatedOn = System.DateTime.UtcNow;
            _context.Artists.Add(artist);
        }

        public bool ArtistExist(Guid id)
        {
            return _context.Artists.Any(a => a.Id == id);
        }

        public void ArtistUpdate(Artist_Members artist)
        {
            throw new NotImplementedException();
        }

        public void DeleteArtist(Artist_Members artist)
        {
            var user = _context.Users.SingleOrDefault(a => a.Id == artist.ApplicationUserId);
            _context.Users.Remove(user);
            _context.Artists.Remove(artist);
        }

        public IEnumerable<Artist_Members> GetAllArtist()
        {
            return _context.Artists
                .OrderBy(a => a.StageName)
                .ToList();
        }

        public Artist_Members GetArtist(Guid id)
        {
            return _context.Artists.FirstOrDefault(a => a.Id == id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);    
        }
    }
}
