using CarShop.ViewModels;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        void AddIssue(string description, string carId);
        bool CarIdIsValid(string carId);
        CarIssuesViewModel GetAll(string carId);

        bool UserCanFixIssue(string userId);

        void FixIssue(string issueId, string carId);
        void DeleteIssue(string issueId);
    }
}
