using BloomAssignment.Interfaces;
using BloomAssignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BloomAssignment.Services
{
    public class RecipeService : IRecipeService
    {
        public RecipeService()
        {
            
        }
        public async Task<RecipeResponse> GetRecipejsonData()
        {
            RecipeResponse response = new RecipeResponse();
            try
            {
                var assembly = this.GetType().GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("BloomAssignment.BloomRecipe.json");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<RecipeResponse>(jsonString);
                    var mealType = response.Items.Select(x => x.MealType).ToList();
                   // List<LocalItemsModel> type = new List<LocalItemsModel>();
                    foreach (var item in mealType)
                    {
                        foreach (var items in item)
                        {
                            LocalItemsModel meal = new LocalItemsModel();
                            meal.Id = items.Id;
                            meal.Name = items.Name;
                            meal.FeaturedImage = items.FeaturedImage;
                            meal.Slug = items.Slug;
                            await App.Database.SaveItemAsync(meal);
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }
        }
    }
}
