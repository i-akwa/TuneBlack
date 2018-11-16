using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuneBlack.Models
{
    public class Album_Members
    {
        [Key]
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist_Members ArtistMember { get; set; }

        public List<Track_Members> TrackUrl { get; set; } = new List<Track_Members>();

        public DateTime CreationDate { get; set; }
    }
}