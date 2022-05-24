using System;
using TheEFCore.ConsoleApp.Model;

namespace TheEFCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var efContext = new learnContext())
            {
                Item item = new Item();
                item.Name = $"name {DateTime.Now.ToShortDateString()}";
                item.Description = $"desc on {DateTime.Now.ToLongTimeString()}";

                efContext.Items.Add(item);
                efContext.SaveChanges();
            }

            Console.WriteLine("Finish!");
        }
    }
}
 