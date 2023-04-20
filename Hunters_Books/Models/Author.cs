using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Hunters_Books.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Maximum 50 caracters.")]
        [Column("Name")]
        [Display(Name = "Name")]
        public string Nombre { get; set; }

       
        public Books Books { get; set; } 
        
    }
}