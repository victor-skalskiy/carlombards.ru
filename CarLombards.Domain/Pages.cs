namespace CarLombards.Domain;

/// <summary>
/// Base BL representation (for crud operation)
/// </summary>
public class Pages
{
    public Pages() { }

    public long Id { get; set; }
    public string Title { get; set; }
    public string ListTitle { get; set; }
    public string ListImageUrl { get; set; }
    public string PageTitle { get; set; }
    public string PageH1 { get; set; }
    public string PageDescription { get; set; }
    public string PageDate { get; set; }
    public string PageUrl { get; set; }
    public string HeadBackgroundColor { get; set; }
    public bool RenderReadMore { get; set; }
    public bool RenderHeadTags { get; set; }
    public string RenderHeadTagsCenter { get; set; }
    public string ThemeColor { get; set; }
    public bool IsArticle { get; set; }
    public string BodyContent { get; set; }
    public bool InReadMoreList { get; set; }
    public string PageTable { get; set; }
    public string PageTableTitle { get; set; }
    public bool ButtonsShareView { get; set; }
    public string ButtonsColor { get; set; }
    public bool MainMenu { get; set; }
    public string MainMenuTitle { get; set; }
    public string MainMenuFooterDescription { get; set; }
    public int MainMenuOrder { get; set; }
    public bool ImportantArticle { get; set; }
    public string PageScript { get; set; }
    public string MetaKeywords { get; set; }
    public string ImportantArticleTitle { get; set; }
    public string PageView { get; set; }
}