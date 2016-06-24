using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Shared
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

        public int TestsCount { get; set; }
    }
}