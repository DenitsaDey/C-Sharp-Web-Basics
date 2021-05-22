<<<<<<< Updated upstream
<<<<<<< HEAD
﻿using System;
=======
﻿using SulsApp.Data;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsApp.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }
        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.db.Problems.Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();
            var submission = new Submission
            {
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                AchievedResult = this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
=======
﻿using SulsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsApp.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }
        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.db.Problems.Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();
            var submission = new Submission
            {
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                AchievedResult = this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
