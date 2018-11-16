using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Models
{
    public class BaseUser
    {
        public BaseUser()
        {

        }

        [Required]
        [Key]
        public Guid Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = System.DateTime.UtcNow;
        
        public DateTime LastEdited { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
