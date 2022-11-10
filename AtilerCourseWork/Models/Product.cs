using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtilerCourseWork.Models
{
    [Table(name: "product")] // виріб
    public class Product
    {
        public int ProductId { get; set; }  
        [Display(Name = "Номер заказа")]
        public int OrderId { get; set; } 
        public Order Order { get; set; }
        [Display(Name = "Причина")]
        public string Reason { get; set; }
        [Display(Name = "Ремонт")]
        public bool IsRepair { get; set; } = false;
    }
}
