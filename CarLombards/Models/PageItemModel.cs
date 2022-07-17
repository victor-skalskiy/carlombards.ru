using System;
using static CarLombards.Controllers.ArticleController;

namespace CarLombards
{
    public class PageItemModel
    {
        public PageItemModel() { }
        public string ListTitle { get; set; }
        public string PageTitle { get; set; }
        public string PageH1 { get; set; }
        public string PageDescription { get; set; }
        public string PageDate { get; set; }
        public string PageUrl { get; set; }
        public string ListImageUrl { get; set; }
        public string HeadBackgroundColor { get; set; }
        public bool RenderReadMore { get; set; }
        public bool RenderHeadTags { get; set; }
        public string RenderHeadTagsCenter { get; set; }
        public ThemeColor ThemeColor { get; set; }
        public bool IsArticle { get; set; }
        public string BodyContent { get; set; }
        public List<PageItemModel> ReadMoreList { get; set; }
        public bool InReadMoreList { get; set; }
        public List<List<string>> PageTable { get; set; }
        public string PageTableTitle { get; set; }
        public List<PageItemModel> List { get; set; }
        public bool ButtonsShareView { get; set; }
        public string ButtonsColor { get; set; }
        public string Url(HttpContext context) => $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";
    }
}

