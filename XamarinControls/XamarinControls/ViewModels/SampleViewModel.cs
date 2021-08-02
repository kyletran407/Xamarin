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
        public TextField FirstName { get; }
        public TextField LastName { get; }
        public TextField Email { get; }
        public TextField Password { get; }
        public TextField ConfirmPassword { get; }
        public DropDownListField<Gender> Gender { get; }
        public IntegerField Age { get; }

        public ICommand SubmitCommand => new AsyncCommand(ValidateFields);

        public SampleViewModel()
        {
            Title = "Sample";

            FirstName = new TextField()
            {
                Label = "First Name",
                Mandatory = true
            };

            LastName = new TextField()
            {
                Label = "Last Name",
                Mandatory = true
            };

            Email = new TextField()
            {
                Label = "Email",
                Mandatory = true,
                BindingType = Models.TextType.Email
            };

            Password = new TextField()
            {
                Label = "Password",
                Mandatory = true,
                BindingType = Models.TextType.Password
            };

            ConfirmPassword = new TextField()
            {
                Label = "Confirm Password",
                Mandatory = true,
                BindingType = Models.TextType.Password
            };

            Gender = new DropDownListField<Gender>()
            {
                Label = "Gender",
                ItemsSource = Enums.Genders
            };

            Age = new IntegerField
            {
                Label = "Age",
                Mandatory = true
            };

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