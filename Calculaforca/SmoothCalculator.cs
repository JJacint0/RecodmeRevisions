using System;

namespace Calculaforca
{
    public class SmoothCalculator
    {
        public static double Add(double fstNumb, double sndNumb)
        {
            return fstNumb + sndNumb;
        }

        public static double Subtract(double fstNumb, double sndNumb)
        {
            return fstNumb - sndNumb;
        }

        public static double Multiply(double fstNumb, double sndNumb)
        {
            return fstNumb * sndNumb;
        }

        public static double Divide(double fstNumb, double sndNumb)
        {
            return fstNumb / sndNumb;
        }

        public static bool IsValidNumber(out double numb)
        {
            Console.WriteLine("Numbero em inglês?");
            if ((double.TryParse(Console.ReadLine(), out numb)))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Inválido em inglês");
                return false;
            }
        }

        public static double SmoothOperation()
        {
            double numbaro1 = 0;
            double numbaro2 = 0;
            double result = 0;
            IsValidNumber(out numbaro1);
            Console.WriteLine("operação inglesa com O grande?");
            char op = Console.ReadKey().KeyChar;
            IsValidNumber(out numbaro2);

            switch (op)
            {
                case '+':
                    result = Add(numbaro1, numbaro2);
                    break;
                case '-':
                    result = Subtract(numbaro1, numbaro2);
                    break;
                case '*':
                    result = Multiply(numbaro1, numbaro2);
                    break;
                case '/':
                    result = Divide(numbaro1, numbaro2);
                    break;
                default:
                    break;
            }

            Console.WriteLine(result);
            return result;
        }
    }
}
