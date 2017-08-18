using Octokit;
using System.Collections.Generic;

namespace CardsService.Model
{
    public interface ICardsRepository
    {
        IReadOnlyList<ProjectCard> GetBacklogCards();
        IReadOnlyList<ProjectCard> GetToDoCards();
        IReadOnlyList<ProjectCard> GetInProgressCards();
        IReadOnlyList<ProjectCard> GetDoneCards();
    }
}
