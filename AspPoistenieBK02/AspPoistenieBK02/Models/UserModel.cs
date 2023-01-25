using AspPoistenieBK02.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspPoistenieBK02.Models
{
    public class UserModel
    {
        public enum EUserGender
        {
            [Display(Name = str01e_User_GenderMale)] Male,
            [Display(Name = str02e_User_GenderFemale)] Female,
            [Display(Name = str03e_User_GenderUknown)] Uknown
        }

        #region PRIVATE STRINGS AND ERR MSGS
        //musia byt konstanty, private aby to nebolo vidiet inde
        private const string str01_errUser_InputFirstName   = "Zadajte meno";
        private const string str02_errUser_InputLastName    = "Zadajte priezvisko";
        private const string str03_errUser_InputEmail       = "Zadajte email";
        private const string str04_errUser_InputPhoneNumber = "Zadajte telefónne číslo";
        private const string str05_errUser_InputBirthDate   = "Zadajte dátum narodenia";
        private const string str06_errUser_InputAddress     = "Zadajte adresu";
        private const string str07_errUser_InputCity        = "Zadajte mesto";
        private const string str08_errUser_InputZipCode     = "Zadajte PSČ";
        private const string str09_errUser_InputGender      = "Zvoľte pohlavie";


        private const string str06_errUser_FirstNameTooLong = "Meno je príliš dlhé! Max 30 znakov.";
        private const string str07_errUser_FirstNameTooShort = "Meno je príliš krátke! Min 3 znaky.";
        private const string str08_errUser_LastNameTooLong = "Priezvisko je príliš dlhé! Max 30 znakov.";
        private const string str09_errUser_LastNameTooShort = "Priezvisko je príliš krátke! Min 3 znaky.";

        private const string str01e_User_GenderMale   = "Muž";
        private const string str02e_User_GenderFemale = "Žena";
        private const string str03e_User_GenderUknown = "Nechcem uviesť..."; //musime byt korektny :-(

        private const string str101_User_DisplayFirstName = "Meno";
        private const string str102_User_DisplayLastName = "Priezvisko";
        private const string str103_User_DisplayEmail = "Email";
        private const string str104_User_DisplayPhone = "Telefónne číslo";
        private const string str105_User_DisplayBirthDay = "Dátum narodenia";
        private const string str106_User_DisplayAdress = "Adresa a číslo popisné";
        private const string str107_User_DisplayCity = "Mesto";
        private const string str108_User_DisplayZipCode = "PSČ";
        private const string str109_User_DisplayGender = "Pohlavie";

        #endregion
        #region PUBLIC STRINGS

        #endregion

#warning dorobit asi aj zadanie titulu pred menom a za menom
#warning dorobit plnoletost pre niektore poistenia - automaticky dopocet
#warning dorobit check pre date aby nebol v buducnosti

        public int Id { get; set; }

        [Display(Name = str101_User_DisplayFirstName)]
        [Required(ErrorMessage = str01_errUser_InputFirstName)]
        [StringLength(30, ErrorMessage = str06_errUser_FirstNameTooLong)]
        [MinLength(3, ErrorMessage = str07_errUser_FirstNameTooShort)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = str102_User_DisplayLastName)]
        [Required(ErrorMessage = str02_errUser_InputLastName)]
        [StringLength(30, ErrorMessage = str08_errUser_LastNameTooLong)]
        [MinLength(3, ErrorMessage = str09_errUser_LastNameTooShort)]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = str103_User_DisplayEmail)]
        [Required(ErrorMessage = str03_errUser_InputEmail)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = str104_User_DisplayPhone)]
        [Required(ErrorMessage = str04_errUser_InputPhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = str105_User_DisplayBirthDay)]
        [Required(ErrorMessage = str05_errUser_InputBirthDate)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = str106_User_DisplayAdress)]
        [Required(ErrorMessage = str06_errUser_InputAddress)]
        public string UserAdress { get; set; } = string.Empty;

        [Display(Name = str107_User_DisplayCity)]
        [Required(ErrorMessage = str07_errUser_InputCity)]
        public string UserCity { get; set; } = string.Empty;

        [Display(Name = str108_User_DisplayZipCode)]
        [Required(ErrorMessage = str08_errUser_InputZipCode)]
        public string UserZipCode { get; set; } = string.Empty;

        [Display(Name = str109_User_DisplayGender)]
        [Required(ErrorMessage = str09_errUser_InputGender)]
        public EUserGender UserGender { get; set; }

        [NotMapped]
        public List<InsuranceModel>? UserInsurances { get; private set; } = null;


        #region public methods
        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public string GetUserAdress()
        {
            return string.Format("{0}, {1}", UserAdress, UserCity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUserGender()
        {
            string returnStr = "";
            switch (UserGender)
            {
                case EUserGender.Male:   returnStr = str01e_User_GenderMale;   break;
                case EUserGender.Female: returnStr = str02e_User_GenderFemale; break;
                case EUserGender.Uknown: returnStr = str03e_User_GenderUknown; break;
                default: returnStr = "[UserModel] ERR - wrong EUserGender!!!"; break;
            }

            return returnStr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetUserAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;

            if (BirthDate.Date > today.AddYears(-age)) age--;

            return age;
        }

        public void SetUserInsurances(ApplicationDbContext context, int userIDkey)
        {
            UserInsurances = context.InsuranceModel.Where(s => s.UserId.Equals(userIDkey)).ToList();
        }


        #endregion

    }
}    
