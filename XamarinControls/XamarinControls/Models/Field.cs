using Xamarin.CommunityToolkit.Behaviors;
using XamarinControls.ViewModels;

namespace XamarinControls.Models
{
    public class Field<T> : Field
    {
        protected T _value;
        public virtual T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }

    public abstract class Field : BaseViewModel
    {
        private string _label;
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public bool Mandatory { get; set; }

        public MultiValidationBehavior FieldValidationBehaviors { get; set; }
    }
}
