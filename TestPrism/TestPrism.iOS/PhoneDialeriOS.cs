using System;
using TestPrism.Interfaces;

namespace TestPrism.iOS
{
    public class PhoneDialeriOS : IPhoneDialer
    {
        public void Call(string phone)
        {
            Console.WriteLine("From iOS...");

        }
    }
}

