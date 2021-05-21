using SulsApp.Data;
using SulsApp.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsApp.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new HomePageProblemViewModel
            {
                id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            })
                .ToList();

            return problems;
        }

        public ProblemViewModel GetById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points
                    }).ToList()
                })
                .FirstOrDefault();

        }

        public string GetNameById(string id)
        {
            var name = this.db.Problems.FirstOrDefault(p => p.Id == id)?.Name;
            //this.db.Problems.Where(p=> p.Id == id).Select(p=>p.Name).FirstOrDefault();
            return name;
        }
    }
}
