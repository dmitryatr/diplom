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

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Состояние")]
        public string State { get; set; }

        [Display(Name = "Оплата")]
        public string Payment { get; set; }

        [Display(Name = "Доставка")]
        public string Delivery { get; set; }

        [Display(Name = "Дата обновления")]
        public DateTime DateUpdate { get; set; }

        public string City { get; set; }

        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
    }
}