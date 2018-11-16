using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Dtos.TrackDtos
{
    public class TrackDto
    {
        public Guid TrackId { get; set; }
        public string TrackName { get; set; }

        public string TrackPathUrl { get; set; }

        public string  ProducerName { get; set; }
        public Guid AlbumId { get; set; }

        public DateTime UploadDate { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public Guid ArtistId { get; set; }
    }
}
