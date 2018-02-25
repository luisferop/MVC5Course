using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class Movie
    {
        public Movie()
        {
            Id = 0;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name ="Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name ="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime? AddedDate { get; set; }

        [Display(Name ="Number In Stock")]
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

    }
}