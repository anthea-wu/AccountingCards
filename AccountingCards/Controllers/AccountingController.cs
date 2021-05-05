using System;
using System.Collections.Generic;
using AccountingCards.Models;
using AccountingCards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountingCards.Controllers
{
    // Controller 只做他該做的事 (取得回傳資料) : 聚合
    public class AccountingController : Controller
    {
        private static readonly AccountingViewModel _accounting = new AccountingViewModel();
        private readonly CardsService _cardsService;
        private readonly ILogger<AccountingController> _logger;

        public AccountingController(CardsService cardsService, ILogger<AccountingController> logger)
        {
            _cardsService = cardsService;
            _logger = logger;
        }

        // GET
        [Route("[controller]")]
        public IActionResult Index()
        {
            _cardsService.CreateDefaultCard(_accounting.Cards);
            _cardsService.CreateDefaultDetails(_accounting);

            return View(_accounting);
        }

        [HttpGet]
        [Route("[controller]/Card/{name}")]
        public IActionResult ShowCardDetails(string name)
        {
            var currentAccounting = _cardsService.GetCurrentAccountingCard(_accounting, name);

            return View(currentAccounting);
        }
    }
}