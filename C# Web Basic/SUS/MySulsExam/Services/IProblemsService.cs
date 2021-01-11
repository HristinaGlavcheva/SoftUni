using MySulsExam.ViewModels.Problems;
using System.Collections.Generic;

namespace MySulsExam.Services
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        IEnumerable<HomePageProblemsViewModel> GetAll();

       string GetNameById(string name);

        ProblemViewModel GetById(string id);
    }
}
