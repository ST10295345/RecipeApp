
using System;
using System.Collections.Generic;

namespace RecipeApp
{

    //Decided on making these classes just hold variables.
    class Ingredient
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }

    class Step
    {
        public int Number { get; set; }
        public string Description { get; set; }
    }

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


        class Program
    {


        static void Main(string[] args)
        {

            //recipe class object
            Recipe recipe = new Recipe();

            // Getting the number of ingredients from the user
            Console.Write("Please enter the number of ingredients in your recipe: ");
            int numIngredients = int.Parse(Console.ReadLine());

            // Getting the ingredient details from the user
            for (int i = 1; i <= numIngredients; i++)
            {
                Console.Write($"Please enter the name of ingredient {i}: ");
                string name = Console.ReadLine();

                Console.Write($"Please enter the amount of ingredient {i} you want: ");
                double amount = double.Parse(Console.ReadLine());

                Console.Write($"Please enter the unit of measurement for ingredient {i}: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(name, amount, unit);
            }

            // Displaying the recipe
            recipe.DisplayRecipe();

            // Scaling the recipe
            Console.Write("\nPlease enter the scaling factor (0.5, 2, or 3) to adjust your recipe: ");
            double factor = double.Parse(Console.ReadLine());
            recipe.ScaleRecipe(factor);

            // Displaying the scaled recipe
            recipe.DisplayRecipe();

            // Resetting scaling factor for the user to enter another one
            recipe.ResetScalingFactor();
            recipe.DisplayRecipe();

            // Clear the recipe
            recipe.ClearRecipe();

        }




    }



}

