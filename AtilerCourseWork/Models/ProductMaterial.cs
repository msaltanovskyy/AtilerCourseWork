using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "material_for_product")] //матеріали для виробу
    public class ProductMaterial
    {
        public int Id { get; set; }
        [Display(Name = "Продукт")]
        public int ProductId { get; set; }
        public Product product { get; set; }
        [Display(Name = "Материал")]
        public int MaterialId { get; set; }
        public Material material { get; set; }
        [Display(Name = "Количество")]
        [Range(1,999, ErrorMessage = "Нарушение диапазона 1-999")]
        public int Quantity { get; set; }
    }
}
