using System;
using System.Collections.Generic;

namespace Worksheet10
{
    public class WS10
    {
        //public static void G1Ex1()
        //{
        //    Console.WriteLine("Nome?");
        //    string name = Console.ReadLine();
        //    Console.WriteLine($"Holá desculpa, my name is " + name);
        //}


        #region Temp Converter
        //public static void TempConverter()
        //{
        //    Console.WriteLine("Temperatura?");
        //    double temp;
        //    bool validMeasure = false;
        //    if (double.TryParse(Console.ReadLine(), out temp))
        //    {
        //        var tempCToF = temp * 9 / 5 + 32;
        //        var tempCToK = temp + 273.15;
        //        var tempFToC = 5 / 9 * (temp - 32);
        //        var tempFToK = 5 / 9 * (temp - 32) + 273;
        //        var tempKToC = temp - 273;
        //        var tempKToF = 9 / 5 * (temp - 273) + 32;

        //        while (validMeasure == false)
        //        {
        //            Console.WriteLine("Medida? (C, F ou K?)");
        //            char measure = Console.ReadKey().KeyChar;
        //            Console.Clear();


        //            switch (measure)
        //            {
        //                case 'c':
        //                    Console.WriteLine($"A temperatura {temp}Cº é {tempCToF}Fº e {tempCToK}Kº");
        //                    validMeasure = true;
        //                    break;
        //                case 'f':
        //                    Console.WriteLine($"A temperatura {temp}Fº é {tempFToC}Cº e {tempFToK}Kº");
        //                    validMeasure = true;
        //                    break;
        //                case 'k':
        //                    Console.WriteLine($"A temperatura {temp}Kº é {tempKToF}Fº e {tempKToC}Cº");
        //                    validMeasure = true;
        //                    break;
        //                default:
        //                    Console.WriteLine("Invalid measure");
        //                    break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid Number");
        //        TempConverter();
        //    }



            //measure == 'c' ? Console.WriteLine($"A temperatura {temp}Cº é {tempCToF}Fº e {tempCToK}Kº") :
            //measure == 'f' ? Console.WriteLine($"A temperatura {temp}Fº é {tempFToC}Cº e {tempFToK}Kº") :
            //measure == 'k' ? Console.WriteLine($"A temperatura {temp}Kº é {tempKToF}Fº e {tempKToC}Cº")
        //}
        #endregion

        #region Refactoring Temp Converter
        public static bool IsValidNumber(out double temp)
        {
            Console.WriteLine("Temperatura?");
            if ((double.TryParse(Console.ReadLine(), out temp)))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Inválido");
                return false;
            }
        }

        public static bool IsValidChar(out string measure)
        {
            Console.WriteLine("Medida? (C, F ou K?)");
            string letter = Console.ReadLine();
            if (letter == "c" || letter == "f" || letter == "k")
            {
                measure = letter;
                return true;
            }
            else
            {
                Console.WriteLine("Inválido");
                measure = letter;
                return false;
            }
        }

        public static void ConvertCelsius(double temp)
        {
            var tempCToF = temp * 9 / 5 + 32;
            var tempCToK = temp + 273.15;
            Console.WriteLine($"A temperatura {temp}Cº é {tempCToF}Fº e {tempCToK}Kº");
        }

        public static void ConvertFahrenheit(double temp)
        {
            var tempFToC = 5 / 9 * (temp - 32);
            var tempFToK = 5 / 9 * (temp - 32) + 273; ;
            Console.WriteLine($"A temperatura {temp}Fº é {tempFToC}Cº e {tempFToK}Kº");
        }

        public static void ConvertKelvin(double temp)
        {
            var tempKToC = temp - 273;
            var tempKToF = 9 / 5 * (temp - 273) + 32;
            Console.WriteLine($"A temperatura {temp}Kº é {tempKToF}Fº e {tempKToC}Cº");
        }

        public static void TemperatureConverter()
        {
            bool validNumber = false;
            double temperature = 0;

            while (validNumber == false)
            {
              validNumber = IsValidNumber(out double temp);
              temperature = temp;
            }

            bool validChar = false;
            string measure = "";

            while (validChar == false)
            {
                validChar = IsValidChar(out string type);
                measure = type;
            }

            if (measure == "c") ConvertCelsius(temperature);
            else if (measure == "f") ConvertFahrenheit(temperature);
            else if (measure == "k") ConvertKelvin(temperature);
        }

        #endregion

        #region Shopping
        public static void ShoppingCart()
        {
            bool isOver = false;
            double ttotal = 0;

            List<string> productList = new List<string>();

            while (isOver == false)
            {
                double total;

                string product;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Produto?");
                Console.ForegroundColor = ConsoleColor.White;
                product = Console.ReadLine();

                double price = 0;
                bool checkPrice = false;
                while(checkPrice == false)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Preço?");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.Clear();
                        Console.WriteLine($"Produto? \n{product}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operação inválida.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Produto? \n{product} \nPreço? \n{price}");
                        checkPrice = true;
                    }
                }
                

                int quantity = 0;
                bool checkQuantity = false;
                while(checkQuantity == false)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Quantidade?");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (!int.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.Clear();
                        Console.WriteLine($"Produto? \n{product} \nPreço? \n{price}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operação inválida.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        checkQuantity = true;
                    }
                }

                total = price * quantity;
                ttotal += total;
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                productList.Add($"{product} x {quantity} (p.u. {price}€) = {total}€");
                Console.Clear();

                foreach (string item in productList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"\nTotal = {ttotal}€");

                bool anythingElse = false;
                while (anythingElse == false)
                {
                    Console.WriteLine($"\nVai desejar mais alguma coisa?(Y/N)");
                    string selection = Console.ReadKey().KeyChar.ToString().ToUpper();
                    if (selection == "Y")
                    {
                        isOver = false;
                        anythingElse = true;
                        Console.Clear();
                        Console.WriteLine($"Total = {ttotal}€\n");
                    }
                    else if (selection == "N")
                    {
                        isOver = true;
                        anythingElse = true;
                        Console.Clear();
                        foreach (string item in productList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine($"\nTotal = {ttotal}€");
                    }
                    else if (selection != "Y" || selection != "N")
                    {
                        anythingElse = false;
                        Console.Clear();
                        foreach (string item in productList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine($"\nTotal = {ttotal}€");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\nOperação inválida.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
        #endregion

        

    }
}
