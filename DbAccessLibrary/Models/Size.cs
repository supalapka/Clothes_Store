using System.ComponentModel.DataAnnotations;

namespace DbAccessLibrary.Models
{
    public enum Size
    {
        [Display(Name = "S")]
        S,
        [Display(Name = "M")]
        M,
        [Display(Name = "L")]
        L,
        [Display(Name = "XL")]
        XL,
        [Display(Name = "2XL")]
        XXL,
        [Display(Name = "3XL")]
        XXXL,
    }
}