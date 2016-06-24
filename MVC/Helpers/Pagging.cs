using System;
using System.Web.Mvc;
using MVC.Models.Pagging;
using System.Text;

namespace MVC.Helpers
{
    public static class Pagging
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfoModel pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                
                tag.AddCssClass(i == pageInfo.PageNumber ? "btn btn-primary selected" : "btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}