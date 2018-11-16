using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneBlack.Models;

namespace TuneBlack.Services.ArtistRepository
{
    public interface IArtistRepository
    {
        void AddArtist(Artist_Members artist);
        IEnumerable<Artist_Members> GetAllArtist();
        Artist_Members GetArtist(Guid id);
        bool ArtistExist(Guid id);
        void ArtistUpdate(Artist_Members artist);
        void DeleteArtist(Artist_Members artist);
        bool Save();
    }
}
