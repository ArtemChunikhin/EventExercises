using System;

namespace lr4_2_FibonacciNumbersEvent_
{

    public delegate void FullScreenDelegate(out Boolean terminate);
    internal static class  EventServices
    {
        public static EventHandler<NumEventArgs> OnPrimeNumber;
        public static FullScreenDelegate OnFullScreen;

        public static void UserService(out Boolean isTerminate)
        {
            Int32 userChoose = 0;
            Console.WriteLine("Enter 1 - Clear Screen And continue | 2 - End Up Program");
            if (!Int32.TryParse(Console.ReadLine(), out userChoose))
            {
                throw new FormatException("Wrong format!");
            }
            else
            {
                switch (userChoose)
                {
                    case 1:
                        Console.Clear();
                        isTerminate = false;
                        break;
                    case 2:
                        isTerminate = true;
                        break;
                    default:
                        throw new FormatException("Wrong format!");
                }
            }
        }
        public static void PrintDigit(Object sender, NumEventArgs e)
        {
            Console.WriteLine("[Number: {0}] [Position: {1}]", e.number, e.numberPosition+1);
        }
        public static Boolean IsSimple(UInt32 value)
        {
            for (UInt32 i = 2; i < value / 2; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
