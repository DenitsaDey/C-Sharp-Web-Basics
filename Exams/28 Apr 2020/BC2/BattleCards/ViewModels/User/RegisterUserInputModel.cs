using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.ViewModels.User
{
    public class RegisterUserInputModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
