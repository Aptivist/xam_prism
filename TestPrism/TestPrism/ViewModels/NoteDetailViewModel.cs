using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace TestPrism.ViewModels
{
    public class NoteDetailViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _entryValue;
        public string EntryValue
        {
            get => _entryValue;
            set => SetProperty(ref _entryValue, value);
        }

        public DelegateCommand BackCommad { get; private set; }

        public NoteDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackCommad = new DelegateCommand(OnBackCommad);
        }

        private void OnBackCommad()
        {
            //navigate
            var parameters = new NavigationParameters();
            parameters.Add("backValue", "something from back");
            _navigationService.GoBackAsync(parameters);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Console.WriteLine("OnNavigatedFrom - NoteDetailViewModel");

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

