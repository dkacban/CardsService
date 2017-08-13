using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsService.Model
{
    interface ICardsRepository
    {
        IList<Card> GetAllCards();
    }
}
