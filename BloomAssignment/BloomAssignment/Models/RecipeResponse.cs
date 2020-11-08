using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloomAssignment.Models
{
    public class RecipeResponse
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
    public partial class Item
    {
        [JsonProperty("meal_type")]
        public List<MealType> MealType { get; set; }
    }
    public partial class MealType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("featured_image")]
        public string FeaturedImage { get; set; }
    }
}

