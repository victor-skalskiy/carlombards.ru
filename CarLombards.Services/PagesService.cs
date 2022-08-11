using CarLombards.Domain;
using CarLombards.Interfaces;
using CarLombards.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarLombards.Services;

public class PagesService : IPagesService
{
    private readonly PagesContext _context;

    public PagesService(PagesContext context)
    {
        _context = context;
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
        return await _context.PagesEntities.Where(x => x.IsActive && x.IsArticle)
            .Select(z => Mapper.FillPages(z)).ToListAsync();
    }

    public async Task<Pages> CreateAsync(string listTitle, string listImageUrl, string pageTitle, string pageH1, string pageDescription,
        string pageDate, string pageUrl, string headBackgroundColor, bool renderReadMore, bool renderHeadTags, string renderHeadTagsCenter,
        string themeColor, bool isArticle, string bodyContent, bool inReadMoreList, string pageTable, string pageTableTitle,
        bool buttonsShareView, string buttonsColor, bool mainMenu, string mainMenuTitle, string mainMenuFooterDescription,
        int mainMenuOrder, bool importantArticle, string pageScript, string metaKeywords, string importantArticleTitle,
        string title, string pageView, CancellationToken token = default)
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
            IsActive = true
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
        string importantArticleTitle, string title, string pageView, CancellationToken token = default)
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
}