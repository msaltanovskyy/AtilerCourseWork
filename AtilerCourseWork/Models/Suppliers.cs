using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "sunppliers")]
    public class Suppliers
    {
        public int SuppliersId { get; set; }

        [Required(ErrorMessage = ("Укажите название компании"))]
        [StringLength(50, ErrorMessage = "Длина строки не более 50")]
        [Display(Name = "Название поставщика")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = ("Укажите номер телефона"))]
        [StringLength(13, ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = ("Адресс"))]
        [StringLength(100, ErrorMessage = "Длина строки не более 100")]
        [Display(Name = "Адресс")]
        public string Adress { get; set; }
        public List<Invoice> invoices { get; set; }
    }
}
