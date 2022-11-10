using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "order")]
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = ("Выберите клиента"))]
        [Display(Name = "Клиент")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Display(Name = "Продукт")]
        public int ProductId {get;set;}
        public Product Product { get; set; }

        [Required(ErrorMessage = ("Выбирете рабочего"))]
        [Display(Name = "Рабочий")]
        public string workerId { get; set; }
        public Worker worker { get; set; }

        [Display(Name = "Начало заказа")]
        public DateTime Start { get; set; } = DateTime.UtcNow;

        [UIHint("Boolean")]
        [Display(Name = "Состояние заказа")]
        public bool IsCompleted { get; set; } = false;

        public List<Fitting> fittings;
    }
}
