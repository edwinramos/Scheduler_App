using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Scheduler;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using DXMauiApp1.Views;
using System.Collections.ObjectModel;

namespace DXMauiApp1.ViewModels
{
    [QueryProperty("Date", "Date")]
    public partial class DayViewViewModel : BaseViewModel
    {
        EventService eventService;
        public DayViewViewModel(EventService eventService, EventTypeService eventTypeService) : base (eventTypeService)
        {
            Title = "Day View";
            DayEvents = new ObservableCollection<Event>();
            this.eventService = eventService;
        }

        [ObservableProperty]
        DateTime date;

        public ObservableCollection<Event> DayEvents { get; private set; }

        public async Task SelectEventAsync(int id)
        {
            var obj = await eventService.GetEventById(id);
            await Shell.Current.GoToAsync($"{nameof(AppointmentPage)}", true,
                new Dictionary<string, object>
                {
                { "EventId", obj.Id }
                });
        }
        async public Task OnAppearing()
        {
            await base.OnAppearing();
            IEnumerable<Event> events = await eventService.GetDateEvent(Date);
            DayEvents.Clear();
            foreach (Event ev in events)
            {
                DayEvents.Add(ev);
            }
        }
    }
}