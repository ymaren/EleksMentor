using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace StoreWeb.Helpers
{
    public static class  MyHelpers
    {
        public static MvcHtmlString CreateSubMenu(this HtmlHelper html, IEnumerable<UserCredentialViewModel> subMenuList, int? parentId)
        {
            var subitems = subMenuList.Where(d => d.ParentCredentialid == parentId).OrderBy(i => i.Order);
            if (subitems.Any())
            {
                TagBuilder ul = new TagBuilder("ul");
                foreach(var itemSub in subitems)
                {
                    TagBuilder li = new TagBuilder("li");
                    TagBuilder link = new TagBuilder("a");
                    link.MergeAttribute("href", itemSub.Url);
                    link.InnerHtml = itemSub.FullNameCredential;
                    li.InnerHtml = link.ToString();
                    ul.InnerHtml += li.ToString();
                }
                return new MvcHtmlString(ul.ToString());
            }
         return null;
        }

        //public static MvcHtmlString CreateSubCheckBox(this HtmlHelper html, IEnumerable<UsersRoleCredentialViewModel> subCheckList, int? parentId)
        //{
        //    var subitems = subCheckList.Where(d => d.ParentCredentialid == parentId).OrderBy(i => i.Order);
        //    if (subitems.Any())
        //    {
        //        TagBuilder ul = new TagBuilder("ul");
        //        ul.Attributes.Add("type", "none");
        //        foreach (var itemSub in subitems)
        //        {
        //            TagBuilder li = new TagBuilder("li");
        //            TagBuilder lable = new TagBuilder("label");
        //            TagBuilder input = new TagBuilder("input"); //.ToString(TagRenderMode.SelfClosing);
        //            input.Attributes.Add("type", "checkbox");                    
        //            lable.InnerHtml += input.ToString(TagRenderMode.SelfClosing);
        //            lable.InnerHtml += itemSub.FullNameCredential.Trim();
        //            li.InnerHtml += lable.ToString();
        //            ul.InnerHtml += li.ToString();
        //        }
        //        return new MvcHtmlString(ul.ToString());
        //    }
        //    return null;
        //}

        

    }
}
