﻿using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; }

        public Book()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }
    }
}

//•	Id - integer, Primary Key
//•	Name - text with length [3, 30]. (required)
//•	Genre - enumeration of type Genre, with possible values (Biography = 1, Business = 2, Science = 3) (required)
//•	Price - decimal in range between 0.01 and max value of the decimal
//•	Pages – integer in range between 50 and 5000
//•	PublishedOn - date and time (required)
//•	AuthorsBooks - collection of type AuthorBook