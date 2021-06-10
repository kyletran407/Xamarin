using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.CommunityToolkit.Behaviors.Internals;

namespace XamarinControls.Bahaviors
{
    public class IntegerFieldValidationBehavior : ValidationBehavior
    {
        public IntegerFieldValidationBehavior() : base()
        {
            Flags = ValidationFlags.ValidateOnValueChanging;
            SetValue(MultiValidationBehavior.ErrorProperty, $"Invalid integer format.");
        }

        protected override ValueTask<bool> ValidateAsync(object value, CancellationToken token)
        {
            var result = value == null || int.TryParse(value.ToString(), out _);
            return new ValueTask<bool>(result);
        }
    }
}
