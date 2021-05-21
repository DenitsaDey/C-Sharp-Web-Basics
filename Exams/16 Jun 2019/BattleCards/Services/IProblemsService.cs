using SulsApp.ViewModels.Problems;
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
}