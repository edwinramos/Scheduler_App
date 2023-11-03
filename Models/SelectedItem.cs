using System;

namespace DXMauiApp1.Models
{
    public class SelectedItem
    {
        public SelectedItem(string value, string desc) 
        {
            this.Value = value;
            this.Description = desc;
        }  
        public string Value { get; set; }
        public string Description { get; set; }
    }
}