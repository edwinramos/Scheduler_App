using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Editors;
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
    public enum RepeatEvent
    {
        Never = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    }
    [QueryProperty("EventId", "EventId")]
    public partial class EditEventViewModel : BaseViewModel
    {
        EventService eventService;
        EventRepeatedService eventRepeatedService;

        [ObservableProperty]
        bool notAllDay;

        [ObservableProperty]
        bool monthWeekInfo;

        [ObservableProperty]
        bool showWeekInfo;

        [ObservableProperty]
        int eventId;

        [ObservableProperty]
        Event eventModel;

        [ObservableProperty]
        List<SelectedItem> repeatEvent;

        [ObservableProperty]
        string selectedRepeatEvent;

        [ObservableProperty]
        IList<string> days;
        
        [ObservableProperty]
        List<string> selectedDays;
        public EditEventViewModel(EventService eventService, EventRepeatedService eventRepeatedService, EventTypeService eventTypeService) : base(eventTypeService)
        {
            Title = "Manage Events";
            Days = new List<string> 
            {
            "M",
            "T",
            "W",
            "T",
            "F",
            "S",
            "D",
            };
            SelectedDays = new List<string>();
            this.eventService = eventService;
            this.eventRepeatedService = eventRepeatedService;
        }

        [RelayCommand]
        public async Task ChangeRepeatFrequencyAsync()
        {
            ShowWeekInfo = false;
            MonthWeekInfo = false;
            switch (SelectedRepeatEvent)
            {
                case "0":

                    break;
                case "1":
                    break;
                case "2":
                    ShowWeekInfo = true;
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (SelectedRepeatEvent is not null)
            {
                var obj = new EventRepeated { EventId = EventModel.Id, DateOnFinish = DateTime.Now, AfterOcurrencesFinish = 0, NeverFinish = false };
                
                switch (SelectedRepeatEvent)
                {
                    case "0":
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                }

                await eventRepeatedService.SaveEventRepeated(obj);
            }
            await eventService.SaveEvent(EventModel);
            await Shell.Current.GoToAsync("..");
        }

        public void ToggleAllDayAsync()
        {
            if (EventModel != null)
                NotAllDay = !EventModel.AllDay;
        }
        public async override Task OnAppearing()
        {
            await base.OnAppearing();
            RepeatEvent = new List<SelectedItem>
            {
                new SelectedItem("0", "Never"),
                new SelectedItem("1", "Daily"),
                new SelectedItem("2", "Weekly"),
                new SelectedItem("3", "Monthly"),
                new SelectedItem("4", "Yearly"),
            };
            SelectedRepeatEvent = "0";

            EventModel = await eventService.GetEventById(EventId);
            NotAllDay = !EventModel.AllDay;
        }
    }
}
