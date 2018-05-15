using System;
using System.Text;
using System.Web.Mvc;
using Diplom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            ul.AddCssClass("pagination-split");
            ul.AddCssClass("justify-content-center");
            if (pagingInfo.CurrentPage != 1 && pagingInfo.TotalPages != 0)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");
                a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
                TagBuilder span = new TagBuilder("span");
                span.InnerHtml = "«";
                a.InnerHtml += span.ToString();
                li.InnerHtml += a.ToString();
                ul.InnerHtml += li.ToString();
            }
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                if (i == pagingInfo.CurrentPage)
                {
                    li.AddCssClass("active");
                }
                TagBuilder tag = new TagBuilder("a");
                tag.AddCssClass("page-link");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                li.InnerHtml += tag.ToString();
                ul.InnerHtml += li.ToString();
            }
            if (pagingInfo.CurrentPage != pagingInfo.TotalPages && pagingInfo.TotalPages != 0)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");
                a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
                TagBuilder span = new TagBuilder("span");
                span.InnerHtml = "»";
                a.InnerHtml += span.ToString();
                li.InnerHtml += a.ToString();
                ul.InnerHtml += li.ToString();
            }
            result.Append(ul.ToString());
            return MvcHtmlString.Create(result.ToString());
        }
    }
}