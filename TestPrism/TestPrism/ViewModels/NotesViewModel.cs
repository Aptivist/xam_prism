using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace TestPrism.ViewModels
{
    public class NotesViewModel : BindableBase
    {
        private string _title;
        private readonly INavigationService _navigationService;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public DelegateCommand NextCommand { get; private set; }

        public NotesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NextCommand = new DelegateCommand(OnNextCommand);
           // NextCommand.

            //NextCommand.obs
            
        }

        private void OnNextCommand()
        {
            //navigate
            _navigationService.NavigateAsync("second");
        }
    }
}

