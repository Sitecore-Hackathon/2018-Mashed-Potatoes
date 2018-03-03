using System;

using Sitecore.Commerce.Services;
using Sitecore.Diagnostics;

namespace MashedPotatoes.Feature.Reviews.Pipelines.Arguments
{
    public class AddReviewRequest : ServiceProviderRequest
    {
        public AddReviewRequest(string text, DateTime date, string author, int score, string productId)
        {
            Assert.ArgumentNotNullOrEmpty(text, nameof(text));
            Assert.ArgumentNotNull(date, nameof(date));
            Assert.ArgumentNotNullOrEmpty(author, nameof(author));
            Assert.ArgumentNotNullOrEmpty(productId, nameof(productId));

            this.Text = text;
            this.Date = date;
            this.Author = author;
            this.Score = score;
            this.ProductId = productId;
        }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public int Score { get; set; }

        public string ProductId { get; set; }

        public string ShopName { get; set; }
    }
}