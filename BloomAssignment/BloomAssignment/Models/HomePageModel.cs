using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BloomAssignment.Models
{
    public partial class HomePageModel
    {
    }
    public partial class SuggestedMealPlanCollection
    {
        public string DayCaption { get; set; }
        public string MealCaption { get; set; }
        public string MealIcon { get; set; }
    }
    public partial class PopularRecipesCollection
    {
        public string Caption { get; set; }
        public string Icon { get; set; }
        public long Id { get; set; }
        public string Slug { get; set; }
    }
    public partial class SuggestedContentsCollection
    {
        public string RecipeCaption { get; set; }
        public string RecipeIcon { get; set; }
        public string RecipeCategory { get; set; }
        public string PlayIcon { get; set; }
    }
}
