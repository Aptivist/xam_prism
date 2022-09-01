using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace TestPrism.ViewModels
{
    public class NotesViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _myText;
        public string MyText
        {
            get => _myText;
            set => SetProperty(ref _myText, value);
        }

        private string _backValue;
        public string BackValue
        {
            get => _backValue;
            set => SetProperty(ref _backValue, value);
        }

        public DelegateCommand NextCommand { get; private set; }

        public NotesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NextCommand = new DelegateCommand(OnNextCommand);
        }

        private void OnNextCommand()
        {
            //navigate
            var parameters = new NavigationParameters();
            parameters.Add("entryValue", MyText);
            _navigationService.NavigateAsync("second", parameters);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                Console.WriteLine("Navigating to NEW!!!");
            }

            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                var backValue = parameters.GetValue<string>("backValue");
                BackValue = backValue;
            }
        }
    }
}

