using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneBlack.Models;

namespace TuneBlack.Services.TrackRepository
{
    public interface ITrackRepository
    {
        void AddTrack(Track_Members track);
        IEnumerable<Track_Members> GetAllTrack();
        IEnumerable<Track_Members> GetTrack(Guid ArtistId);
        Track_Members GetSingleTrack(Guid id);
        bool TrackExist(Guid id);
        void TrackUpdate(Track_Members track);
        void DeleteTrack(Track_Members track);
        bool Save();
    }
}
