using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "expend_material_invoice")]
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Display(Name = "Поставщик")]
        public int SuppliersId { get; set; }
        public Suppliers suppliers { get; set; }
        [Display(Name = "Рабочий")]
        public int WorkerId { get; set; }
        public Worker worker { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
