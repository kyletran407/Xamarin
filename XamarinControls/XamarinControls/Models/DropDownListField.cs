using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Forms;
using XamarinControls.Interfaces;

namespace XamarinControls.Models
{
    public class DropDownListField<T> : Field<T>, IDropDownListField
    {
        readonly ObservableCollection<ListItem> _items = new ObservableCollection<ListItem>();

        public IList<ListItem> Items => _items;

        protected ListItem<T> _selectedItem;
        public  ListItem<T> SelectedItem
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

        ListItem IDropDownListField.SelectedItem
        {
            get => SelectedItem;
            set => SelectedItem = (ListItem<T>)value;
        }

        IEnumerable<ListItem> IDropDownListField.ItemsSource
        {
            set => ItemsSource = (IEnumerable<ListItem<T>>)value;
        }

        public override void SetupBinding(VisualElement view, MultiValidationBehavior fieldValidationBehaviors)
        {
            base.SetupBinding(view, fieldValidationBehaviors);
        }
    }
}
