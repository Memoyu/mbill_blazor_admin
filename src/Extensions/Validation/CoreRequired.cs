using System.ComponentModel.DataAnnotations;

namespace mbill_blazor_admin.Extensions.Validation
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
