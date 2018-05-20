namespace CarDealerSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TestViewModel : IValidatableObject  // TAKA VALIDIRAM MODELA PO CUSTOM
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
         /* ili samo yield ili error list dobavqm i return errors .. po izbor
            var errors = new List<ValidationResult>(); 
            ValidationResult e modelstate-a
         */

            if (Username == "Nqkoisi" && StatusMessage == "alabala nica drun drun")
            {
                // ili yield ili error list dobavqm i return errors .. yield e mnogo po-burzo
                yield return new ValidationResult("Sorry but you wrong! For example!");
            }

            else if(IsEmailConfirmed == false)
            {
                yield return new ValidationResult("IsEmailConfirmed is false");
            }

          /*
            else if (Email == "greshen@abv.bg")
            {
                // ili samo yield ili error list dobavqm i return errors .. po izbor
                 errors.Add(new ValidationResult("IsEmailConfirmed is false"));
            }

             //ili yield ili error list dobavqm i return errors .. po izbor
             return errors;  */

        }
    }
}
