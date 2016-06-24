using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC.Models.Shared;
using MVC.Models.Client;

namespace MVC.Models.Pagging
{
    public class PageViewModel
    {
        public IEnumerable<TestViewModel> PageContent { get; set; }
        public List<PassedTestViewModel> PassedTests { get; set; }

        [Display(Name = "Name")]
        public string SearchingToken { get; set; }

        public PageInfoModel PageInfo { get; set; }
    }
}