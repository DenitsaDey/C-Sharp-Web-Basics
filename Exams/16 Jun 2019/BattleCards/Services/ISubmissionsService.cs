<<<<<<< HEAD
﻿namespace SulsApp.Services
{
    public interface ISubmissionsService
    {
    }
=======
﻿namespace SulsApp.Services
{
    public interface ISubmissionsService
    {
        void Create(string problemId, string userId, string code);

        void Delete(string id);
    }
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
}