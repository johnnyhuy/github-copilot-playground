using System;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius of the circle:");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double radius))
            {
                double area = Math.PI * radius * radius;
                Console.WriteLine($"The area of the circle is: {area}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }
}
