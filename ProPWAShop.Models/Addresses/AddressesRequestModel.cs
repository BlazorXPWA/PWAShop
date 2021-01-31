namespace ProPWAShop.Models.Addresses
{
    using ProPWAShop.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstants.Address;

    public class AddressesRequestModel
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public string Comments { get; set; }

        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}
