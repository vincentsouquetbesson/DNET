﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormationPOEWebAPI
{
    public class BookTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string PublisherName { get; set; }
    }
}