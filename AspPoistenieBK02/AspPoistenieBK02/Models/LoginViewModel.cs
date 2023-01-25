using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspPoistenieBK02.Models
{
    public class LoginViewModel
    {
        #region STRINGS AND ERR MSGS
        //musia byt konstanty, private aby to nebolo vidiet inde
        private const string str01_errLogInView_WrongEmail = "Neplatná emailová adresa";
        private const string str02_errLogInView_InputEmail = "Zadajte emailovú adresu";
        private const string str03_errLogInView_InputPassword = "Zadajte heslo";

        private const string str101_LogInView_DisplayPassword = "Heslo";
        private const string str102_LogInView_DisplayRemeberMe = "Pamätaj si ma";
        #endregion

        [Required(ErrorMessage = str02_errLogInView_InputEmail)]
        [EmailAddress(ErrorMessage = str01_errLogInView_WrongEmail)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = str03_errLogInView_InputPassword)]
        [DataType(DataType.Password)]
        [Display(Name = str101_LogInView_DisplayPassword)]
        public string Password { get; set; } = "";

        [Display(Name = str102_LogInView_DisplayRemeberMe)]
        public bool RememberMe { get; set; }
       

    }
}
