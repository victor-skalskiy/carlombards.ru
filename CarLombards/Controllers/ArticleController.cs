using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarLombards.Models;

namespace CarLombards.Controllers;

public class ArticleController : Controller
{
    private readonly ILogger<ArticleController> _logger;

    public ArticleController(ILogger<ArticleController> logger)
    {
        _logger = logger;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index()
    {
        // _HeaderBlackPartial — хедер под черные элементы
        // _HeaderWhitePartial — белые элементы
        ViewBag.HeaderName = "_HeaderBlackPartial";
        ViewBag.ThemeColor = "Black";
        return View();
    }

    [Route("analytics")]
    public IActionResult Analytics()
    {
        ViewBag.HeaderName = "_HeaderBlackPartial";
        return View();
    }

    [Route("articles/finance-simulation")]
    public IActionResult Simulation()
    {
        // Black || White
        ViewBag.ThemeColor = "Black";
        ViewBag.HeaderName = "_HeaderWhitePartial";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("articles/svodnaya-tablitsa-shem-avtolombardov")]
    public IActionResult Scheme()
    {
        return View();
    }

    [Route("articles")]
    public IActionResult List()
    {
        return View();
    }

    

    [Route("articles/kakie-nuzhni-sotrudniki-v-avtolombard")]
    public IActionResult Staff()
    {
        return View();
    }

    [Route("articles/oshibki-pri-otkrytii-avtolombarda")]
    public IActionResult OpenedErrors()
    {
        return View();
    }

    [Route("articles/finansovye-pokazateli-po-periodam")]
    public IActionResult FinCounters()
    {
        return View();
    }

    [Route("articles/pomosch-pri-otkrytii-lombarda")]
    public IActionResult Help()
    {
        return View();
    }

    [Route("articles/primery-paketov-dokumentov")]
    public IActionResult DocsExample()
    {
        return View();
    }

    [Route("articles/voprosi-i-otvety")]
    public IActionResult FAQ()
    {
        return View();
    }

    [Route("articles/community-avtolombardov")]
    public IActionResult Community()
    {
        return View();
    }

    [Route("about")]
    public IActionResult About()
    {
        return View();
    }

    [Route("articles/otchetnost-i-nadzornye-organy")]
    public IActionResult Reports()
    {
        return View();
    }

}

