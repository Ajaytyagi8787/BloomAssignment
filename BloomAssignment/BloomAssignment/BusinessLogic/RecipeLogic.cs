using BloomAssignment.Interfaces;
using BloomAssignment.Models;
using BloomAssignment.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloomAssignment.BusinessLogic
{
   public class RecipeLogic
    {
        RecipeService service;
        IRecipeService recipeService;
        public RecipeLogic()
        {
             service = new RecipeService();
             recipeService = service;
        }
        public async Task<RecipeResponse> GetRecipeResponseAsync()
        {
           return await recipeService.GetRecipejsonData();
        }
    }
}
