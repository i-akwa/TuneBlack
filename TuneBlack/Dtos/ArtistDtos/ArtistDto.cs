using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Dtos.ArtistDtos
{
    public class ArtistDto
    {
        [Display(Name ="Stage Name")]
        public string StageName { get; set; }
        public Guid Id { get; set; }

        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Mobile Number")]
        public string Tel { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
