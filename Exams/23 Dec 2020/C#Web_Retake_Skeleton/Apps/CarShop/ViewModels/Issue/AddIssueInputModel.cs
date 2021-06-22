using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels
{
    public class AddIssueInputModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsFixed { get; set; }
    }
}
