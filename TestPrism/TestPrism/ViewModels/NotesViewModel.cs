using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TestPrism.Interfaces;

namespace TestPrism.ViewModels
{
    public class NotesViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPhoneDialer _phoneDialer;
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
        public DelegateCommand CallCommand { get; private set; }

        public DelegateCommand NextCommand { get; private set; }
        
        public NotesViewModel(INavigationService navigationService,
            IPhoneDialer phoneDialer)
        {
            _phoneDialer = phoneDialer;
            _navigationService = navigationService;
            NextCommand = new DelegateCommand(OnNextCommand);
            CallCommand = new DelegateCommand(OnCallCommand, () =>
            {
                if (string.IsNullOrEmpty(MyText))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }).ObservesProperty(() => MyText);
        }

        private void OnCallCommand()
        {
            _phoneDialer.Call(MyText);
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
            Console.WriteLine("OnNavigatedFrom");
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

