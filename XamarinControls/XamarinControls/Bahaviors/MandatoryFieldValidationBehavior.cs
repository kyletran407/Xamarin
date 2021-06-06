using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.CommunityToolkit.Behaviors.Internals;

namespace XamarinControls.Bahaviors
{
    public class MandatoryFieldValidationBehavior : ValidationBehavior
    {
        public MandatoryFieldValidationBehavior(string label) : base()
        {
            Flags = ValidationFlags.ValidateOnValueChanging;
            SetValue(MultiValidationBehavior.ErrorProperty, $"{label} is required.");
        }

        protected override ValueTask<bool> ValidateAsync(object value, CancellationToken token)
        {
            var result = true;
            if (value == null)
                result = false;

            var str = value as string;
            if (str != null && string.IsNullOrEmpty(str))
                result = false;

            return new ValueTask<bool>(result);
        }
    }
}
