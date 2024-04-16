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
        
        public List<string> Ingredients { get; set; } = new List<string>();//Declaring an array for the storage of ingredients
        public List<string> Steps { get; set; } = new List<string>();//Declaring an array for the storage of steps;

        public List<int> sFactor { get; set; } = new List<int>();//Declaring an array in which the scale factor will be stored
                                                                 

        public void addRecipe()//Method for adding a recipe
        {
            Console.WriteLine("\n*****************************************\nENTERING A RECIPE: ");
            try
            {
                Console.WriteLine("Enter the number of ingredients you would like to enter");
                int iAmount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < iAmount; i++)//For loop which runs for the amount of ingredients the user would like to enter
                {


                    Console.WriteLine($"Ingredient {i + 1}:");//Iterates the ingredient number

                    Console.WriteLine("Enter Ingredient Name: ");
                    string iName = Console.ReadLine();
                    Console.WriteLine("Enter ingredient quantity");
                    int iQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter unit of measurement: ");
                    string uMeasurement = Console.ReadLine();
                    //Code for the capture of recipe details from user input

                    string ingredient = $"{iQuantity} {uMeasurement} of {iName}";//string manipulation to provide a format for the ingredients
                    Ingredients.Add(ingredient);//adding the ingredients to the array


                }
                try
                {
                    Console.WriteLine("Enter amount of steps: ");
                    int steps = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the steps: ");
                    for (int i = 0; i < steps; i++)//for loop runs for the amount of steps the user would like to enter
                    {
                        Console.WriteLine($"Step {i + 1}:");//iteration for the steps


                        string Step = Console.ReadLine().Trim();
                        Steps.Add(Step);// adding the steps to the array
                    }
                }
                catch (FormatException)// re-worked from code provided by chatGPT: https://chat.openai.com/
                {
                    Console.WriteLine("Invalid input, please try again");
                    addRecipe();
                }
                Console.WriteLine("RECIPE SUCCESSFULLY CAPTURED\n*****************************************");
            }

            catch (FormatException)// exception handling to make sure the user enters a valid number
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                addRecipe(); //calling method so that user can retry in case of an exception
            }
        }

    public void DisplayRecipe()// method for the display of the recipe
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//Changing the text colour of the displayed recipe. Adapted from code taken from: https://www.tutorialspoint.com/how-to-change-the-foreground-color-of-text-in-chash-console
            Console.WriteLine("\nFull Recipe: \n------------------------------------------------");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");//creating the format in which the ingredients will be displayed
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");//creating the format in which the steps will be displayed
            }
            Console.WriteLine("-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;// changing the text colour back
        }

        public void ScaleRecipe(int scaleFactor)//method for scaling the ingredients to a certain factor
        {
            //Scale factor is captured in the main
            sFactor.Add(scaleFactor);//adding the scale factor to the sFactor array


            for (int i = 0; i < Ingredients.Count; i++)//for loop created so that the scale factor is multiplied by each ingredient
            {
                // Splitting the ingredient string into parts so that only the quantity is changed
                string ingredient = Ingredients[i];
                //storing the different parts of the ingredient string
                string[] parts = ingredient.Split(' ');//adapted from code taken from: https://ironpdf.com/blog/net-help/csharp-split-string-guide/#:~:text=In%20C%23%2C%20the%20String.,based%20on%20a%20given%20separator.

                if (int.TryParse(parts[0], out int quantity))//making sure quantity is the first part of the string(Re-worked from code provided by Claude AI: https://claude.ai/chats)
                {
                    string unit = parts[1];
                    string name = string.Join(" ", parts, 3, parts.Length - 3);
                    int sQuantity = quantity * scaleFactor;//multiplying the quantity by the scale factor
                    Ingredients[i] = $"{sQuantity} {unit} of {name}";// displaying the new scaled ingredients in the correct format
                }
            }

                Console.WriteLine("\nRecipe scaled successfully.");
                Console.WriteLine("Scaled Recipe: \n**********************************************");
                DisplayRecipe();//Displaying the scaled recipe
                Console.WriteLine("**********************************************");

            
        }




        public void ResetQuantities()// method for resetting the scaled ingredients back to the unscaled ingredients
    {

            int scaleFactor = sFactor[sFactor.Count - 1]; // Getting the last scaling factor from the sFactor array

            for (int i = 0; i < Ingredients.Count; i++)//For loop to iterate through each ingredient
            {
                string ingredient = Ingredients[i];
                string[] parts = ingredient.Split(' ');

                if (int.TryParse(parts[0], out int quantity))
                {
                    string unit = parts[1];
                    string name = string.Join(" ", parts, 3, parts.Length - 3); 
                    int originalQuantity = quantity / scaleFactor;// resetting the quantity by simply dividing the new quantity by the scale factor
                    Ingredients[i] = $"{originalQuantity} {unit} of {name}";//displaying the new reset ingredients in teh correct format
                }
                
            }

            Console.WriteLine("\nQuantities reset successfully.");
            Console.WriteLine("Reset recipe: ");
            DisplayRecipe();//displaying the new reset recipe
        }

        public void ClearRecipes()//method for clearing all recipes and prompting the user to add another
        {
            Ingredients.Clear();//clearing the ingredients array
            Steps.Clear();//clearing the steps array
            sFactor.Clear();//clearing the sFactor array
            Console.WriteLine("\nRecipe has been reset");
            addRecipe();//prompting the user to add another recipe by calling the addRecipe method
        }
    }
    }

