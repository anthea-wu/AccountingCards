using System.Collections.Generic;

namespace AccountingCards.Models
{
    public class AccountingViewModel
    {
        public List<Card> Cards { get; set; }
        public List<Detail> Details { get; set; }

        public AccountingViewModel()
        {
            Cards = new List<Card>();
            Details = new List<Detail>();
        }
    }
}