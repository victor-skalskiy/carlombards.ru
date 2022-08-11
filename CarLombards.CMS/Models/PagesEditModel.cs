using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarLombards.CMS;

public class PagesEditModel
{
    public PagesEditModel() { }

    public long Id { get; set; }

    [Display(Name = "Title"), Required]
    public string Title { get; set; }

    [Display(Name = "ListTitle")]
    public string ListTitle { get; set; }

    [Display(Name = "ListImageUrl")]
    public string ListImageUrl { get; set; }

    [Display(Name = "PageTitle")]
    public string PageTitle { get; set; }

    [Display(Name = "PageH1")]
    public string PageH1 { get; set; }

    [Display(Name = "PageDescription")]
    public string PageDescription { get; set; }

    [Display(Name = "PageDate")]
    public string PageDate { get; set; }

    [Display(Name = "PageUrl")]
    public string PageUrl { get; set; }

    [Display(Name = "HeadBackgroundColor")]
    public string HeadBackgroundColor { get; set; }

    [Display(Name = "RenderReadMore")]
    public bool RenderReadMore { get; set; }

    [Display(Name = "RenderHeadTags")]
    public bool RenderHeadTags { get; set; }

    [Display(Name = "RenderHeadTagsCenter")]
    public string RenderHeadTagsCenter { get; set; }

    [Display(Name = "ThemeColor")]
    public string ThemeColor { get; set; }

    [Display(Name = "IsArticle field")]
    public bool IsArticle { get; set; }

    [Display(Name = "BodyContent")]
    public string BodyContent { get; set; }

    [Display(Name = "InReadMoreList")]
    public bool InReadMoreList { get; set; }

    [Display(Name = "PageTable"), JsonIgnore]
    public string PageTable { get; set; }

    [Display(Name = "PageTableTitle")]
    public string PageTableTitle { get; set; }

    [Display(Name = "ButtonsShareView")]
    public bool ButtonsShareView { get; set; }

    [Display(Name = "ButtonsColor")]
    public string ButtonsColor { get; set; }

    [Display(Name = "MainMenu")]
    public bool MainMenu { get; set; }

    [Display(Name = "MainMenuTitle")]
    public string MainMenuTitle { get; set; }

    [Display(Name = "MainMenuFooterDescription")]
    public string MainMenuFooterDescription { get; set; }

    [Display(Name = "MainMenuOrder")]
    public int MainMenuOrder { get; set; }

    [Display(Name = "ImportantArticle")]
    public bool ImportantArticle { get; set; }

    [Display(Name = "PageScript")]
    public string PageScript { get; set; }

    [Display(Name = "MetaKeywords")]
    public string MetaKeywords { get; set; }

    [Display(Name = "ImportantArticleTitle")]
    public string ImportantArticleTitle { get; set; }

    [Display(Name = "PageView"), Required]
    public string PageView { get; set; }
}

