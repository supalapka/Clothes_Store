using System.ComponentModel.DataAnnotations;

namespace DbAccessLibrary.Models
{
    public enum Colors
    {
        [Display(Name = "Чорний")]
        Black,
        [Display(Name = "Білий")]
        White,
        [Display(Name = "Червоний")]
        Red,
        [Display(Name = "Зелений")]
        Green,
        [Display(Name = "Синій")]
        Blue,
        [Display(Name = "Жовтий")]
        Yellow,
        [Display(Name = "Коричневий")]
        Brown,
        [Display(Name = "Фіолетовий")]
        Purple,
        [Display(Name = "Сірий")]
        Gray,
        [Display(Name = "Хакі")]
        Khaki,
        [Display(Name = "Оранжевий")]
        Orange,
        [Display(Name = "Рожевий")]
        Pink,
    };
}