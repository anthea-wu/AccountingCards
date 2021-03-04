using System.Collections.Generic;

namespace AccountingCards.Models
{
    public class AccountingViewModel
    {
        public List<Card> Cards { get; set; }

        public AccountingViewModel()
        {
            Cards = new List<Card>();
        }
    }
}