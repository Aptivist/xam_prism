using System;
using Prism;
using Prism.Ioc;
using TestPrism.Interfaces;

namespace TestPrism.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPhoneDialer, DroidPhoneDialer>();
        }
    }
}

