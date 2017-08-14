using Octokit;
using System.Collections.Generic;

namespace CardsService.Model
{
    interface ICardsRepository
    {
        IReadOnlyList<ProjectCard> GetBacklogCards();
    }
}
