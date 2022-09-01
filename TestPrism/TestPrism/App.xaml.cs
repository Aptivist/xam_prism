using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using TestPrism.Pages;
using TestPrism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestPrism
{
    public partial class App : PrismApplication
    {

        public App() : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NoteDetailPage, NoteDetailViewModel>("second");
            containerRegistry.RegisterForNavigation<NotesPage, NotesViewModel>(nameof(NotesViewModel));
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(nameof(NotesViewModel));
        }
    }
}

