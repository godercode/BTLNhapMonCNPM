﻿using System.ComponentModel.DataAnnotations;

namespace BTLNhapMonCNPM.Models
{
    public class Beverage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đồ uống là bắt buộc.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ảnh đồ uống là bắt buộc.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc.")]
        [Range(10000, 100000, ErrorMessage = "Giá phải nằm trong khoảng từ 10000 đến 100000.")]
        public decimal Price { get; set; }
    }
}