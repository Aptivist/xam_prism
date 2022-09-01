using System;
using Prism;
using Prism.Ioc;
using TestPrism.Interfaces;

namespace TestPrism.iOS
{
    public class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPhoneDialer, PhoneDialeriOS>();
        }
    }
}

