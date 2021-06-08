using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XamarinControls.Bahaviors;
using XamarinControls.Models;

namespace XamarinControls.ViewModels
{
    public class SampleViewModel : BaseViewModel
    {
        public TextField FirstName { get; } = new TextField() { Label = "First Name", Mandatory = true };
        public TextField LastName { get; } = new TextField() { Label = "Last Name", Mandatory = true };
        public TextField Email { get; } = new TextField() { Label = "Email", Mandatory = true, BindingType = BindingType.Email };
        public TextField Password { get; } = new TextField() { Label = "Password", Mandatory = true, BindingType = BindingType.Password };
        public TextField ConfirmPassword { get; } = new TextField() { Label = "Confirm Password", Mandatory = true, BindingType = BindingType.Password };
        public DropDownListField<Gender> Gender { get; } = new DropDownListField<Gender>() { Label = "Gender", ItemsSource = Enums.Genders };

        public ICommand SubmitCommand => new AsyncCommand(ValidateFields);

        public SampleViewModel()
        {
            Title = "Sample";

            // Add confirm password validation
            ConfirmPassword.AddValidationBehavior(
                new CustomValidationBehavior<SampleViewModel>(
                    this, vm => vm.Password.Value == vm.ConfirmPassword.Value, "Confirm Password doesn't match."));
        }

        async Task ValidateFields()
        {
            if (!ValidateFields(FirstName, LastName, Email, Password, ConfirmPassword, Gender))
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