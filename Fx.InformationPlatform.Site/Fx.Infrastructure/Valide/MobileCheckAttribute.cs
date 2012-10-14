using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MobileCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string match = @"^[1][3-5]\d{9}$";
            if (value == null || !Regex.IsMatch(value.ToString(), match))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
