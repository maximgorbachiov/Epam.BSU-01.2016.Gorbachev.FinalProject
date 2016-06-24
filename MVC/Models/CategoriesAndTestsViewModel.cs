using System.Collections.Generic;
using MVC.Models.Shared;

namespace MVC.Models
{
    public class CategoriesAndTestsViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<TestViewModel> Tests { get; set; }
    }
}