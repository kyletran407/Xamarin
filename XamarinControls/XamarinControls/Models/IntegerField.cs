using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Forms;
using XamarinControls.Bahaviors;

namespace XamarinControls.Models
{
    public class IntegerField : Field<int?>
    {
        public override void SetupBinding(VisualElement view, MultiValidationBehavior fieldValidationBehaviors)
        {
            base.SetupBinding(view, fieldValidationBehaviors);

            FieldValidationBehaviors.Children.Add(new IntegerFieldValidationBehavior());

            var entry = view as Entry;
            if (entry != null)
            {
                entry.Keyboard = Keyboard.Numeric;
            }
        }
    }
}
