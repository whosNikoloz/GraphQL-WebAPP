﻿using System.ComponentModel.DataAnnotations;

namespace Graphql_.Net.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
