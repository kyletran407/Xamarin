using System.Collections.Generic;
using XamarinControls.Models;

namespace XamarinControls.Interfaces
{
    public interface IDropDownListField
    {
        IList<ListItem> Items { get; }
    }
}
