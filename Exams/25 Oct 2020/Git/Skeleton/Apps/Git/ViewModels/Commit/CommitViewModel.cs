﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Commit
{
    public class CommitViewModel
    {
        public string Id { get; set; }
        public string Repository { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
