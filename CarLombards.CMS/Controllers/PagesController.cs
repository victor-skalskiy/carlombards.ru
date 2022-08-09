using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarLombards.Interfaces;
using Newtonsoft.Json;

namespace CarLombards.CMS;

public class PagesController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private readonly string _indexUrl;
    private readonly IPagesService _pages;

    public PagesController(IPagesService service)
    {
        _pages = service;
        _indexUrl = "/";
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(new IndexModel
        {
            PagesList = await _pages.GetListAsync(HttpContext.RequestAborted)
        });
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View(
            nameof(this.Create),
            new PagesEditModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(PagesEditModel model)
    {
        await _pages.CreateAsync(model.ListTitle, model.ListImageUrl, model.PageTitle, model.PageH1,
            model.PageDescription, model.PageDate, model.PageUrl, model.HeadBackgroundColor, model.RenderReadMore, model.RenderHeadTags,
            model.RenderHeadTagsCenter, model.ThemeColor, model.IsArticle, model.BodyContent, model.InReadMoreList, model.PageTable,
            model.PageTableTitle, model.ButtonsShareView, model.ButtonsColor, model.MainMenu, model.MainMenuTitle,
            model.MainMenuFooterDescription, model.MainMenuOrder, model.ImportantArticle, model.PageScript, model.MetaKeywords,
            model.ImportantArticleTitle, model.Title, model.PageView, HttpContext.RequestAborted);

        return Redirect(_indexUrl);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var pages = await _pages.GetAsync(id, HttpContext.RequestAborted);
        return View(
            nameof(this.Edit),
            new PagesEditModel()
            {
                Id = pages.Id,
                Title = pages.Title,
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
                PageTable = pages.PageTable,
                PageTableTitle = pages.PageTableTitle,
                PageTitle = pages.PageTitle,
                PageUrl = pages.PageUrl,
                RenderHeadTags = pages.RenderHeadTags,
                RenderHeadTagsCenter = pages.RenderHeadTagsCenter,
                RenderReadMore = pages.RenderReadMore,
                ThemeColor = pages.ThemeColor,
                PageView = pages.PageView
            });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, PagesEditModel model)
    {
        await _pages.UpdateAsync(id, model.ListTitle, model.ListImageUrl, model.PageTitle, model.PageH1,
            model.PageDescription, model.PageDate, model.PageUrl, model.HeadBackgroundColor, model.RenderReadMore, model.RenderHeadTags,
            model.RenderHeadTagsCenter, model.ThemeColor, model.IsArticle, model.BodyContent, model.InReadMoreList, model.PageTable,
            model.PageTableTitle, model.ButtonsShareView, model.ButtonsColor, model.MainMenu, model.MainMenuTitle,
            model.MainMenuFooterDescription, model.MainMenuOrder, model.ImportantArticle, model.PageScript, model.MetaKeywords,
            model.ImportantArticleTitle, model.Title, model.PageView, HttpContext.RequestAborted);

        return Redirect(_indexUrl);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long id)
    {
        await _pages.DeleteAsync(id, HttpContext.RequestAborted);

        return Redirect(_indexUrl);
    }

    [HttpGet]
    public async Task<IActionResult> Load()
    {
        List<PagesEditModel> items = new List<PagesEditModel>();
        using (StreamReader r = new StreamReader("ContentData.json"))
        {
            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<List<PagesEditModel>>(json);
        }

        foreach (var item in items)
        {
           await _pages.CreateAsync(item.ListTitle, item.ListImageUrl, item.PageTitle, item.PageH1,
            item.PageDescription, item.PageDate, item.PageUrl, item.HeadBackgroundColor, item.RenderReadMore, item.RenderHeadTags,
            item.RenderHeadTagsCenter, item.ThemeColor, item.IsArticle, item.BodyContent, item.InReadMoreList, item.PageTable,
            item.PageTableTitle, item.ButtonsShareView, item.ButtonsColor, item.MainMenu, item.MainMenuTitle,
            item.MainMenuFooterDescription, item.MainMenuOrder, item.ImportantArticle, item.PageScript, item.MetaKeywords,
            item.ImportantArticleTitle, item.ListTitle, item.PageView, HttpContext.RequestAborted);
        }

        return Redirect(_indexUrl);
    }
}