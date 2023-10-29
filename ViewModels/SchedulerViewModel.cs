using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Scheduler;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using DXMauiApp1.Views;
using System.Collections.ObjectModel;

namespace DXMauiApp1.ViewModels
{
    public partial class SchedulerViewModel : BaseViewModel
    {
        EventService eventService;
        public SchedulerViewModel(EventService eventService, EventTypeService eventTypeService) : base (eventTypeService)
        {
            Title = "Scheduler";
            Items = new ObservableCollection<Event>();
            this.eventService = eventService;
        }

        public ObservableCollection<Event> Items { get; private set; }

        public async Task SelectDayAsync(DateTime date)
        {
            await Shell.Current.GoToAsync($"{nameof(DayViewPage)}", true,
                new Dictionary<string, object>
                {
                { "Date", date }
                });
        }

        public async override Task OnAppearing()
        {
            await base.OnAppearing();
            IEnumerable<Event> events = await eventService.GetMonthEvents(DateTime.Today.Month);
            Items.Clear();
            foreach (Event ev in events)
            {
                Items.Add(ev);
            }
        }
    }
}