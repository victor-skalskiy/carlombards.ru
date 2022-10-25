using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarLombards.Models;
using CarLombards.Interfaces;
using Newtonsoft.Json;
using CarLombards.Domain;

namespace CarLombards.Controllers;

public class ArticleController : Controller
{
    private readonly IPagesService _pages;
    private readonly IPagesOptions _pagesOptions;

    public ArticleController(IPagesService pages, IPagesOptions pagesOptions)
    {
        _pages = pages;
        _pagesOptions = pagesOptions;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<List<string>> GetTable(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        return JsonConvert.DeserializeObject<List<List<string>>>(raw);
    }

    private async Task<IActionResult> Process(string url, bool loadList = false)
    {
        if (url.Substring(0, 1) != "/")
            url = $"/{url}";

        var model = new PageItemModel() { PageView = "Article" };

        var pages = await _pages.GetByUrlAsync(url);

        if (pages.Id > 0)
            model = new PageItemModel
            {
                BodyContent = pages.BodyContent,
                ButtonsColor = pages.ButtonsColor,
                ButtonsShareView = pages.ButtonsShareView,
                HeadBackgroundColor = pages.HeadBackgroundColor,
                ImportantArticle = pages.ImportantArticle,
                ImportantArticleTitle = pages.ImportantArticleTitle,
                InReadMoreList = pages.InReadMoreList,
                IsArticle = pages.IsArticle,
                ListImageUrl = pages.ListImageUrl,
                ListTitle = pages.ListTitle,
                MainMenu = pages.MainMenu,
                MainMenuFooterDescription = pages.MainMenuFooterDescription,
                MainMenuOrder = pages.MainMenuOrder,
                MainMenuTitle = pages.MainMenuTitle,
                MetaKeywords = pages.MetaKeywords,
                PageDate = pages.PageDate,
                PageDescription = pages.PageDescription,
                PageH1 = pages.PageH1,
                PageScript = pages.PageScript,
                PageTable = GetTable(pages.PageTable),
                PageTableTitle = pages.PageTableTitle,
                PageTitle = pages.PageTitle,
                PageUrl = pages.PageUrl,
                RenderHeadTags = pages.RenderHeadTags,
                RenderHeadTagsCenter = pages.RenderHeadTagsCenter,
                RenderReadMore = pages.RenderReadMore,
                ThemeColor = (ThemeColor)Enum.Parse(typeof(ThemeColor), pages.ThemeColor),
                PageView = pages.PageView,
                PageTableContent = pages.PageTableContent,
                MetaDescription = pages.MetaDescription,
                SiteMapPriority = pages.SiteMapPriority,
                IsIsManualList = pages.IsManualList,
                ManualListTitle = pages.ManualListTitle
            };

        var tags = await _pages.GetTagsListAsync(HttpContext.RequestAborted);
        model.TagsBody = tags[_pagesOptions.TagsBodyEntityTitle].PageScript;
        model.TagsHeader = tags[_pagesOptions.TagsHeadEntityTitle].PageScript;
        model.MainMenuItems = await _pages.GetMainMenu(HttpContext.RequestAborted);
        model.ReadMoreList = await _pages.GetReadMore(HttpContext.RequestAborted);
        model.ImportantArticleItems = await _pages.GetImportant(HttpContext.RequestAborted);
        model.ListArticles = await _pages.GetArticles(HttpContext.RequestAborted);
        model.ListManualArticles = await _pages.GetManualArticles(HttpContext.RequestAborted);
        model.PageTable = GetTable(pages.PageTable);
        model.SetTheme();

        return View(model.PageView, model);
    }

    public Task<IActionResult> Index()
    {
        return Process("/");
    }

    [Route("articles/{page}")]
    public Task<IActionResult> Action(string page)
    {
        return Process($"articles/{page}");
    }

    [Route("{page}")]
    public Task<IActionResult> AnyPage(string page)
    {
        return Process(page);
    }

    [Route("robots.txt")]
    public async Task<FileStreamResult> RobotTxt()
    {
        var fileName = "robots.txt";

        var pages = await _pages.GetByUrlAsync(fileName);
        if (pages.Id < 1)
        {
            pages.BodyContent = @"User-agent: *
Disallow:
Host: https://carlombards.ru
Disallow: /crm/";
        }

        var fi = new FileInfo(fileName);
        using (StreamWriter writer = fi.CreateText())
        {
            writer.WriteLine(pages.BodyContent);
        }
        return File(fi.OpenRead(), "text/plain");
    }

    [Route("sitemap.xml")]
    public async Task<FileStreamResult> SitemapXml()
    {
        var fileName = "sitemap.xml";

        var content = await _pages.GetSitemapAsync(HttpContext.RequestAborted);
        if (content.Count < 1)
        {
            throw new HttpRequestException("File doesn't exist", null, System.Net.HttpStatusCode.NotFound);
        }

        var fi = new FileInfo(fileName);
        using (StreamWriter writer = fi.CreateText())
        {
            foreach (var row in content)
            {
                writer.WriteLine(row);
            }
        }
        return File(fi.OpenRead(), "text/plain");
    }
}