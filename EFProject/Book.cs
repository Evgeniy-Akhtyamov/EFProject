using System;
using System.Collections.Generic;
using System.Text;

namespace EFProject
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        
        // Внешний ключ
        public int? UserId { get; set; }
        // Навигационное свойство
        public User User { get; set; }
    }
}
