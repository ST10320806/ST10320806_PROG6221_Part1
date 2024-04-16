using ST10320806_PROG6221_Part1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10320806_PROG6221_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeManager rec1 = new RecipeManager();
            

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to Recipe Manager!");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe quantities");
                Console.WriteLine("5. Clear all recipes");
                Console.WriteLine("6. Exit");
                

                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        rec1.addRecipe();
                        break;
                    case "2":
                        rec1.DisplayRecipe();
                        break;
                    case "3":
                        Console.WriteLine("\nEnter scaling factor:");
                        int scaleFactor = Convert.ToInt32(Console.ReadLine());
                        rec1.ScaleRecipe(scaleFactor);
                        break;
                    case "4":
                        
                        rec1.ResetQuantities();
                        break;
                    case "5":
                        rec1.ClearRecipes();
                        break;
                    case "6":
                        exit = true;
                        break;
                    
                    
                }

                Console.WriteLine(); // Add a blank line for readability
            }
            


            Console.WriteLine("Press any key to exit application");
            Console.ReadKey();
        }
    }
}