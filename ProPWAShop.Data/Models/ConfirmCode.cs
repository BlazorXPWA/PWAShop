namespace ProPWAShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    public class ConfirmCode : BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int MessageId { get; set; }
        public int Code { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ProPWAShopUser User { get; set; }

    }
}
