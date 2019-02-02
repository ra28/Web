﻿using System.ComponentModel.DataAnnotations;


namespace SchoolApp.Server.Models.DataObject
{
    public class Book : EntityBase
    {
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }

        // Foreign Key
        public int AuthorId { get; set; }
        // Navigation property
        public Author Author
        {
            get; set;
        }
    }
}