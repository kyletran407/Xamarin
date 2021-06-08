using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.CommunityToolkit.Behaviors.Internals;

namespace XamarinControls.Bahaviors
{
    public class CustomValidationBehavior<T> : ValidationBehavior
    {
        private T _context;

        private Func<T, bool> _validationAction;

        public CustomValidationBehavior(T context, Func<T, bool> validationAction, string errorMessage)
        {
            _context = context;
            _validationAction += validationAction;
            SetValue(MultiValidationBehavior.ErrorProperty, errorMessage);
        }

        protected override ValueTask<bool> ValidateAsync(object value, CancellationToken token)
        {
            var result = _validationAction?.Invoke(_context) ?? true;
            return new ValueTask<bool>(result);
        }
    }
}
