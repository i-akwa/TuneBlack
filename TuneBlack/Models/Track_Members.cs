using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Models
{
    public class Track_Members
    {
        [Key]
        public Guid TrackId { get; set; }
        public string TrackName { get; set; }
        
        [Display(Name ="Track Path")]
        public string TrackPathUrl { get; set; }

        public string Genre { get; set; }

        public string ProducerName { get; set; }
        public Guid AlbumId { get; set; }

        public DateTime UploadDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist_Members Artist_Members { get; set; }
    }
}
