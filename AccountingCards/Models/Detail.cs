using System;

namespace AccountingCards.Models
{
    public class Detail
    {
        public int Order { get; set; }
        public string Info { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public Card Card { get; set; }
    }
}