using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "expend_material")] //витратні матеріали
    public class Material
    {
        public int MaterialId { get; set; }
        [Display(Name = "Тип материала")]
        public string Type { get; set; }
        [Display(Name = "Описание материала")]
        public string Description { get; set; }

    }
}
