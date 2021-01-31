namespace ProPWAShop.Models.Cities
{
    using System.ComponentModel.DataAnnotations;

    public class CitiesRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
