using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloomAssignment.FormsControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class RatingStars : ContentView
    {
        private List<Image> StarImages { get; set; }

        public RatingStars()
        {
            GenerateDisplay();
        }

        private void GenerateDisplay()
        {

            //Create Star Image Placeholders 
            StarImages = new List<Image>();
            for (int i = 0; i < 5; i++)
                StarImages.Add(new Image());

            //Create Horizontal Stack containing stars and review count label 
            StackLayout starsStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Padding = 0,
                Spacing = 0,
                Children = {
                    StarImages[0],
                    StarImages[1],
                    StarImages[2],
                    StarImages[3],
                    StarImages[4],
                }
            };
            updateStarsDisplay();
            this.Content = starsStack;
        }


        //Set the correct images for the stars based on the rating 
        public void updateStarsDisplay()
        {
            for (int i = 0; i < StarImages.Count; i++)
            {
                StarImages[i].Source = GetStarFileName(i);
            }
        }

        //uses zero based position for stars 
        private string GetStarFileName(int position)
        {
            int currentStarMaxRating = position;
            //Rating is out of 5
            if (currentStarMaxRating  >= Rating)
            {
                return "Star2.png";
            }
            else
            {
                return "Star1.png";
            }
        }

        //Add in configurable "Rating" double property from XAML, for setting the rating stars
        public static BindableProperty RatingProperty =
            BindableProperty.Create<RatingStars, int>(ctrl => ctrl.Rating,
                defaultValue: 0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    var ratingStars = (RatingStars)bindable;
                    ratingStars.updateStarsDisplay();
                }
            );

        //Rating is out of 5 
        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }
    }
}