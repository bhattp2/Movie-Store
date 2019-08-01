using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }


        [Display(Name = "Released Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Range(1, 20)]
        [Display(Name = "No of Stocks")]
        public byte? NoOfStocks { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreID { get; set; }

        public String title {
            get {
                if (Id != null)
                    return "Edit Movie";
                else
                    return "New Movie";
            }

        }
        public MovieViewModel()
        {
            Id = 0;
        }
        public MovieViewModel(Movie movie)
        {

            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NoOfStocks = movie.NoOfStocks;
            GenreID = movie.GenreID;
        }
    }

}