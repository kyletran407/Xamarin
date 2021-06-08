using System.Collections.Generic;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.CommunityToolkit.Behaviors.Internals;
using Xamarin.Forms;
using XamarinControls.Bahaviors;
using XamarinControls.Interfaces;
using XamarinControls.ViewModels;

namespace XamarinControls.Models
{
    public class Field<T> : Field, IField
    {
        protected T _value;
        public virtual T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        object IField.Value 
        { 
            get => Value; 
            set => Value = (T)value; 
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

        public MultiValidationBehavior FieldValidationBehaviors { get; private set; }

        private List<ValidationBehavior> _additionalValidationBehaviors = new List<ValidationBehavior>();

        public void AddValidationBehavior(ValidationBehavior vb)
        {
            _additionalValidationBehaviors.Add(vb);
        }

        public virtual void SetupBinding(VisualElement view, MultiValidationBehavior fieldValidationBehaviors)
        {
            FieldValidationBehaviors = fieldValidationBehaviors;

            foreach (var vb in _additionalValidationBehaviors)
                fieldValidationBehaviors.Children.Add(vb);

            if (Mandatory)
            {
                FieldValidationBehaviors.Children.Add(new MandatoryFieldValidationBehavior(Label));
            }
        }
    }
}
