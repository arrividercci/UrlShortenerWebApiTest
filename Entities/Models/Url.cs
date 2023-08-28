using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Url
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "OriginalUrl is requered field.")]
        public string? OriginalUrl { get; set; }
        [Required(ErrorMessage = "ShorterUrl is requered field.")]
        public string? ShorterUrl { get; set; }
        [Required(ErrorMessage = "CreationDate is requered field.")]
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "UserId is requered field.")]
        public string? UserId { get; set; }
    }
}
