using System.Threading.Channels;
using FlowControl.Helpers;

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boolean exit = false;
            while (!exit)
            {

                Console.WriteLine("Welcome! This is the main menu.\nYou navigate by typing one of these command numbers 0-1-2-3");
                Console.WriteLine("0. Exit the program");
                Console.WriteLine("1. Calculate movie discounts based on age");
                Console.WriteLine("2. Calculate movie ticket price for groups");
                Console.WriteLine("3. Repeat some text");
                Console.WriteLine("4. Third word");

                string number = Console.ReadLine();
                switch (number)
                {
                    case "0":
                        exit = true;
                        Console.WriteLine("Good bye!");
                        break;
                    case "1":
                        // cinema check if retired or youth
                        MovieDiscount();
                        break;
                    case "2":
                        MovieDiscountGroup();
                        break;
                    case "3":
                        RepeatText();
                        break;
                    case "4":
                        ThirdWord();
                        break;

                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
            }
        }

        private static void ThirdWord()
        {
            string sentence = Util.ReadString("write at least 3 words");
            var words = sentence.Split(" ");
            string thirdWord = words[2];
            Console.WriteLine($"The third word was '{thirdWord}'");
        }

        private static void RepeatText()
        {
            string text = Util.ReadString("Text to repeat");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}. {text} ");
            }
            Console.WriteLine(); // empty line after
        }

        private static void MovieDiscountGroup()
        {
            //Vi vill även få möjlighet att kunna räkna ut priset för ett helt sällskap. Lägg till det
            //    alternativet i huvudmenyn(ett case “2”). Det är även ok att ha alternativet i en undermeny.
            //    Vi anger då först hur många vi är som ska gå på bio.Frågar sedan efter ålder på var och en
            //och skriver sedan ut en sammanfattning i konsolen som ska innehålla följande:
            //    ● Antal personer
            //    ● Samt totalkostnad för hela sällskapet
            int numberOfAttendants = Util.ReadInt("Number of attendants");
            int totalPrice = 0;
            for (int i = 1; i <= numberOfAttendants; i++)
            {
                int age = Util.ReadInt($"age of attendant {i}:");
                int price = GetTicketPrice(age);
                totalPrice += price;
            }

            Console.WriteLine($"The total price for all the tickets is {totalPrice}");
        }

        private static int GetTicketPrice(int age)
        {
            if (age < 5 || age > 100)
            {
                Console.WriteLine("You get free entrance");
                return 0;
            }
            else if (age < 20)
            {
                Console.WriteLine("Youth price: 80kr");
                return 80;
            }
            else if (age > 64)
            {
                Console.WriteLine("Retiree price: 90kr");
                return 90;
            }
            else
            {
                Console.WriteLine("Standard price: 120kr");
                return 120;
            }
        }
        private static void MovieDiscount()
        {
            int age = Util.ReadInt("age");
            if (age < 20)
            {
                Console.WriteLine("Youth price: 80kr");
            }
            else if (age > 64)
            {
                Console.WriteLine("Retiree price: 90kr");
            }
            else
            {
                Console.WriteLine("Standard price: 120kr");
            }
        }


    }
}
