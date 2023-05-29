
using System;
using System.Collections.Generic;

namespace RecipeApp
{

    //the recipe class will collect the data and store it in the array list?? lists??
    class Recipe
    {
        private List<string> recipeData = new List<string>();
        private double scalingFactor = 1.0;

        public string Name { get; set; }

        public void AddIngredient(string ingredient)
        {
            recipeData.Add(ingredient);
        }

        public void AddStep(string step)
        {
            recipeData.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*** Recipe ***\n");
            Console.ResetColor();

            Console.WriteLine($"Recipe Name: {Name}");

            Console.WriteLine("\nIngredients:");
            int ingredientCount = 1;
            foreach (var item in recipeData)
            {
                if (item.StartsWith("Ingredient"))
                {
                    Console.WriteLine($"  {ingredientCount}. {item}");
                    ingredientCount++;
                }
            }

            Console.WriteLine("\nSteps:");
            int stepCount = 1;
            foreach (var item in recipeData)
            {
                if (item.StartsWith("Step"))
                {
                    Console.WriteLine($"  {stepCount}. {item}");
                    stepCount++;
                }
            }
        }

        public void ScaleRecipe(double factor)
        {
            scalingFactor = factor;
        }

        public void ResetScalingFactor()
        {
            scalingFactor = 1.0;
        }

        public void ClearRecipe()
        {
            recipeData.Clear();
            scalingFactor = 1.0;
        }
    }

    //


    class Program
    {


        static void Main(string[] args)
        {

            Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();


            while (true)
            {

                Console.WriteLine("===== Recipe App =====");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Delete Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Display Recipe");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice (1-5): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddRecipe(recipes);
                        break;
                    case 2:
                        DeleteRecipe(recipes);
                        break;
                    case 3:
                        ScaleRecipe(recipes);
                        break;
                    case 4:
                        DisplayRecipe(recipes);
                        break;
                    case 5:
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

    }




    }



}

