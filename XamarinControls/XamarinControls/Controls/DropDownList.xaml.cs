using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinControls.Bahaviors;
using XamarinControls.Models;
using System.Collections.Generic;
using XamarinControls.Interfaces;

namespace XamarinControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropDownList : ContentView
    {
        public DropDownList()
        {
            InitializeComponent();
        }

        private bool _fieldbindingSet;

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Field field = BindingContext as Field;
            if (!_fieldbindingSet && field != null)
            {
                if (field.Mandatory)
                {
                    FieldValidationBehaviors.Children.Add(new MandatoryFieldValidationBehavior(field.Label));
                }

                var ddlField = field as IDropDownListField;
                if (ddlField != null)
                {
                    Picker.SetBinding(Picker.ItemsSourceProperty, "Items");
                    Picker.SetBinding(Picker.SelectedItemProperty, "SelectedItem");
                    Picker.ItemDisplayBinding = new Binding("Value");
                }

                field.FieldValidationBehaviors = FieldValidationBehaviors;
                _fieldbindingSet = true;
            }
        }
    }
}