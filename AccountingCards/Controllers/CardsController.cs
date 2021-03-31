using AccountingCards.Models;
using AccountingCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly AccountingViewModel _accounting = new AccountingViewModel();
        private readonly CardsService _cardsService;

        public CardsController(CardsService cardsService)
        {
            _cardsService = cardsService;
        }

        // GET
        public IActionResult Index()
        {
            _cardsService.CreateDefaultCard(_accounting.Cards);

            return View(_accounting);
        }
    }
}