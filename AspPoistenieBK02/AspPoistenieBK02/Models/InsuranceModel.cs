using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspPoistenieBK02.Models
{
    public class InsuranceModel
    {
        public enum EInsuranceType
        {
            [Display(Name = str01e_InsuranceType_PersonalInsurance)]              PersonalInsurance,
            [Display(Name = str02e_InsuranceType_LifeInsurance)]                  LifeInsurance,
            [Display(Name = str03e_InsuranceType_TravelInsurance)]                TravelInsurance,
            [Display(Name = str04e_InsuranceType_AccidentInsurance)]              AccidentInsurance,
            [Display(Name = str05e_InsuranceType_HealthInsurance)]                HealthInsurance,
            [Display(Name = str06e_InsuranceType_PropertyInsurance)]              PropertyInsurance,
            [Display(Name = str07e_InsuranceType_NaturalDisasterInsurance)]       NaturalDisasterInsurance,
            [Display(Name = str08e_InsuranceType_TechnicalInsurance)]             TechnicalInsurance,
            [Display(Name = str09e_InsuranceType_CarInsurance)]                   CarInsurance,
            [Display(Name = str10e_InsuranceType_BusinessInsurance)]              BusinessInsurance,
            [Display(Name = str11e_InsuranceTypeLiabilityInsurance)]              LiabilityInsurance,
            [Display(Name = str12e_InsuranceType_ProffesionalLiabilityInsurance)] ProffesionalLiabilityInsurance
        }

        #region STRINGS AND ERR MSGS
        //musia byt konstanty, private aby to nebolo vidiet inde
        private const string str01_errInsurance_InputAmount    = "Zadajte hodnotu poistenia";
        private const string str02_errInsurance_InputSubject   = "Zadajte predmet/osobu poistenia";
        private const string str03_errInsurance_InputValidFrom = "Zadajte dátum platnosti od";
        private const string str04_errInsurance_InputValidTo   = "Zadajte dátum platnosti do";

        private const string str05_errInsurance_AmountIsTooLow = "Zadaj hodnotu vyššiu ako 0,- €";

        public  const string str101_Insurance_DisplayInsuranceType = "Poistenie";
        public  const string str102_Insurance_DisplayAmmount       = "Čiastka v €";
        private const string str103_Insurance_DisplaySubject       = "Predmet/Osoba poistenia";
        private const string str104_Insurance_DisplayValidFrom     = "Platnosť od";
        public  const string str105_Insurance_DisplayValidTo       = "Platnosť do";
        private const string str106_Insurance_DisplayPayment       = "Mesačná splátka";

        #endregion

        #region PUBLIC STRINGS
        public const string str01e_InsuranceType_PersonalInsurance              = "Osobné poistenie";
        public const string str02e_InsuranceType_LifeInsurance                  = "Životné poistenie";
        public const string str03e_InsuranceType_TravelInsurance                = "Cestovné poistenie";
        public const string str04e_InsuranceType_AccidentInsurance              = "Úrazové poistenie";
        public const string str05e_InsuranceType_HealthInsurance                = "Zdravotné poistenie";
        public const string str06e_InsuranceType_PropertyInsurance              = "Majetkové poistenie";
        public const string str07e_InsuranceType_NaturalDisasterInsurance       = "Živelné poistenie";
        public const string str08e_InsuranceType_TechnicalInsurance             = "Technické poistenie";
        public const string str09e_InsuranceType_CarInsurance                   = "Poistenie vozidla";
        public const string str10e_InsuranceType_BusinessInsurance              = "Poistenie podnikania";
        public const string str11e_InsuranceTypeLiabilityInsurance              = "Poistenie odpovednosti";
        public const string str12e_InsuranceType_ProffesionalLiabilityInsurance = "Positenie profesionálnej odpovednosti";

#warning pridat popis poistenia
        public const string str01e_InsuranceType_PersonalInsuranceDescription = "Osobné poistenie - popis";
        public const string str02e_InsuranceType_LifeInsuranceDescription = "Životné poistenie - popis";
        public const string str03e_InsuranceType_TravelInsuranceDescription = "Cestovné poistenie - popis";
        public const string str04e_InsuranceType_AccidentInsuranceDescription = "Úrazové poistenie - popis";
        public const string str05e_InsuranceType_HealthInsuranceDescription = "Zdravotné poistenie - popis";
        public const string str06e_InsuranceType_PropertyInsuranceDescription = "Majetkové poistenie - popis";
        public const string str07e_InsuranceType_NaturalDisasterInsuranceDescription = "Živelné poistenie - popis";
        public const string str08e_InsuranceType_TechnicalInsuranceDescription = "Technické poistenie - popis";
        public const string str09e_InsuranceType_CarInsuranceDescription = "Poistenie vozidla - popis";
        public const string str10e_InsuranceType_BusinessInsuranceDescription = "Poistenie podnikania - popis";
        public const string str11e_InsuranceTypeLiabilityInsuranceDescription = "Poistenie odpovednosti - popis";
        public const string str12e_InsuranceType_ProffesionalLiabilityInsuranceDescription = "Positenie profesionálnej odpovednosti - popis";
        #endregion
        

        public int Id { get; set; }
        public int UserId { get; set; }

        [Display(Name = str101_Insurance_DisplayInsuranceType)]        
        public EInsuranceType InsuranceType { get; set; }

        [Display(Name = str102_Insurance_DisplayAmmount)]
        [Required(ErrorMessage = str01_errInsurance_InputAmount)]
        [Range(1, int.MaxValue, ErrorMessage = str05_errInsurance_AmountIsTooLow)]
        public int Amount { get; set; }

        [Display(Name = str103_Insurance_DisplaySubject)]
        [Required(ErrorMessage = str02_errInsurance_InputSubject)]
        public string Subject { get; set; } = string.Empty;

        [Display(Name = str104_Insurance_DisplayValidFrom)]
        [Required(ErrorMessage = str03_errInsurance_InputValidFrom)]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }
        [Display(Name = str105_Insurance_DisplayValidTo)]
        [Required(ErrorMessage = str04_errInsurance_InputValidTo)]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }


        public override string ToString()
        {
            string returnString = "";
            switch (InsuranceType)
            {
                case EInsuranceType.PersonalInsurance: returnString = str01e_InsuranceType_PersonalInsurance; break;
                case EInsuranceType.LifeInsurance: returnString = str02e_InsuranceType_LifeInsurance; break;
                case EInsuranceType.TravelInsurance: returnString = str03e_InsuranceType_TravelInsurance; break;
                case EInsuranceType.AccidentInsurance: returnString = str04e_InsuranceType_AccidentInsurance; break;
                case EInsuranceType.HealthInsurance: returnString = str05e_InsuranceType_HealthInsurance; break;
                case EInsuranceType.PropertyInsurance: returnString = str06e_InsuranceType_PropertyInsurance; break;
                case EInsuranceType.NaturalDisasterInsurance: returnString = str07e_InsuranceType_NaturalDisasterInsurance; break;
                case EInsuranceType.TechnicalInsurance: returnString = str08e_InsuranceType_TechnicalInsurance; break;
                case EInsuranceType.CarInsurance: returnString = str09e_InsuranceType_CarInsurance; break;
                case EInsuranceType.BusinessInsurance: returnString = str10e_InsuranceType_BusinessInsurance; break;
                case EInsuranceType.LiabilityInsurance: returnString = str11e_InsuranceTypeLiabilityInsurance; break;
                case EInsuranceType.ProffesionalLiabilityInsurance: returnString = str12e_InsuranceType_ProffesionalLiabilityInsurance; break;
                default: returnString = "ERR - wrong EInsuranceType!!!"; break;
            }
            return returnString;
        }



    }
}
