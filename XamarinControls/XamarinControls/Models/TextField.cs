namespace XamarinControls.Models
{
    public enum BindingType { Text, Email, Password }

    public class TextField : Field<string>
    {
        public BindingType BindingType { get; set; }
    }
}
