using Xamarin.CommunityToolkit.Behaviors;

namespace XamarinControls.Interfaces
{
    public interface IField
    {
        object Value { get; set; }
        string Label { get; set; }
        bool Mandatory { get; set; }
        MultiValidationBehavior FieldValidationBehaviors { get; }
    }
}
