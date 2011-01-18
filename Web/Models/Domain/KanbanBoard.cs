﻿using System;

namespace Web.Models.Domain
{
    public class KanbanBoard
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public int TimesFavorited { get; set; }
        public DateTime Posted { get; set; }
        public string Thumbnail { get; set; }
    }
}