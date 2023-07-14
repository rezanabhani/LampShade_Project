using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int number1 =0;
            //int number2 = 0;
            //int sum = 0;
            //Console.WriteLine("Please Enter Number 1");
            //number1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Please Enter Number2");
            //number2 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Sum :");
            //sum = number1 * number2;
            //Console.WriteLine(sum);
            //Console.ReadKey();

            int number1 = 0;
            int number2 = 0;
            int sum = 0;
            string operation;

            Console.WriteLine("Please Enter Number 1");
            number1 = Convert.ToInt32(Console.ReadLine());

            operation = Console.ReadLine();

            Console.WriteLine("Please Enter Number2");
            number2 = Convert.ToInt32(Console.ReadLine());


            if (operation == "+")
            {
                sum = number1 + number2;
            }
            else if(operation == "-") 
            {
                sum = number1 - number2;
            }
            else if (operation == "*")
            {
                sum = number1 * number2;
            }
            else if (operation == "/")
            {
                sum = number1 / number2;
            }

            Console.WriteLine(sum);
            Console.ReadKey();

        }
    }
}
