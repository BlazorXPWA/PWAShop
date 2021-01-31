namespace ProPWAShop.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static ErrorMessages;
    using static Data.ModelConstants.Common;

    public class ChangeSettingsRequestModel
    {
        [Required]
        [StringLength(
            MaxNameLength,
            ErrorMessage = StringLengthErrorMessage,
            MinimumLength = MinNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(
            MaxNameLength,
            ErrorMessage = StringLengthErrorMessage,
            MinimumLength = MinNameLength)]
        public string LastName { get; set; }

        public int PhoneConfirmation { get; set; }

        public bool PhoneConfirmed { get; set; }

        public string Phone { get; set; }
    }
}