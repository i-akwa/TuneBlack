using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Dtos.TrackDtos
{
    public class TrackForCreationDto
    {
        public string TrackName { get; set; }

        [Display(Name = "Track Path")]
        public string TrackPathUrl { get; set; }

        public string Genre { get; set; }
        public string ProducerName { get; set; }

        public DateTime UploadDate { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
