using Microsoft.Deployment.WindowsInstaller;
using System.Text.RegularExpressions;

namespace UserInputValidation
{
    public class CustomActions
    {
public static bool PhoneNumberValidator(string phoneNumber)
        {
            string phoneNumberPattern = @"^09\d{9}$";
            Regex regex = new Regex(phoneNumberPattern);
            return regex.IsMatch(phoneNumber);
        }

        public static bool NameValidator(string name)
        {
            string namePattern = @"^[a-zA-Zآ-ی\s]{3,}$";
            Regex regex = new Regex(namePattern);
            return regex.IsMatch(name);
        }

        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            session.Log("User input validation bagan...");
            string first_name = session["FIRST_NAME_VALUE"];
            string last_name = session["LAST_NAME_VALUE"];
            string phone_number = session["PHONE_NUMBER_VALUE"];
            
            bool isFirstNameValid = NameValidator(first_name);
            bool isLastNameValid = NameValidator(last_name);
            bool isPhoneNumberValid = PhoneNumberValidator(phone_number);
            
            if (!isFirstNameValid) {
                session["VALIDATION_RESULT"] = "نام شما باید تنها شامل حروف و بیش از سه حرف باشد.";
            } else if (!isLastNameValid)
            {
                session["VALIDATION_RESULT"] = "نام خانوادگی شما باید تنها شامل حروف و بیش از سه حرف باشد";
            } else if (!isPhoneNumberValid)
            {
                session["VALIDATION_RESULT"] = "شماره موبایل خود را به صورت صحیح وارد نمایید";
            } else
            {
                session["VALIDATION_RESULT"] = "bravo, all valid!";
            }

            return ActionResult.Success;
        }

        
    }
}
