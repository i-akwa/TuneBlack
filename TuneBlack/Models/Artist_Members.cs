using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Models
{
    public class Artist_Members:BaseUser
    {
        
        [MaxLength(25)]
        public string StageName { get; set; }
     
    }
}
