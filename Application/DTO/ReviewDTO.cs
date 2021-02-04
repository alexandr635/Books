﻿using Data;

namespace Application.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Pseudonim { get; set; }
        public string ReviewString { get; set; }
        public int Rating { get; set; }
        public Book Book { get; set; }
    }
}
