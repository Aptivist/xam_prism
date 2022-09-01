using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace TestPrism.ViewModels
{
    public class NotesViewModel : BindableBase
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
    }
}

