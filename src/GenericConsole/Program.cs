using System;

namespace GenericConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FireException();
            }
            catch(Exception ex) when (ex?.Message?.Length > 1)
            {
                Console.WriteLine($"Info when filter : {ex?.Message}");
                Console.WriteLine("Found match ex : "+ ex.Message);
            }




            Console.WriteLine("Finish!");
        }

        //static void FireException()
        //{
        //    throw null;
        //}

        static void FireException() => throw null;
    }
}
