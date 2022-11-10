using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "worker")]
    public class Worker : IdentityUser
    {
        [Required(ErrorMessage = ("Введите имя"))]
        [StringLength(20, ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Имя рабочего")]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Введите фамилию"))]
        [StringLength(20, ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Фамилия рабочего")]
        public string Surname { get; set; }

        [Required(ErrorMessage = ("Введите отчество"))]
        [StringLength(20, ErrorMessage = "Длина строки не более 20")]
        [Display(Name = "Отчество рабочего")]
        public string Secondname { get; set; }

        [Required(ErrorMessage = ("Введите зарплату"))]
        [Display(Name = "Зарплата")]
        public double Salary { get; set; }

        [Required(ErrorMessage = ("Введите номер телефона"))]
        [Display(Name = "Номер телефона")]
        public string Phone {get; set; }

        [Required(ErrorMessage = ("Введите дату начала работы"))]
        [Display(Name = "Начало работы")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartWork { get; set; } = DateTime.UtcNow;

        public List<Order> Orders { get; set; }
        
        

    }
}
