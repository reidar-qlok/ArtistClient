using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistClient.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}
