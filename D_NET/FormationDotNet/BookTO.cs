﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationDotNet
{
    public class BookTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PublisherName { get; set; }
    }
}