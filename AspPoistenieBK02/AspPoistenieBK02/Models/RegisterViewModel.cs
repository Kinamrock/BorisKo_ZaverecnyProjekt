using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspPoistenieBK02.Models
{
    public class RegisterViewModel
    {
        #region STRINGS AND ERR MSGS
        //musia byt konstanty, private aby to nebolo vidiet inde
        private const string str01_errRegisterView_InputEmail = "Neplatná emailová adresa";
        private const string str02_errRegisterView_InputPassword = "{0} musí mať dĺžku aspoň {2} a nejviac {1} znakov";
        private const string str03_errRegisterView_ComparePassword = "Zadané heslá sa musia zhodovať";
        private const string str04_errRegisterView_EnterEmail = "Zadajte emailovú adresu";
        private const string str05_errRegisterView_EnterPassword = "Zadajte heslo";
        private const string str06_errRegisterView_EnterConfirmPassword = "Zadajte potvrdenie hesla";

        private const string str101_Register_DisplayEmail = "Email";
        private const string str101_Register_DisplayPassword = "Heslo";
        private const string str101_Register_DisplayPasswordConfirm = "Potvrdenie hesla";

        #endregion

        [Required(ErrorMessage = str04_errRegisterView_EnterEmail)]
        [EmailAddress(ErrorMessage = str01_errRegisterView_InputEmail)]
        [Display(Name = str101_Register_DisplayEmail)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = str05_errRegisterView_EnterPassword)]
        [StringLength(20, ErrorMessage = str02_errRegisterView_InputPassword, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = str101_Register_DisplayPassword)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = str06_errRegisterView_EnterConfirmPassword)]
        [DataType(DataType.Password)]
        [Display(Name = str101_Register_DisplayPasswordConfirm)]
        [Compare("Password", ErrorMessage = str03_errRegisterView_ComparePassword)]
        public string ConfirmPassword { get; set; } = "";
    }
}
