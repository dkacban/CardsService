using System.Collections.Generic;

namespace CardsService.Model
{
    public interface IAuditRepository
    {
        IList<Audit> GetAll();
        IList<Audit> GetByCardId(int id);
        void Add(string details);
    }
}
