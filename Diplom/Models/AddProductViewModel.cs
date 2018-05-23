using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class AddProductViewModel
    {
        [Display(Name = "Тип")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Состояние")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Оплата")]
        public string Payment { get; set; }

        [Display(Name = "Доставка")]
        public string Delivery { get; set; }

        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
    }
}