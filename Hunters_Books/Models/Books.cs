using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Hunters_Books.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        /*[Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Book ID")]
        public int BookID { get; set; }*/

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the author.")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter a title.")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre required")]
        [StringLength(50, ErrorMessage = "Invalid genre")]

        public string Genre { get; set; }

        public int GenreID { get; set; }

        public Books(int id, string author, string title, string genre, int genreID)
        {
            Id = id;
            Author = author;
            Title = title;
            Genre = genre;
            GenreID = genreID;
        }

        [ForeignKey(Author)]
        //public Author Author { get; set; }




    }
}