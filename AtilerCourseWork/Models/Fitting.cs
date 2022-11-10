using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "fitting")]
    public class Fitting
    {
        public int FittingId { get; set; }
        [Display(Name = "Индитификатор заказа")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Display(Name = "Описание")]
        public string Discription { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
