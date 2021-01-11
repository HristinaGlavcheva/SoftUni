using MySulsExam.Data;
using MySulsExam.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace MySulsExam.Services
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

        public IEnumerable<HomePageProblemsViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new HomePageProblemsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count
            }).ToList();
            return problems;
        }

        public string GetNameById(string id)
        {
            return this.db.Problems.FirstOrDefault(x => x.Id == id).Name;
        }

        public ProblemViewModel GetById(string id)
        {
            var problemViewModel = this.db.Problems.Where(p => p.Id == id)
                .Select(p => new ProblemViewModel
            {
                Name = p.Name,
                Submissions = p.Submissions.Select(s => new SubmissionViewModel
                {
                    SubmissionId = s.Id,
                    AchievedResult = s.AchievedResult,
                    CreatedOn = s.CreatedOn,
                    Username = s.User.Username,
                    MaxPoints = p.Points
                })
            }).FirstOrDefault();

            return problemViewModel;
        }
    }
}
