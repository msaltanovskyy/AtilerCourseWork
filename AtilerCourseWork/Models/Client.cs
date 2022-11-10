using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "client")]
    public class Client
    {
        public int ClientId { get;set; }

        [Required(ErrorMessage =("Введите имя"))]
        [StringLength(20,ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Введите фамилию"))]
        [StringLength(20, ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = ("Введите отчество"))]
        [StringLength(20, ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Отечество")]
        public string Secondname { get; set; }

        [Required(ErrorMessage = ("Введите номер телефона"))]
        [Display(Name = "Номер телефона")]
        [StringLength(13, ErrorMessage = "Длина строки не более 20")]
        public string Phone { get; set; }

        [Required(ErrorMessage = ("Введите почту"))]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Display(Name = "Размеры")]
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public List<Order> orders { get; set; }
    }
}
