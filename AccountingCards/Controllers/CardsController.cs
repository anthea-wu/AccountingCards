using AccountingCards.Models;
using AccountingCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingCards.Controllers
{
    public class Cards : Controller
    {
        private readonly AccountingViewModel _accounting = new AccountingViewModel();
        private readonly CardsService _cardsService;

        public Cards(CardsService cardsService)
        {
            _cardsService = cardsService;
        }

        // GET
        public IActionResult Index()
        {
            if (_accounting.Cards.Count == 0)
            {
                _cardsService.CreateDefaultCard(_accounting.Cards);
            }

            return View(_accounting);
        }
    }
}