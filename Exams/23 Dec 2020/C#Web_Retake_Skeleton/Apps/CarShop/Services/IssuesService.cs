using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;
        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddIssue(string description, string carId)
        {
            var newIssue = new Issue
            {
                Description = description,
                IsFixed = false,
                CarId = carId,
                Car = this.db.Cars.FirstOrDefault(c => c.Id == carId)
            };
            this.db.Issues.Add(newIssue);
            this.db.SaveChanges();
        }

        public bool CarIdIsValid(string carId)
        {
            return this.db.Cars.Any(c => c.Id == carId);
        }
        public CarIssuesViewModel GetAll(string carId)
        {
            //var allIssues = new List<IssueViewModel>();
            //var currentUser = this.db.Users.FirstOrDefault(u => u.Id == userId);

            //if (!currentUser.IsMechanic)
            //{

            //}
            var allIssues = this.db.Cars
            .Where(c => c.Id == carId)
            .Select(c => new CarIssuesViewModel
            {
                CarId = c.Id,
                Model = c.Model,
                Year = c.Year,
                Issues = c.Issues.Select(i => new IssueViewModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    IsItFixed = i.IsFixed ? "Yes" : "Not yet"
                })
               .ToList()
        })
            .FirstOrDefault();
            
            return allIssues;
        }

        public bool UserCanFixIssue(string userId)
        {
            return this.db.Users.Any(u => u.Id == userId && u.IsMechanic);
        }

        public void FixIssue(string issueId, string carId)
        {
            var currentCarIssue = this.db.Issues.Where(i => i.Id == issueId && i.CarId == carId).FirstOrDefault();
            currentCarIssue.IsFixed = true;
            db.SaveChanges();
        }

        public void DeleteIssue(string issueId)
        {
            var issue = this.db.Issues.Find(issueId);
            this.db.Issues.Remove(issue);
            this.db.SaveChanges();
        }
    }
}

