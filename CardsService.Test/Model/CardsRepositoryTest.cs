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
    }
}
