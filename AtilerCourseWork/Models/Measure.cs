using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "measure")]
    public class Measure
    {
        public int MeasureId { get; set; }
        [Display(Name = "Клиент")]
        public int ClientId {get;set;}
        public Client Client {get;set; }
        [Display(Name = "Рост")]
        public double Rost { get; set; }
        [Display(Name = "Обхват груди")]
        public double Grud { get; set; }
        [Display(Name = "Обхват талии")]
        public double Talia { get; set; }
        [Display(Name = "Обхват стегна")]
        public double Stegna { get; set; }
        [Display(Name = "Обхват стегно")]
        public double Stegno { get; set; }
        [Display(Name = "Обхват запастье")]
        public double Zapaiste { get; set; }
        [Display(Name = "Плечи")]
        public double Plecha { get; set; }
        [Display(Name = "Рукова")]
        public double Rukova { get; set; }
        [Display(Name = "Длина")]
        public double Dlina { get; set; }
        [Display(Name = "Длина борюк")]
        public double Dlina_Bruk { get; set; }
        [Display(Name = "Спина")]
        public double Spina { get; set; }
        [Display(Name = "Высота сидения")]
        public double Visota_Sidina { get; set; }

    }
}
