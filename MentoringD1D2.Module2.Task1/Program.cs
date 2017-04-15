using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Module2.Task1.Attributes;
using MentoringD1D2.Module2.Task1.Helpers;

namespace MentoringD1D2.Module2.Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var developers = DeveloperHelper.GetDeveloperAttributes(typeof (TestHelper))?.ToList();
            if (developers != null && developers.Any())
            {
                developers.ForEach(x => Console.WriteLine($"Name: {x.Name}, Email: {x.Email}"));
            }
            else
            {
                Console.WriteLine($"There aren't any developer attributes related to {typeof(TestHelper)}.");
            }
            Console.ReadKey();
        }
        
    }
}
