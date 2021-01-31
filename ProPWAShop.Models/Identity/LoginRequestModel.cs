namespace ProPWAShop.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstants.Identity;

    public class LoginRequestModel
    {
        [RegularExpression("^?([0-9]{7})$", ErrorMessage = "Введите корректный номер")]
        [Required(ErrorMessage = "Телефонный номер - обязателен")]
        //[DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [MinLength(MinPasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
