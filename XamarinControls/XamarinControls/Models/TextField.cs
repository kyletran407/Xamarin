using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Forms;
using XamarinControls.Bahaviors;

namespace XamarinControls.Models
{
    public enum BindingType { Text, Email, Password }

    public class TextField : Field<string>
    {
        public BindingType BindingType { get; set; }

        public override void SetupBinding(VisualElement view, MultiValidationBehavior fieldValidationBehaviors)
        {
            base.SetupBinding(view, fieldValidationBehaviors);

            if (BindingType == BindingType.Email)
            {
                FieldValidationBehaviors.Children.Add(new EmailFieldValidationBehavior());
            }

            if (BindingType == BindingType.Password)
            {
                var entry = view as Entry;
                if (entry != null)
                    entry.IsPassword = true;
            }
        }
    }
}
