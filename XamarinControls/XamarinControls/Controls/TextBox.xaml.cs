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
                field.SetupBinding(Entry, FieldValidationBehaviors);
                _fieldbindingSet = true;
            }
        }
    }
}