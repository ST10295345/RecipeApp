
using System;
using System.Collections.Generic;

namespace RecipeApp
{

    //the recipe class will collect the data and store it in the list??
    class Recipe
    {
        public List<string> recipeData = new List<string>();
        private double scalingFactor = 1.0;
        public int Calories { get; private set; }

        public string Name { get; set; }

        public void AddIngredient(string ingredient)
        {
            recipeData.Add(ingredient);
        }

        public void AddStep(string step)
        {
            recipeData.Add(step);
        }

        public void SetCalories(int calories)
        {
            Calories = calories;
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


        static void AddRecipe(Dictionary<string, Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = new Recipe();
            recipe.Name = recipeName;

            Console.Write("Please enter the number of ingredients in your recipe: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numIngredients; i++)
            {
                Console.Write($"Please enter the name of ingredient {i}: ");
                string name = Console.ReadLine();

                Console.Write($"Please enter the amount of ingredient {i} you want: ");
                double amount = double.Parse(Console.ReadLine());

                Console.Write($"Please enter the unit of measurement for ingredient {i}: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient($"Ingredient {i}: {amount} {unit} {name}");
            }


            while (true)
            {
                Console.Write("Would you like to enter a step? (y/n): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    Console.Write($"Enter step {recipe.recipeData.Count - numIngredients + 1}: ");
                    string stepDescription = Console.ReadLine();

                    recipe.AddStep($"Step {recipe.recipeData.Count - numIngredients + 1}: {stepDescription}");
                }
                else if (choice == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            Console.Write("Enter the number of calories in the recipe: ");
            int calories = int.Parse(Console.ReadLine());

            recipe.SetCalories(calories);

            recipes.Add(recipeName, recipe);
            Console.WriteLine($"Recipe '{recipeName}' has been added successfully.");
        }


        static void DeleteRecipe(Dictionary<string, Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe you want to delete: ");
            string recipeName = Console.ReadLine();

            if (recipes.ContainsKey(recipeName))
            {
                recipes.Remove(recipeName);
                Console.WriteLine($"Recipe '{recipeName}' has been deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }
        }


        static void ScaleRecipe(Dictionary<string, Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe you want to scale: ");
            string recipeName = Console.ReadLine();

            if (recipes.ContainsKey(recipeName))
            {
                Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());

                Recipe recipe = recipes[recipeName];
                recipe.ScaleRecipe(factor);
                Console.WriteLine($"Recipe '{recipeName}' has been scaled by a factor of {factor}.");
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }
        }


        static void DisplayRecipe(Dictionary<string, Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe you want to display: ");
            string recipeName = Console.ReadLine();

            if (recipes.ContainsKey(recipeName))
            {
                Recipe recipe = recipes[recipeName];
                recipe.DisplayRecipe();
                Console.WriteLine($"Calories: {recipe.Calories}");

                if (recipe.Calories > 300)
                {
                    Console.WriteLine("This recipe has more than 300 calories.");
                }
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }
        }


    }




}





