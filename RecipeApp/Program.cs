
using System;
using System.Collections.Generic;

namespace RecipeApp
{

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


}

