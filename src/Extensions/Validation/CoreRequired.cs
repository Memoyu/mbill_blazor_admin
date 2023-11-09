using System.ComponentModel.DataAnnotations;

namespace Mbill.Admin.Extensions.Validation
{
    public class CoreRequired : ValidationAttribute
    {
        public CoreRequired()
        {
            ErrorMessage = "属性不能为空！";
        }
        public string Msg
        {
            get { return ErrorMessage; }
            set { ErrorMessage = value; }
        }

        public override bool IsValid(object value)
        {

            return !(value == null);
        }
    }
}
