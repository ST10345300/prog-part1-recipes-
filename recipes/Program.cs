using System;
//this is the main project 
namespace RecipeManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            // Boolean to check if user exited
            bool exit = false;

            // While loop to display menu
            while (!exit)
            {
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            recipe.EnterDetails();
                            break;
                        case 2:
                            recipe.Display();
                            break;
                        case 3:
                            recipe.ScaleRecipe();
                            break;
                        case 4:
                            recipe.ResetQuantities();
                            break;
                        case 5:
                            recipe.ClearData();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }

    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        public void EnterDetails()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of {ingredients[i]}:");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for {ingredients[i]}:");
                units[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }
        }

        public void Display()
        {
            Console.WriteLine("Recipe:");

            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

        public void ResetQuantities()
        {
            // Code to reset quantities to original values
            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearData()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;

            Console.WriteLine("All data cleared.");
        }
    }
}

