using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XamarinControls.Models;

namespace XamarinControls.ViewModels
{
    public class SampleViewModel : BaseViewModel
    {
        public SampleViewModel()
        {
            Title = "Sample";
        }

        public TextField FirstName { get; } = new TextField() { Label = "First Name", Mandatory = true };
        public TextField LastName { get; } = new TextField() { Label = "Last Name", Mandatory = true };
        public TextField Email { get; } = new TextField() { Label = "Email", Mandatory = true, BindingType = BindingType.Email };
        public TextField Password { get; } = new TextField() { Label = "Password", Mandatory = true, BindingType = BindingType.Password };
        public DropDownListField<Gender> Gender { get; } = new DropDownListField<Gender>() { Label = "Gender", ItemsSource = Enums.Genders };

        public ICommand SubmitCommand => new AsyncCommand(ValidateFields);

        async Task ValidateFields()
        {
            if (!ValidateFields(FirstName, LastName, Email, Password, Gender))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Invalid Form", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Valid Form", "OK");
            }
        }
    }
}