﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.ViewModels.Card
{
    public class CardsAllViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Keyword { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
    }
}
