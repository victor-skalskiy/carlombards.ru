using CarLombards.Domain;
using CarLombards.Interfaces;
using CarLombards.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CarLombards.Services;

public class PagesService : IPagesService
{
    private readonly PagesContext _context;
    private readonly IPagesOptions _pagesOptions;

    public PagesService(PagesContext context, IPagesOptions pagesOptions)
    {
        _context = context;
        _pagesOptions = pagesOptions;
    }

    public async Task<List<Pages>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.PagesEntities.Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<Pages> GetAsync(long id, CancellationToken token = default)
    {
        var finded = await _context.PagesEntities.Where(x => x.IsActive && x.Id == id).FirstOrDefaultAsync();

        if (finded is null)
            return new Pages() { };

        return Mapper.FillPages(finded);
    }

    public async Task<Pages> GetByUrlAsync(string url, CancellationToken token = default)
    {
        var finded = await _context.PagesEntities.Where(x => x.PageUrl.ToLower() == url.ToLower()).FirstOrDefaultAsync();

        if (finded is null)
            return new Pages() { };

        return Mapper.FillPages(finded);
    }

    public async Task<List<Pages>> GetListAsync(CancellationToken token = default)
    {
        return await _context.PagesEntities.Where(x => x.IsActive)
            .OrderBy(o => o.Id).Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<List<Pages>> GetImportant(CancellationToken token = default)
    {
        return await _context.PagesEntities.Where(x => x.IsActive && x.ImportantArticle)
            .Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<List<Pages>> GetReadMore(CancellationToken token = default)
    {
        return await _context.PagesEntities.Where(x => x.IsActive && x.InReadMoreList)
            .Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<List<Pages>> GetMainMenu(CancellationToken token = default)
    {
        return await _context.PagesEntities.Where(x => x.IsActive && x.MainMenu)
            .OrderBy(o => o.MainMenuOrder).Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<List<Pages>> GetArticles(CancellationToken token = default)
    {
        return await _context.PagesEntities.Where(x => x.IsActive && x.IsArticle && !x.IsManualList)
            .Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<List<Pages>> GetManualArticles(CancellationToken token = default)
    {
        return await _context.PagesEntities.Where(x => x.IsActive && x.IsArticle && x.IsManualList)
            .OrderBy(o => o.ManualListOrder)
            .Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<Pages> CreateAsync(string listTitle, string listImageUrl, string pageTitle, string pageH1, string pageDescription,
        string pageDate, string pageUrl, string headBackgroundColor, bool renderReadMore, bool renderHeadTags, string renderHeadTagsCenter,
        string themeColor, bool isArticle, string bodyContent, bool inReadMoreList, string pageTable, string pageTableTitle,
        bool buttonsShareView, string buttonsColor, bool mainMenu, string mainMenuTitle, string mainMenuFooterDescription,
        int mainMenuOrder, bool importantArticle, string pageScript, string metaKeywords, string importantArticleTitle,
        string title, string pageView, string metaDescription, string pageTableContent, string siteMapPriority,
        bool isManualList, string manualListTitle, int manualListOrder, CancellationToken token = default)
    {
        var created = new PagesEntity()
        {
            Title = title,
            ListTitle = listTitle,
            ListImageUrl = listImageUrl,
            PageTitle = pageTitle,
            PageH1 = pageH1,
            PageDescription = pageDescription,
            PageDate = pageDate,
            PageUrl = pageUrl,
            HeadBackgroundColor = headBackgroundColor,
            RenderReadMore = renderReadMore,
            RenderHeadTags = renderHeadTags,
            RenderHeadTagsCenter = renderHeadTagsCenter,
            ThemeColor = themeColor,
            IsArticle = isArticle,
            BodyContent = bodyContent,
            InReadMoreList = inReadMoreList,
            PageTable = pageTable,
            PageTableTitle = pageTableTitle,
            ButtonsShareView = buttonsShareView,
            ButtonsColor = buttonsColor,
            MainMenu = mainMenu,
            MainMenuTitle = mainMenuTitle,
            MainMenuFooterDescription = mainMenuFooterDescription,
            MainMenuOrder = mainMenuOrder,
            ImportantArticle = importantArticle,
            PageScript = pageScript,
            MetaKeywords = metaKeywords,
            ImportantArticleTitle = importantArticleTitle,
            PageView = pageView,
            IsActive = true,
            MetaDescription = metaDescription,
            PageTableContent = pageTableContent,
            SiteMapPriority = siteMapPriority,
            IsManualList = isManualList,
            ManualListTitle = manualListTitle,
            ManualListOrder = manualListOrder
        };

        _context.PagesEntities.Add(created);
        await _context.SaveChangesAsync(token);

        return Mapper.FillPages(created);
    }

    public async Task<Pages> UpdateAsync(long id, string listTitle, string listImageUrl, string pageTitle, string pageH1,
        string pageDescription, string pageDate, string pageUrl, string headBackgroundColor, bool renderReadMore, bool renderHeadTags,
        string renderHeadTagsCenter, string themeColor, bool isArticle, string bodyContent, bool inReadMoreList, string pageTable,
        string pageTableTitle, bool buttonsShareView, string buttonsColor, bool mainMenu, string mainMenuTitle,
        string mainMenuFooterDescription, int mainMenuOrder, bool importantArticle, string pageScript, string metaKeywords,
        string importantArticleTitle, string title, string pageView, string metaDescription, string pageTableContent,
        string siteMapPriority, bool isManualList, string manualListTitle, int manualListOrder, CancellationToken token = default)
    {
        var finded = await _context.PagesEntities.Where(x => x.IsActive && x.Id == id).FirstOrDefaultAsync();
        if (finded is null)
            return new Pages();

        finded.Title = title;
        finded.ListTitle = listTitle;
        finded.ListImageUrl = listImageUrl;
        finded.PageTitle = pageTitle;
        finded.PageH1 = pageH1;
        finded.PageDescription = pageDescription;
        finded.PageDate = pageDate;
        finded.PageUrl = pageUrl;
        finded.HeadBackgroundColor = headBackgroundColor;
        finded.RenderReadMore = renderReadMore;
        finded.RenderHeadTags = renderHeadTags;
        finded.RenderHeadTagsCenter = renderHeadTagsCenter;
        finded.ThemeColor = themeColor;
        finded.IsArticle = isArticle;
        finded.BodyContent = bodyContent;
        finded.InReadMoreList = inReadMoreList;
        finded.PageTable = pageTable;
        finded.PageTableTitle = pageTableTitle;
        finded.ButtonsShareView = buttonsShareView;
        finded.ButtonsColor = buttonsColor;
        finded.MainMenu = mainMenu;
        finded.MainMenuTitle = mainMenuTitle;
        finded.MainMenuFooterDescription = mainMenuFooterDescription;
        finded.MainMenuOrder = mainMenuOrder;
        finded.ImportantArticle = importantArticle;
        finded.PageScript = pageScript;
        finded.ModifyDate = DateTime.UtcNow;
        finded.MetaKeywords = metaKeywords;
        finded.ImportantArticleTitle = importantArticleTitle;
        finded.PageView = pageView;
        finded.MetaDescription = metaDescription;
        finded.PageTableContent = pageTableContent;
        finded.SiteMapPriority = siteMapPriority;
        finded.IsManualList = isManualList;
        finded.ManualListTitle = manualListTitle;
        finded.ManualListOrder = manualListOrder;

        _context.PagesEntities.Update(finded);
        await _context.SaveChangesAsync(token);

        return Mapper.FillPages(finded);
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken token = default)
    {
        var finded = await _context.PagesEntities.Where(x => x.IsActive && x.Id == id).FirstOrDefaultAsync();
        if (finded is null)
            return false;

        finded.IsActive = false;
        _context.PagesEntities.Update(finded);
        await _context.SaveChangesAsync(token);

        return true;
    }

    public async Task<List<string>> GetSitemapAsync(CancellationToken token = default)
    {
        //TODO: refac this shit
        var result = new List<string>();

        var pages = await _context.PagesEntities
            .Where(x => !string.IsNullOrWhiteSpace(x.SiteMapPriority))
            .OrderBy(o => o.SiteMapPriority).ToListAsync();

        result.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        result.Add("<urlset xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd\">");
        foreach (var page in pages)
        {
            var urlpart = page.PageUrl.ToLower() == "/index" ? "/" : page.PageUrl;
            result.Add($"<url><loc>https://carlombards.ru{urlpart}</loc><lastmod>{page.ModifyDate:yyyy-MM-dd}</lastmod><priority>{page.SiteMapPriority}</priority></url>");
        }
        result.Add("</urlset>");

        return result;
    }

    private async Task<PagesEntity> CreateEmptyTagsEntity(string title)
    {
        var pages = new PagesEntity() { Title = title, PageUrl = title, PageView = _pagesOptions.EmptyEntityViewTitle };
        _context.PagesEntities.Add(pages);

        await _context.SaveChangesAsync();

        return pages;
    }

    public async Task<Dictionary<string, Pages>> GetTagsListAsync(CancellationToken token = default)
    {
        var result = new Dictionary<string, Pages>();

        var headTagsEntity = await _context.PagesEntities.Where(x => x.Title == _pagesOptions.TagsHeadEntityTitle).FirstOrDefaultAsync();
        if (headTagsEntity is null)
            headTagsEntity = await CreateEmptyTagsEntity(_pagesOptions.TagsHeadEntityTitle);
        result.Add(_pagesOptions.TagsHeadEntityTitle, Mapper.FillPages(headTagsEntity));

        var bodyTagsEntity = await _context.PagesEntities.Where(x => x.Title == _pagesOptions.TagsBodyEntityTitle).FirstOrDefaultAsync();
        if (bodyTagsEntity is null)
            bodyTagsEntity = await CreateEmptyTagsEntity(_pagesOptions.TagsBodyEntityTitle);
        result.Add(_pagesOptions.TagsBodyEntityTitle, Mapper.FillPages(bodyTagsEntity));

        return result;
    }
}