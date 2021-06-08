using System.Collections.Generic;
using XamarinControls.Models;

namespace XamarinControls.Interfaces
{
    public interface IDropDownListField : IField
    {
        IList<ListItem> Items { get; }

        ListItem SelectedItem { get; set; }

        IEnumerable<ListItem> ItemsSource { set; }
    }
}
