using System.ComponentModel.DataAnnotations;

namespace DbAccessLibrary.Models
{
    public enum TypesOfClothes
    {
        [Display(Name = "Футболка")]
        Tshirt,
        [Display(Name = "Світер")]
        Sweater,
        [Display(Name = "Худі")]
        Hoodies,
        [Display(Name = "Шорти")]
        Shorts,
        [Display(Name = "Спідниця")]
        Skirt,
        [Display(Name = "Джинси")]
        Jeans,
        [Display(Name = "Пальто")]
        Coat,
        [Display(Name = "Костюм")]
        Suit,
        [Display(Name = "Головний убір")]
        Cap,
        [Display(Name = "Шкарпетки")]
        Socks,
        [Display(Name = "Сорочка")]
        Shirt,
        [Display(Name = "Шарф")]
        Scarf,
        [Display(Name = "Рукавиці")]
        Gloves,
        [Display(Name = "Куртка")]
        Jacket,
        [Display(Name = "Сукня")]
        Dress,
        [Display(Name = "Взуття")]
        Shoes,
    }
}