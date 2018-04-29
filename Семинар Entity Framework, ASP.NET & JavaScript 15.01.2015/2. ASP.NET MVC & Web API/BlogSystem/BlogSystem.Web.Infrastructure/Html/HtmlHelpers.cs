namespace BlogSystem.Web.Infrastructure.Html
{
    using System.Web.Mvc;
    using HtmlTags;

    public static class HtmlHelpers
    {
        public static HtmlTag Submit(this HtmlHelper helper, string value)
        {
            return new HtmlTag("input")
                .Attr("type", "submit")
                .Attr("value", value);
        }
    }
}
