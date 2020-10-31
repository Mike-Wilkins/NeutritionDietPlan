using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        [DisplayName("Nutrition Information")]
        public string NutritionalInfo { get; set; }

        public int DietId { get; set; }

        public string DietType { get; set; }
    }
}
