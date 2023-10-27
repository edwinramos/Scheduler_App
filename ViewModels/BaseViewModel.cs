using CommunityToolkit.Mvvm.ComponentModel;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DXMauiApp1.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
        public BaseViewModel()
        {

        }

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public INavigationService Navigation => DependencyService.Get<INavigationService>();
        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}