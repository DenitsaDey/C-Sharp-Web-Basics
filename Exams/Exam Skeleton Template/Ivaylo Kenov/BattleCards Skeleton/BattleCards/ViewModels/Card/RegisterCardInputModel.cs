using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.ViewModels.Card
{
    public class RegisterCardInputModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Keyword { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string Description { get; set; }
    }
}
