using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week3Assignment.CustomHtmlHelper
{
    public static class CustomerHtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}