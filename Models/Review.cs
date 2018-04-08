using System;

namespace restauranter.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string RestaurantName { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime DateVisit { get; set; }
        public int Helpful { get; set; }
        public int Unhelpful { get; set; }
    }
}