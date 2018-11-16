using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneBlack.Models;

namespace TuneBlack.Services.AlbumRepository
{
    public interface IAlbumRepo
    {
        void AddTrack(Album_Members album);
        IEnumerable<Album_Members> GetAllAlbums();
        Album_Members GetTrack(Guid id);
        bool AlbumExist(Guid id);
        void AlbumUpdate(Album_Members track);
        void DeleteTrack(Album_Members track);
        bool Save();
    }
}
