using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BeautySalon
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Заполните поле");

            dynamic client = value;
            if (string.IsNullOrWhiteSpace(client.lastName))
                return new ValidationResult(false, "Заполните поле");

            return ValidationResult.ValidResult;
        }
    }

}
