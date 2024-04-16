using ST10320806_PROG6221_Part1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Jesse Weeder
/// ST10320806
/// Module PROG6221
/// </summary>

namespace ST10320806_PROG6221_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeManager rec1 = new RecipeManager();//created an instance of the RecipeManager class
            

            bool exit = false;

            while (!exit)// while loop which creates the menu
            {
                //Different options the user can select
                Console.WriteLine("WELCOME TO THE RECIPE MANAGER!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\n1. Add a new recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe quantities");
                Console.WriteLine("5. Clear all recipes");
                Console.WriteLine("6. Exit");
                

                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();// capturing the users input

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
                        //Capturing the scale factor
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
            Console.ReadKey();// tool for exiting the application
        }
    }
}