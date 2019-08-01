using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }


        public DateTime ReleaseDate { get; set; }


        public DateTime DateAdded { get; set; }


        [Range(1, 20)]
        public byte NoOfStocks { get; set; }

        public GenreDto GenreType { get; set; }

        [Required]
        public byte GenreID { get; set; }
    }
}