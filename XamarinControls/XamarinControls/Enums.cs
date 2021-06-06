using System.Collections.Generic;
using XamarinControls.Models;

namespace XamarinControls
{
    public enum Gender { Male = 1, Female =2 }

    public static class Enums
    {
        public static IEnumerable<ListItem<Gender>> Genders = GetGenders();

        private static IEnumerable<ListItem<Gender>> GetGenders()
        {
            yield return new ListItem<Gender>(Gender.Male, "Male");
            yield return new ListItem<Gender>(Gender.Female, "Female");
        }
    }
}
