using Microsoft.OData.Client;

using Sitecore.Commerce.Core;

namespace MashedPotatoes.Feature.Reviews.Entities
{
    [Key("Id")]
    public class Review : Sitecore.Commerce.Core.CommerceEntity
    {
        private string text;

        private string author;

        private int score;

        private EntityReference productReference;

        public string Text
        {
            get => this.text;
            set
            {
                this.text = value;
                this.OnPropertyChanged(nameof(this.Text));
            }
        }


        public string Author
        {
            get => this.author;
            set
            {
                this.author = value;
                this.OnPropertyChanged(nameof(this.Author));
            }
        }


        public int Score
        {
            get => this.score;
            set
            {
                this.score = value;
                this.OnPropertyChanged(nameof(this.Score));
            }
        }

        public EntityReference ProductReference
        {
            get => this.productReference;
            set
            {
                this.productReference = value;
                this.OnPropertyChanged(nameof(this.ProductReference));
            }
        }
    }
}