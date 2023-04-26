
using System;
using System.Collections.Generic;

namespace RecipeApp
{

    //Decided on making these classes just hold variables.
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class Step
    {
        public int Number { get; set; }
        public string Description { get; set; }
    }

    //the recipe class will collect the data and store it in the array list?? lists??
    class Rescipe 
    {
        //the two lists and the scaling factor for when the user wants to scale up their recipe
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private List<Step> _steps = new List<Step>();
        private double _scalingFactor = 1.0;

        //adding ingredients to the ingredients array
        public void AddIngredient(string name, double quantity, string unit)
        {
            _ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
        }

        //adding ingredients to the steps array


    }

}

