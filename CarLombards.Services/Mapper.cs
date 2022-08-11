using CarLombards.DAL;
using CarLombards.Domain;

public static class Mapper
{
    public static Pages FillPages(PagesEntity pagesEntity) =>
        new Pages
        {
            Title = pagesEntity.Title,
            Id = pagesEntity.Id,
            BodyContent = pagesEntity.BodyContent,
            ButtonsColor = pagesEntity.ButtonsColor,
            ButtonsShareView = pagesEntity.ButtonsShareView,
            HeadBackgroundColor = pagesEntity.HeadBackgroundColor,
            ImportantArticle = pagesEntity.ImportantArticle,
            InReadMoreList = pagesEntity.InReadMoreList,
            IsArticle = pagesEntity.IsArticle,
            ListImageUrl = pagesEntity.ListImageUrl,
            ListTitle = pagesEntity.ListTitle,
            MainMenu = pagesEntity.MainMenu,
            MainMenuFooterDescription = pagesEntity.MainMenuFooterDescription,
            MainMenuOrder = pagesEntity.MainMenuOrder,
            MainMenuTitle = pagesEntity.MainMenuTitle,
            PageDate = pagesEntity.PageDate,
            PageDescription = pagesEntity.PageDescription,
            PageH1 = pagesEntity.PageH1,
            PageScript = pagesEntity.PageScript,
            PageTable = pagesEntity.PageTable,
            PageTableTitle = pagesEntity.PageTableTitle,
            PageTitle = pagesEntity.PageTitle,
            PageUrl = pagesEntity.PageUrl,
            RenderHeadTags = pagesEntity.RenderHeadTags,
            RenderHeadTagsCenter = pagesEntity.RenderHeadTagsCenter,
            RenderReadMore = pagesEntity.RenderReadMore,
            ThemeColor = pagesEntity.ThemeColor,
            MetaKeywords = pagesEntity.MetaKeywords,
            ImportantArticleTitle = pagesEntity.ImportantArticleTitle,
            PageView = pagesEntity.PageView,
            MetaDescription = pagesEntity.MetaDescription,
            PageTableContent = pagesEntity.PageTableContent
        };
}