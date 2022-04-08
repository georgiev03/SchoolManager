using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Core.CustomAttributes
{
    public class DateRangeAttribute : ValidationAttribute
    {
        DateTime MinDate, MaxDate;

        public DateRangeAttribute(string minDate, string maxDate)
        {
            MinDate = DateTime.Parse(minDate);
            MaxDate = DateTime.Parse(maxDate);
            if (string.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = $"Date must be between {minDate} and {maxDate}";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            var d = (DateTime)value;
            if (d < MinDate || d > MaxDate)
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }

}
