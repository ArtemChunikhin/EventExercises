using System;

namespace lr4_2_FibonacciNumbersEvent_
{
    internal class NumEventArgs : EventArgs
    {
        public readonly UInt32 number;
        public readonly Int32 numberPosition;
        public NumEventArgs(UInt32 number, Int32 numberPosition)
        {
            this.number = number;
            this.numberPosition = numberPosition;
        }
    }
}
