using System.ComponentModel.DataAnnotations;

namespace DbAccessLibrary.Models
{
    public enum TypesOfClothes
    {
        [Display(Name = "Головний убір")]
        Cap,
        [Display(Name = "Пальто")]
        Coat,
        [Display(Name = "Куртка")]
        Jacket,
        [Display(Name = "Кофта")]
        Sweater,
        [Display(Name = "Сорочка")]
        Shirt,
        [Display(Name = "Футболка")]

        Tshirt,
        [Display(Name = "Штани")]
        pants,
        [Display(Name = "Джинси")]
        Jeans,
        [Display(Name = "Шорти")]
        Shorts,
       
        [Display(Name = "Спідниця")]
        Skirt,
        [Display(Name = "Рукавиці")]
        Gloves,
        [Display(Name = "Шарф")]
        Scarf,
        [Display(Name = "Сукня")]
        Dress,
        [Display(Name = "Костюм")]
        Suit,
        [Display(Name = "Шкарпетки")]
        Socks,
        [Display(Name = "Взуття")]
        Shoes,
    }
}