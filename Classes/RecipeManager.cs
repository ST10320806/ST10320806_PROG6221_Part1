using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ST10320806_PROG6221_Part1.Classes
{
    internal class RecipeManager
    {
        
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Steps { get; set; } = new List<string>();
        public List<int> sFactor { get; set; } = new List<int>();
        //public string Step {  get; set; }
        //public string ingredient { get; set; }
       
        public void addRecipe()
        {
            Console.WriteLine("\n*****************************************\nENTERING A RECIPE: ");
            
            Console.WriteLine("Enter the number of ingredients you would like to enter");
            int iAmount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < iAmount; i++)
            {
                

                Console.WriteLine($"Ingredient {i + 1}:");

                Console.WriteLine("Enter Ingredient Name: ");
                string iName = Console.ReadLine();
                Console.WriteLine("Enter ingredient quantity");
                int iQuantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter unit of measurement: ");
                string uMeasurement = Console.ReadLine();
               string ingredient = $"{iQuantity} {uMeasurement} of {iName}";
                Ingredients.Add(ingredient);


            }
            Console.WriteLine("Enter amount of steps: ");
            int steps = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the steps: ");
            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");


                string Step = Console.ReadLine().Trim();
                Steps.Add(Step);
            }
            Console.WriteLine("RECIPE SUCCESSFULLY CAPTURED\n*****************************************");
        }

        public void DisplayRecipe() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Full Recipe: \n------------------------------------------------");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            Console.WriteLine("-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ScaleRecipe(int scaleFactor)
        {
            sFactor.Add(scaleFactor);


            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Split ingredient string into parts
                string ingredient = Ingredients[i];
                string[] parts = ingredient.Split(' ');



                // Extract quantity, unit, and name
                if (int.TryParse(parts[0], out int quantity))
                {
                    string unit = parts[1];
                    string name = string.Join(" ", parts, 3, parts.Length - 3);
                    int sQuantity = quantity * scaleFactor;
                    Ingredients[i] = $"{sQuantity} {unit} of {name}";
                }
                else
                {
                    Console.WriteLine($"Invalid quantity in ingredient: {ingredient}");
                }

                Console.WriteLine("Recipe scaled successfully.");
                Console.WriteLine("Scaled Recipe: \n**********************************************");
                DisplayRecipe();
                Console.WriteLine("**********************************************");

            }
        }




        public void ResetQuantities()
    {
            if(sFactor.Count == 0)
            {
                Console.WriteLine("No scaling factor available to reset quantities.");
                return;
            }

            int scaleFactor = sFactor[sFactor.Count - 1]; // Get the last scaling factor

            Console.WriteLine($"\nResetting quantities by dividing by scaling factor of {scaleFactor}...");

            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Split ingredient string into parts
                string ingredient = Ingredients[i];
                string[] parts = ingredient.Split(' ');

                // Extract quantity, unit, and name
                if (int.TryParse(parts[0], out int quantity))
                {
                    string unit = parts[1];
                    string name = string.Join(" ", parts, 3, parts.Length - 3); // Join remaining parts as name

                    // Calculate original quantity by dividing scaled quantity by scaleFactor
                    int originalQuantity = quantity / scaleFactor;

                    // Update ingredient string with original quantity
                    Ingredients[i] = $"{originalQuantity} {unit} of {name}";
                }
                else
                {
                    Console.WriteLine($"Invalid quantity in ingredient: {ingredient}");
                }
            }

            Console.WriteLine("Quantities reset successfully.");
            Console.WriteLine("Reset Quantity: ");
            DisplayRecipe();
        }

        public void ClearRecipes()
        {
            Ingredients.Clear();
            Steps.Clear();
            Console.WriteLine("Recipe has been reset");
            addRecipe();
        }
    }
    }

