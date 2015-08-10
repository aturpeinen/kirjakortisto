namespace Kirjakortisto.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Book
    {
        public Book()
        {
            
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the book is required!")]
        [Index]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description of the book is required!")]
        public string Description { get; set; }

        [Index]
        [MaxLength(256)]
        [Required(ErrorMessage = "Author of the Book is required!")]
        public string Author { get; set; }

        [Index]
        [Required(ErrorMessage = "Purchase date is required!")]
        public DateTime PurchaseDate { get; set; }
    }
}