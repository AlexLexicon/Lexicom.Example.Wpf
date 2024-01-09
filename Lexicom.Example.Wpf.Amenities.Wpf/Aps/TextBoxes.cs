using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lexicom.Example.Wpf.Amenities.Wpf.Aps;
public static class TextBoxes
{
    private static HashSet<int> HashCodesOfTextBoxesBeingValidated { get; } = [];

    private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        Validate(sender);
    }

    private static void Validate(object obj)
    {
        if (obj is TextBox textBox)
        {
            int hashCode = textBox.GetHashCode();
            if (!HashCodesOfTextBoxesBeingValidated.Contains(hashCode))
            {
                HashCodesOfTextBoxesBeingValidated.Add(hashCode);

                Func<string?, IEnumerable<string?>>? validation = GetValidation(textBox);

                IEnumerable<string?>? errors = validation?.Invoke(textBox.Text);
                bool isValid = errors is not null && !errors.Any();

                SetErrors(textBox, errors);
                SetIsValid(textBox, isValid);

                ICommand? command = GetValidateCommand(textBox);
                object? parameter = GetValidateCommandParameter(textBox);

                command?.Execute(parameter);

                HashCodesOfTextBoxesBeingValidated.Remove(hashCode);
            }
        }
    }

    /*
     * Validation
     */
    public static readonly DependencyProperty ValidationProperty = DependencyProperty.RegisterAttached("Validation", typeof(Func<string?, IEnumerable<string?>>), typeof(TextBoxes), new FrameworkPropertyMetadata(null, OnValidationProperty_TextBox_PropertyChanged));
    public static Func<string?, IEnumerable<string?>>? GetValidation(DependencyObject obj) => (Func<string?, IEnumerable<string?>>?)obj.GetValue(ValidationProperty);
    public static void SetValidation(DependencyObject obj, Func<string?, IEnumerable<string?>>? validation) => obj.SetValue(ValidationProperty, validation);
    private static void OnValidationProperty_TextBox_PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (dependencyObject is TextBox textBox)
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.TextChanged += TextBox_TextChanged;

            Validate(textBox);
        }
    }

    /*
     * IsValid
     */
    public static readonly DependencyProperty IsValidProperty = DependencyProperty.RegisterAttached("IsValid", typeof(bool), typeof(TextBoxes), new FrameworkPropertyMetadata(true, OnIsValidProperty_TextBox_PropertyChanged));
    public static bool GetIsValid(DependencyObject obj) => (bool)obj.GetValue(IsValidProperty);
    public static void SetIsValid(DependencyObject obj, bool isValid) => obj.SetValue(IsValidProperty, isValid);
    private static void OnIsValidProperty_TextBox_PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (dependencyObject is TextBox textBox)
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.TextChanged += TextBox_TextChanged;

            Validate(textBox);
        }
    }

    /*
     * Errors
     */
    public static readonly DependencyProperty ErrorsProperty = DependencyProperty.RegisterAttached("Errors", typeof(IEnumerable<string?>), typeof(TextBoxes), new FrameworkPropertyMetadata(null, OnValidationProperty_TextBox_PropertyChanged));
    public static IEnumerable<string?>? GetErrors(DependencyObject obj) => (IEnumerable<string?>?)obj.GetValue(ErrorsProperty);
    public static void SetErrors(DependencyObject obj, IEnumerable<string?>? errors) => obj.SetValue(ErrorsProperty, errors);
    private static void OnErrorsProperty_TextBox_PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (dependencyObject is TextBox textBox)
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.TextChanged += TextBox_TextChanged;

            Validate(textBox);
        }
    }

    /*
     * ValidateCommand
     */
    public static readonly DependencyProperty ValidateCommandProperty = DependencyProperty.RegisterAttached("ValidateCommand", typeof(ICommand), typeof(TextBoxes), new FrameworkPropertyMetadata(null, OnValidateCommandProperty_TextBox_PropertyChanged));
    public static ICommand? GetValidateCommand(DependencyObject obj) => (ICommand?)obj.GetValue(ValidateCommandProperty);
    public static void SetValidateCommand(DependencyObject obj, ICommand? command) => obj.SetValue(ValidateCommandProperty, command);
    private static void OnValidateCommandProperty_TextBox_PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (dependencyObject is TextBox textBox)
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.TextChanged += TextBox_TextChanged;

            Validate(textBox);
        }
    }

    /*
     * ValidateCommandParameter
     */
    public static readonly DependencyProperty ValidateCommandParameterProperty = DependencyProperty.RegisterAttached("ValidateCommandParameter", typeof(object), typeof(TextBoxes), new FrameworkPropertyMetadata(null, OnValidateCommandParameterProperty_TextBox_PropertyChanged));
    public static object? GetValidateCommandParameter(DependencyObject obj) => (object?)obj.GetValue(ValidateCommandParameterProperty);
    public static void SetValidateCommandParameter(DependencyObject obj, object? parameter) => obj.SetValue(ValidateCommandParameterProperty, parameter);
    private static void OnValidateCommandParameterProperty_TextBox_PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (dependencyObject is TextBox textBox)
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.TextChanged += TextBox_TextChanged;

            Validate(textBox);
        }
    }
}
