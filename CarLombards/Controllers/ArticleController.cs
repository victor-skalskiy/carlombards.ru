using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarLombards.Models;
using Newtonsoft.Json;

namespace CarLombards.Controllers;

public class ArticleController : Controller
{
    private readonly ILogger<ArticleController> _logger;

    private List<PageItemModel> _mainMenuItems;
    public List<PageItemModel> MainMenuItems
    {
        get
        {
            if (_mainMenuItems is null)
                _mainMenuItems = GetContentItems()
                    .Where(x => x.MainMenu).OrderBy(o => o.MainMenuOrder).ToList();
            return _mainMenuItems;
        }
    }

    private List<PageItemModel> _readMoreItems;
    public List<PageItemModel> ReadMoreItems
    {
        get
        {
            if (_readMoreItems is null)
                _readMoreItems = GetContentItems().Where(x => x.InReadMoreList).ToList();
            return _readMoreItems;
        }
    }

    private List<PageItemModel> _importantArticleItems;
    public List<PageItemModel> ImportantArticleItems
    {
        get
        {
            if (_importantArticleItems is null)
                _importantArticleItems = GetContentItems().Where(x => x.ImportantArticle).ToList();
            return _importantArticleItems;
        }
    }

    private readonly string _soul;

    public ArticleController(ILogger<ArticleController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _soul = configuration.GetSection("Soul").Value;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public enum ThemeColor { Black, White, Yellow }

    private void SetTheme(ThemeColor color = ThemeColor.Black)
    {
        // ЛОГОТИП — LogoClass
        // logo__light — белый
        // logo__black — черный

        // ХЕДЕР — HeaderClass
        // blue-theme — белый
        // light-theme — черный

        // МЕНЮ пункт — MenuItemClass
        // lite__nav-item — белый
        // dark__nav-item - черный

        // Бургер — BurgerClass
        // lite__burger - белый
        // black__burger - черный

        // ТЭГИ — TagContainerClass
        // links — белый контейнер
        // tag__white — белый элемент

        // TagItemClass
        // articles-page__tags — черный контейнер
        // tag__black — черный элемент

        //H1 + Description — PageTitleBlockClass
        // section__white - белый
        // section__black — черный

        ViewBag.Soul = _soul;

        switch (color)
        {            
            case ThemeColor.White:
                ViewBag.LogoClass = "logo__light";
                ViewBag.HeaderClass = "blue-theme";
                ViewBag.MenuItemClass = "lite__nav-item";
                ViewBag.BurgerClass = "lite__burger";
                ViewBag.TagContainerClass = "links";
                ViewBag.TagItemClass = "tag__white";
                ViewBag.PageTitleBlockClass = "section__white";
                break;
            default:
                // Black
                ViewBag.LogoClass = "logo__black";
                ViewBag.HeaderClass = "light-theme";
                ViewBag.MenuItemClass = "dark__nav-item";
                ViewBag.BurgerClass = "black__burger";
                ViewBag.TagContainerClass = "articles-page__tags";
                ViewBag.TagItemClass = "tag__black";
                ViewBag.PageTitleBlockClass = "section__black";
                break;
        }

    }

    private List<PageItemModel> GetContentItems()
    {
        List<PageItemModel> items = new List<PageItemModel>();
        using (StreamReader r = new StreamReader("ContentData.json"))
        {
            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<List<PageItemModel>>(json);
        }
        return items;
    }

    private PageItemModel GetPageItem(string url)
    {
        if (url.Substring(0, 1) != "/")
            url = $"/{url}";

        var finded = GetContentItems()
            .Where(x => x.PageUrl.ToLower() == url.ToLower()).FirstOrDefault();

        if (finded is null)
            finded = new PageItemModel();

        finded.MainMenuItems = MainMenuItems;
        finded.ReadMoreList = ReadMoreItems;
        finded.ImportantArticleItems = ImportantArticleItems;

        return finded;
    }

    public IActionResult Index()
    {
        var page = GetPageItem("index");
        SetTheme(page.ThemeColor);

        return View("Index", page);
    }

    [Route("articles")]
    public IActionResult List()
    {
        var page = GetPageItem("articles");
        SetTheme(page.ThemeColor);
        page.List = GetContentItems().Where(x => x.IsArticle).ToList();

        return View("List", page);
    }

    [Route("contact")]
    public IActionResult Contact()
    {
        var page = GetPageItem("contact");
        SetTheme(page.ThemeColor);

        return View("Form", page);
    }

    [Route("request-access")]
    public IActionResult GetAccess()
    {
        var page = GetPageItem("request-access");
        SetTheme(page.ThemeColor);

        return View("Form", page);
    }

    [Route("analytics")]
    public IActionResult Analytics()
    {
        var page = GetPageItem("analytics");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("finance-simulation")]
    public IActionResult Simulation()
    {
        var page = GetPageItem("finance-simulation");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("privacy")]
    public IActionResult Privacy()
    {
        var page = GetPageItem("privacy");
        SetTheme(page.ThemeColor);

        return View("Simple", page);
    }

    [Route("articles/svodnaya-tablitsa-shem-avtolombardov")]
    public IActionResult Scheme()
    {
        var page = GetPageItem("articles/svodnaya-tablitsa-shem-avtolombardov");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/kakie-nuzhni-sotrudniki-v-avtolombard")]
    public IActionResult Staff()
    {
        var page = GetPageItem("articles/kakie-nuzhni-sotrudniki-v-avtolombard");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/oshibki-pri-otkrytii-avtolombarda")]
    public IActionResult OpenedErrors()
    {
        var page = GetPageItem("articles/oshibki-pri-otkrytii-avtolombarda");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/finansovye-pokazateli-po-periodam")]
    public IActionResult FinCounters()
    {
        var page = GetPageItem("articles/finansovye-pokazateli-po-periodam");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/pomosch-pri-otkrytii-lombarda")]
    public IActionResult Help()
    {
        var page = GetPageItem("articles/pomosch-pri-otkrytii-lombarda");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/primery-paketov-dokumentov")]
    public IActionResult DocsExample()
    {
        var page = GetPageItem("articles/primery-paketov-dokumentov");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/voprosi-i-otvety")]
    public IActionResult FAQ()
    {
        var page = GetPageItem("articles/voprosi-i-otvety");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("community")]
    public IActionResult Community()
    {
        var page = GetPageItem("community");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("about")]
    public IActionResult About()
    {
        var page = GetPageItem("about");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }

    [Route("articles/otchetnost-i-nadzornye-organy")]
    public IActionResult Reports()
    {
        var page = GetPageItem("articles/otchetnost-i-nadzornye-organy");
        SetTheme(page.ThemeColor);

        return View("Article", page);
    }
}