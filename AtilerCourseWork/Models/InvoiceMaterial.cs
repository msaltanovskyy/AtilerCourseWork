using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "invoice_expand_material")] //накладна витратні матеріали
    public class InvoiceMaterial
    {
        public int InvoiceMaterialId { get; set; }

        [Display(Name = "Накладна")]
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }
        [Display(Name = "Материал")]
        public int MaterialId { get; set; }
        public Material material { get; set; }
        [Display(Name = "Коло-во")]
        public int Quntity { get; set; }
        [Display(Name = "Цена")]
        public decimal Cost { get; set; }
    }
}
