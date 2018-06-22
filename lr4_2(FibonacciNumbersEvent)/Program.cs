using System;
using System.Collections.Generic;

namespace lr4_2_FibonacciNumbersEvent_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UInt32> fibonacciNumbers = new List<UInt32>();

            EventServices.OnPrimeNumber += EventServices.PrintDigit;
            EventServices.OnFullScreen += EventServices.UserService;
            Boolean isTerminate;

            Int32 simpleNumCounter = 0;

            Int32 index = 0;
            while (true)
            {
                if (fibonacciNumbers.Count == 0)
                {
                    fibonacciNumbers.Add(0);
                }
                else
                {
                    if (fibonacciNumbers.Count == 1)
                    {
                        fibonacciNumbers.Add(1);
                    }
                    else
                    {
                        fibonacciNumbers.Add(fibonacciNumbers[index - 2] + fibonacciNumbers[index - 1]);
                        if (EventServices.IsSimple(fibonacciNumbers[index]) && EventServices.OnPrimeNumber != null)
                        {
                            EventServices.OnPrimeNumber(null, new NumEventArgs(fibonacciNumbers[index], index));
                            simpleNumCounter++;
                            if (simpleNumCounter % 10 == 0 && EventServices.OnFullScreen != null)
                            {
                                try
                                {
                                    EventServices.OnFullScreen(out isTerminate);
                                    if (isTerminate)
                                    {
                                        return;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    break;
                                }
                            }
                        }
                    }
                }
                index++;
            }
        }
    }
}
