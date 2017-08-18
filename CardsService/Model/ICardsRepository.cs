using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardsService.Model
{
    public interface ICardsRepository
    {
        IReadOnlyList<ProjectCard> GetBacklogCards();
        IReadOnlyList<ProjectCard> GetToDoCards();
        IReadOnlyList<ProjectCard> GetInProgressCards();
        IReadOnlyList<ProjectCard> GetDoneCards();
        Task ReplaceText(string from, string to, int columnId);
    }
}
