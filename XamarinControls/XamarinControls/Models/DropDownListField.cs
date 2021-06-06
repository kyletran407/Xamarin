using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinControls.Interfaces;

namespace XamarinControls.Models
{
    public class DropDownListField<T> : Field<T>, IDropDownListField
    {
        readonly ObservableCollection<ListItem> _items = new ObservableCollection<ListItem>();

        public IList<ListItem> Items => _items;

        protected ListItem<T> _selectedItem;
        public virtual ListItem<T> SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                Value = value.Key;
            }
        }

        public IEnumerable<ListItem<T>> ItemsSource
        {
            set
            {
                _items.Clear();
                foreach (var i in value)
                {
                    _items.Add(i);
                }
            }
        }
    }
}
