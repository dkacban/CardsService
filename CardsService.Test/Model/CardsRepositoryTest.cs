using Xunit;
using CardsService.Model;

namespace CardsService.Test.Model
{
    public class CardsRepositoryTest
    {
        [Fact]
        public void ShouldGetReadBacklogCardsFromGithubProject()
        {
            var repo = new CardsRepository();
            var cards = repo.GetBacklogCards();

            Assert.True(cards.Count > 0);
        }

        [Fact]
        public void ShouldGetReadToDoCardsFromGithubProject()
        {
            var repo = new CardsRepository();
            var cards = repo.GetToDoCards();

            Assert.True(cards.Count > 0);
        }

        [Fact]
        public void ShouldGetReadInProgressCardsFromGithubProject()
        {
            var repo = new CardsRepository();
            var cards = repo.GetInProgressCards();

            Assert.True(cards.Count > 0);
        }

        [Fact]
        public void ShouldGetReadDoneCardsFromGithubProject()
        {
            var repo = new CardsRepository();
            var cards = repo.GetDoneCards();

            Assert.True(cards.Count > 0);
        }

        [Fact]
        public void ShouldCheckPrerequirementsIfProjectExists()
        {
            var repo = new CardsRepository();
            var result = repo.ArePreRequirementsMet("Test");

            Assert.True(result);
        }

        [Fact]
        public void ShouldCheckPrerequirementsIfProjectNotExisting()
        {
            var repo = new CardsRepository();
            var result = repo.ArePreRequirementsMet("Test-error");

            Assert.False(result);
        }

        [Fact]
        public async void ShouldReplaceTextInCards()
        {
            var repo = new CardsRepository();
            await repo.ReplaceText("a", "z", CardsRepository.BacklogColumnId);
        }
    }
}
