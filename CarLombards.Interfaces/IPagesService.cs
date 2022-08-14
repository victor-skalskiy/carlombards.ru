using CarLombards.Domain;

namespace CarLombards.Interfaces;

public interface IPagesService
{
    public Task<Pages> GetAsync(long id, CancellationToken token = default);

    public Task<Pages> GetByUrlAsync(string url, CancellationToken token = default);

    public Task<List<Pages>> GetAllAsync(CancellationToken token = default);

    public Task<List<Pages>> GetListAsync(CancellationToken token = default);

    public Task<List<string>> GetSitemapAsync(CancellationToken token = default);

    public Task<Dictionary<string, Pages>> GetTagsListAsync(CancellationToken token = default);

    public Task<List<Pages>> GetImportant(CancellationToken token = default);

    public Task<List<Pages>> GetReadMore(CancellationToken token = default);

    public Task<List<Pages>> GetMainMenu(CancellationToken token = default);

    public Task<List<Pages>> GetArticles(CancellationToken token = default);

    public Task<Pages> CreateAsync(string listTitle, string listImageUrl, string pageTitle, string pageH1, string pageDescription,
        string pageDate, string pageUrl, string headBackgroundColor, bool renderReadMore, bool renderHeadTags, string renderHeadTagsCenter,
        string themeColor, bool isArticle, string bodyContent, bool inReadMoreList, string pageTable, string pageTableTitle,
        bool buttonsShareView, string buttonsColor, bool mainMenu, string mainMenuTitle, string mainMenuFooterDescription, int mainMenuOrder,
        bool importantArticle, string pageScript, string metaKeywords, string importantArticleTitle, string title, string pageView,
        string metaDescription, string pageTableContent, string siteMapPriority, CancellationToken token = default);

    public Task<Pages> UpdateAsync(long id, string listTitle, string listImageUrl, string pageTitle, string pageH1,
        string pageDescription, string pageDate, string pageUrl, string headBackgroundColor, bool renderReadMore, bool renderHeadTags,
        string renderHeadTagsCenter, string themeColor, bool isArticle, string bodyContent, bool inReadMoreList, string pageTable,
        string pageTableTitle, bool buttonsShareView, string buttonsColor, bool mainMenu, string mainMenuTitle,
        string mainMenuFooterDescription, int mainMenuOrder, bool importantArticle, string pageScript, string metaKeywords,
        string importantArticleTitle, string title, string pageView, string metaDescription, string pageTableContent,
        string siteMapPriority, CancellationToken token = default);

    public Task<bool> DeleteAsync(long id, CancellationToken token = default);
}