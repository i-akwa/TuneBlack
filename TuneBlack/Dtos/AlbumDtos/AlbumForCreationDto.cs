using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuneBlack.Dtos.AlbumDtos
{
    public class AlbumForCreationDto
    {
        public string AlbumName { get; set; }
        public Guid ArtistId { get; set; }
    }
}
