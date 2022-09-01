using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace TestPrism.ViewModels
{
    public class NoteDetailViewModel : BindableBase, INavigationAware
    {
        private string _entryValue;
        public string EntryValue
        {
            get => _entryValue;
            set => SetProperty(ref _entryValue, value);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                var entry = parameters.GetValue<string>("entryValue");
                EntryValue = entry;
            }
        }
    }
}

