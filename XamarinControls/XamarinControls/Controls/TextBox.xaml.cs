using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinControls.Bahaviors;
using XamarinControls.Models;

namespace XamarinControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextBox : ContentView
    {
        public TextBox()
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

                var txtField = field as TextField;
                if (txtField != null)
                {
                    if (txtField.BindingType == BindingType.Email)
                    {
                        FieldValidationBehaviors.Children.Add(new EmailFieldValidationBehavior());
                    }

                    if (txtField.BindingType == BindingType.Password)
                    {
                        Entry.IsPassword = true;
                    }
                }

                field.FieldValidationBehaviors = FieldValidationBehaviors;
                _fieldbindingSet = true;
            }
        }
    }
}