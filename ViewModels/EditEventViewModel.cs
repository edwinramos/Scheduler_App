using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXMauiApp1.ViewModels
{
    [QueryProperty("EventId", "EventId")]
    public partial class EditEventViewModel : BaseViewModel
    {
        EventService eventService;
        [ObservableProperty]
        int eventId;

        [ObservableProperty]
        Event eventModel;
        public EditEventViewModel(EventService eventService, EventTypeService eventTypeService) : base(eventTypeService)
        {
            if (EventId != 0)
                Title = "Edit Event";
            else
                Title = "New Event";

            this.eventService = eventService;
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            await eventService.SaveEvent(EventModel);
            await Shell.Current.GoToAsync("..");
            //await Shell.Current.GoToAsync($"{nameof(EditEventPage)}", true,
            //    new Dictionary<string, object>
            //    {
            //    { "EventId", Appointment.Id }
            //    });
        }

        public async override Task OnAppearing()
        {
            await base.OnAppearing();
            EventModel = await eventService.GetEventById(EventId);
        }
    }
}
