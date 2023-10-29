using CommunityToolkit.Mvvm.ComponentModel;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System.Collections.ObjectModel;
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

        EventTypeService eventTypeService;
        public BaseViewModel(EventTypeService eventTypeService)
        {
            EventTypes = new ObservableCollection<EventType>();
            this.eventTypeService = eventTypeService;
        }
        public ObservableCollection<EventType> EventTypes { get; private set; }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public INavigationService Navigation => DependencyService.Get<INavigationService>();
        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }

        public virtual async Task OnAppearing()
        {
            foreach (var item in await eventTypeService.GetAllEventTypes())
            {
                EventTypes.Add(item);
            }
        }
    }
}