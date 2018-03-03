using System;

namespace MashedPotatoes.Feature.Reviews.Models
{
    public class Review
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public int Score { get; set; }

        public string ProductId { get; set; }
    }
}