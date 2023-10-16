﻿using System.Net;

namespace ShopProjectAPP.Models
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
