using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DbAccessLibrary.Models
{
    public enum ClothingCategory
    {
        [Display(Name = "Без сезону")]
        Default,
        [Display(Name="Зимній одяг")]
        Winter,
        [Display(Name="Літній одяг")]
        Summer
    }
}
