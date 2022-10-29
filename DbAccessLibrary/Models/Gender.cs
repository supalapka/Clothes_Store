using System.ComponentModel.DataAnnotations;

namespace DbAccessLibrary.Models
{
    public enum Gender
    {
        [Display(Name = "Чоловічий одяг")]
        Male,
        [Display(Name = "Жіночий одяг")]
        Female,
    }
}