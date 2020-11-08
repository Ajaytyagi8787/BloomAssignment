using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloomAssignment.BusinessLogic;
using BloomAssignment.Models;
using Xamarin.Forms;

namespace BloomAssignment.ViewModels
{
    public class HomePageVM: BaseViewModel
    {
        ObservableCollection<PopularRecipesCollection> popularRecipesCollectionView { get; set; }
        List<SuggestedMealPlanCollection> suggestedMealPlanColectionView { get; set; }
        List<SuggestedContentsCollection> suggestedContentsCollectionView { get; set; }
        public ObservableCollection<PopularRecipesCollection> PopularRecipesCollectionView
        {
            get
            {
                return popularRecipesCollectionView;
            }
            set
            {
                popularRecipesCollectionView = value;
                OnPropertyChanged("PopularRecipesCollectionView");
            }
        }
        public List<SuggestedMealPlanCollection> SuggestedMealPlanColectionView
        {
            get
            {
                return suggestedMealPlanColectionView;
            }
            set
            {
                suggestedMealPlanColectionView = value;
                OnPropertyChanged("SuggestedMealPlanColectionView");
            }
        }
        public List<SuggestedContentsCollection> SuggestedContentsCollectionView
        {
            get
            {
                return suggestedContentsCollectionView;
            }
            set
            {
                suggestedContentsCollectionView = value;
                OnPropertyChanged("SuggestedContentsCollectionView");
            }
        }
        public HomePageVM()
        {
            GetAppData();
            GetSuggestedContents();
            GetSuggestedMealPlanColection();
        }
        async Task GetAppData()
        {
            try
            {
                var LocalData =await App.Database.GetItemsAsync();
                if (LocalData.Count > 0)
                {
                   await BindPopularRecipesData(LocalData);
                }
                else
                   await GetRecipeResponse();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        async Task BindPopularRecipesData(List<LocalItemsModel> localItems)
        {
            try
            {
                var items = localItems.Take(5);
                popularRecipesCollectionView = new ObservableCollection<PopularRecipesCollection>();
                foreach (var item in items)
                {
                    PopularRecipesCollection collection = new PopularRecipesCollection();
                    collection.Caption = item.Name;
                    collection.Icon = item.FeaturedImage;
                    collection.Id = item.Id;
                    collection.Slug = item.Slug;
                    popularRecipesCollectionView.Add(collection);
                }
                PopularRecipesCollectionView = popularRecipesCollectionView;
            }
            catch (Exception ex)
            {
                return;
            }
        }
        async Task GetRecipeResponse()
        {
            try
            {
                RecipeLogic logic = new RecipeLogic();
                var result = await logic.GetRecipeResponseAsync();
                var LocalData = await App.Database.GetItemsAsync();
                await BindPopularRecipesData(LocalData);
                var mealType = result.Items.Select(x => x.MealType);
                var data = mealType.Take(10).ToList();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        async Task GetSuggestedMealPlanColection()
        {
            try
            {
                suggestedMealPlanColectionView = new List<SuggestedMealPlanCollection>()
                {
                    new SuggestedMealPlanCollection{ MealIcon="Group16002x.png", DayCaption="Monday", MealCaption="Bangus Sardines"},
                    new SuggestedMealPlanCollection{ MealIcon="RoundedDish2x.png", DayCaption="Tuesday", MealCaption="Stir-Fried Tofu"},
                    new SuggestedMealPlanCollection{ MealIcon="Group16002x.png", DayCaption="Wednesday", MealCaption="Bangus Sardines"},
                    new SuggestedMealPlanCollection{ MealIcon="RoundedDish2x.png", DayCaption="Thursday", MealCaption="Stir-Fried Tofu"},
                    new SuggestedMealPlanCollection{ MealIcon="Group16002x.png", DayCaption="Friday", MealCaption="Bangus Sardines"},
                    new SuggestedMealPlanCollection{ MealIcon="RoundedDish2x.png", DayCaption="Saturday", MealCaption="Stir-Fried Tofu"},
                    new SuggestedMealPlanCollection{ MealIcon="Group16002x.png", DayCaption="Sunday", MealCaption="Bangus Sardines"},
                };
            }
            catch (Exception ex)
            {
                return;
            }
        }
        async Task GetSuggestedContents()
        {
            try
            {
                suggestedContentsCollectionView = new List<SuggestedContentsCollection>()
                {
                    new SuggestedContentsCollection{ RecipeCaption="How to make a better kitchen", RecipeIcon="Group16012x.png", RecipeCategory="Lesson 1", PlayIcon="playbutton2x.png"},
                    new SuggestedContentsCollection{ RecipeCaption="Forest Feast", RecipeIcon="MaskGroup1082x.png", RecipeCategory="123 Pages\nArticle", PlayIcon=""},
                    new SuggestedContentsCollection{ RecipeCaption="How to make a better kitchen", RecipeIcon="MaskGroup1762x.png", RecipeCategory="Lesson 3", PlayIcon="playbutton2x.png"},
                    new SuggestedContentsCollection{ RecipeCaption="Forest Feast", RecipeIcon="MaskGroup1082x.png", RecipeCategory="123 Pages\nArticle", PlayIcon=""},
                };
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
