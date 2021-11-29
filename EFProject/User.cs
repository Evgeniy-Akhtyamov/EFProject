﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFProject
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
