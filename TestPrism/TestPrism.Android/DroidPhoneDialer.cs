using System;
using TestPrism.Interfaces;

namespace TestPrism.Droid
{
    public class DroidPhoneDialer : IPhoneDialer
    {
        public void Call(string phone)
        {
            Console.WriteLine($"From Android... {phone}");
        }
    }
}

