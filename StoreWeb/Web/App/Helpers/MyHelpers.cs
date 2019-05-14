namespace Store.Web.App.Helpers
{
    using Logic.ProductStore.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

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

       
    }
}
