using CarLombards.Domain;
using Newtonsoft.Json;

namespace CarLombards;

public class PageItemModel
{
    public PageItemModel() { }

    public string MetaTitle => PageTitle;
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public string MetaApplicationName => "Как открыть Автоломбард?!";

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

    [JsonIgnore]
    public List<Pages> ReadMoreList { get; set; }

    public bool InReadMoreList { get; set; }
    public List<List<string>> PageTable { get; set; }
    public string PageTableTitle { get; set; }
    public string PageTableContent { get; set; }

    public string PageScript { get; set; }

    [JsonIgnore]
    public List<Pages> ListArticles { get; set; }

    public bool ButtonsShareView { get; set; }
    public string ButtonsColor { get; set; }

    public string GetUrl(string url, HttpContext context) => $"{Host(context)}{url}";
    public string Host(HttpContext context) => $"https://{context.Request.Host}";

    public string Url(HttpContext context) => $"{Host(context)}{context.Request.Path}";

    public bool MainMenu { get; set; }
    public string MainMenuTitle { get; set; }
    public long MainMenuOrder { get; set; }
    public string MainMenuFooterDescription { get; set; }
    [JsonIgnore]
    public List<Pages> MainMenuItems { get; set; }


    public bool ImportantArticle { get; set; }
    public string ImportantArticleTitle { get; set; }

    [JsonIgnore]
    public List<Pages> ImportantArticleItems { get; set; }

    public string PageView { get; set; }
    public string SiteMapPriority { get; set; }


    #region ВИЗУАЛКА
    /// <summary>
    /// ЛОГОТИП — LogoClass
    /// logo__light — белый
    /// logo__black — черный
    /// </summary>
    public string LogoClass { get; set; }

    /// <summary>
    /// ХЕДЕР
    /// blue-theme — белый
    /// light-theme — черный
    /// </summary>
    public string HeaderClass { get; set; }

    /// <summary>
    /// МЕНЮ пункт
    /// lite__nav-item — белый
    /// dark__nav-item - черный
    /// </summary>
    public string MenuItemClass { get; set; }

    /// <summary>
    /// Бургер
    /// lite__burger - белый
    /// black__burger - черный
    /// </summary>
    public string BurgerClass { get; set; }

    /// <summary>
    /// ТЭГИ (облако) контейнер
    /// links — белый контейнер
    /// tag__white — белый элемент
    /// </summary>
    public string TagContainerClass { get; set; }

    /// <summary>
    /// ТЭГИ (облако) элемент
    /// tag__black — черный элемент
    /// articles-page__tags — черный контейнер
    /// </summary>
    public string TagItemClass { get; set; }

    /// <summary>
    /// H1 + Description
    /// section__white - белый
    /// section__black — черный
    /// </summary>
    public string PageTitleBlockClass { get; set; }
    #endregion ВИЗУАЛКА

    public void SetTheme()
    {
        switch (ThemeColor)
        {
            case ThemeColor.White:
                LogoClass = "logo__light";
                HeaderClass = "blue-theme";
                MenuItemClass = "lite__nav-item";
                BurgerClass = "lite__burger";
                TagContainerClass = "links";
                TagItemClass = "tag__white";
                PageTitleBlockClass = "section__white";
                break;
            default:
                LogoClass = "logo__black";
                HeaderClass = "light-theme";
                MenuItemClass = "dark__nav-item";
                BurgerClass = "black__burger";
                TagContainerClass = "articles-page__tags";
                TagItemClass = "tag__black";
                PageTitleBlockClass = "section__black";
                break;
        }

    }
}

public enum ThemeColor { Black, White, Yellow }