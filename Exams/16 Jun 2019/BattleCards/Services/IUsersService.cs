<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string passowrd);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string email);
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string passowrd);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string email);
    }
}
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
