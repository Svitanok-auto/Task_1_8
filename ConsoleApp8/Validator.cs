using System;

namespace ConsoleApp8
{
    public class Validator
    {
        public const int MAX_ATTEMPTS = 30;
        public int GetChoiceToShowShipmentInfo()
        {
            Console.WriteLine("\nIf you want to see Shipment info only, please push 1; If you want to see Shipments with Orders, please push 2");
            int attempt = 0;
            int choiceToSeeGarland = 0;
            while (attempt < MAX_ATTEMPTS)
            {
                string inputString = Console.ReadLine();
                if ((inputString.ToString() != string.Empty) && ((inputString.ToString() == "1") || (inputString.ToString() == "2")))
                {
                    try
                    {
                        if ((inputString.IndexOf('0') != -1) && (inputString.Length == 1))
                        {
                            Console.WriteLine("\nIncorrect Input: Zero is not allowed ");
                            attempt++;
                            continue;
                        }
                        else
                        {
                            choiceToSeeGarland = Convert.ToInt32(inputString);
                            Console.WriteLine("\n Choice is= " + choiceToSeeGarland);
                            return choiceToSeeGarland;
                        }
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine("\nIncorrect Input, error: " + ex.Message);
                        Console.WriteLine("\nMake a choice 1 or 2");
                        attempt++;
                    }
                }
                else
                {
                    Console.WriteLine("\nIncorrect Input: Such value is not allowed");
                }
            }
            return 0;
        }

    }
}
