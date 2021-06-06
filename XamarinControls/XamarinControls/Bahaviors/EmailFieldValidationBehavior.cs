using Xamarin.CommunityToolkit.Behaviors;

namespace XamarinControls.Bahaviors
{
    public class EmailFieldValidationBehavior : TextValidationBehavior
    {
        public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        
        public EmailFieldValidationBehavior() : base()
        {
            Flags = ValidationFlags.ValidateOnValueChanging;
            RegexPattern = EmailRegex;
            SetValue(MultiValidationBehavior.ErrorProperty, "Invalid email.");
        }
    }
}
