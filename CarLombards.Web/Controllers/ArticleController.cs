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

    public ArticleController(IPagesService pages)
    {
        _pages = pages;
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
                PageView = pages.PageView
            };


        model.MainMenuItems = await _pages.GetMainMenu();
        model.ReadMoreList = await _pages.GetReadMore();
        model.ImportantArticleItems = await _pages.GetImportant();
        model.ListArticles = await _pages.GetArticles();
        model.PageTable = GetTable(pages.PageTable);
        model.SetTheme();

        return View(model.PageView, model);
    }

    public Task<IActionResult> Index()
    {
        return Process("Index");
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
}