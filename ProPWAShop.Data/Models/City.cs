using ProPWAShop.Data.Contracts;

namespace ProPWAShop.Data.Models
{
    public class City : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}