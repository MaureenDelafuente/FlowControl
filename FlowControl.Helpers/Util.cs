namespace FlowControl.Helpers
{
    public static class Util
    {
        public static void Main(string[] args)
        {
            string name = ReadString("name");
        }
        public static string ReadString(string prompt)
        {
            Console.Write($"{prompt}: ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                input = "";
            }

            return input;
        }

        public static int ReadInt(string prompt)
        {
            bool success = false;
            int number = 0;
            while (!success)
            {
                string input = ReadString(prompt); 
               
                success = int.TryParse(input, out number);
                if (!success)
                {
                    Console.WriteLine("Incorrect, you did not write a number!");
                }
            }
            return number;
        }
    }
}
