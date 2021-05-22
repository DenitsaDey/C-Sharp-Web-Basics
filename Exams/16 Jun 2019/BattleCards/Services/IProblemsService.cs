<<<<<<< Updated upstream
<<<<<<< HEAD
﻿namespace SulsApp.Services
=======
﻿using SulsApp.ViewModels.Problems;
using System.Collections;
using System.Collections.Generic;

namespace SulsApp.Services
>>>>>>> Stashed changes
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string id);

        ProblemViewModel GetById(string id);
    }
=======
﻿using SulsApp.ViewModels.Problems;
using System.Collections;
using System.Collections.Generic;

namespace SulsApp.Services
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string id);

        ProblemViewModel GetById(string id);
    }
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
}