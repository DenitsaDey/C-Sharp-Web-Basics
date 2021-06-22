using CarShop.ViewModels;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        void AddIssue(AddIssueInputModel input, string carId);
        bool CarIdIsValid(string carId);
        CarIssuesViewModel GetAll(string carId);
    }
}
