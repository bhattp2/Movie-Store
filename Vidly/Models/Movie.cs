using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        //[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }
       
        [Display(Name = "Released Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Range(1,20)]
        [Display(Name = "No of Stocks")]
        public byte NoOfStocks { get; set; }

        public Genre GenreType { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreID { get; set; }

        public Nullable<DateTime> DateAdded { get; set; }

        public byte NumberAvailable { get; set; }
    }
}