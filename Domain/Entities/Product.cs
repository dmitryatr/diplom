using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        public string Type { get; set; }

        [Display(Name = "Исполнитель")]
        public string Name { get; set; }

        public int CategoryID { get; set; }

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

        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public string City { get; set; }

        public string ImagesName { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public Category Category { get; set; }
    }
}
