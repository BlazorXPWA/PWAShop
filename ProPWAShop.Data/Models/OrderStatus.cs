namespace ProPWAShop.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum OrderStatus
    {
        [Display(Name = "Принят")]
        Accepted,
        [Display(Name = "Согласован")]
        Contacted,
        [Display(Name = "Formed")]
        Формируется,
        [Display(Name = "В пути")]
        OnWay,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Выполнен")]
        Done,
        [Display(Name = "Закрыт")]
        Closed,
        [Display(Name = "Отменен")]
        Canceled,
        [Display(Name = "Возврат")]
        Return,
    }
}
