using BloomAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloomAssignment.Interfaces
{
   public interface IRecipeService
    {
         Task<RecipeResponse> GetRecipejsonData();
    }
}
