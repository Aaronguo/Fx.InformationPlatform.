using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{

    public class EmailCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string match = @"^ \w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
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
