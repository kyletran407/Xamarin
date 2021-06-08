using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Behaviors;

namespace XamarinControls.Interfaces
{
    public interface IField
    {
        string Label { get; set; }
        bool Mandatory { get; set; }
        MultiValidationBehavior FieldValidationBehaviors { get; }
        object Value { get; set; }
    }
}
