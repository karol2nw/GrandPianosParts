using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts.Services.ServiceProviders
{
    public interface IUserCommunicationProvider
    {
        void AddItem(IRepository<PianoParts> repository);
        void WriteAll(IReadRepository<IEntity> repository);
        void RemoveItemById(IRepository<PianoParts> repository);
        void SortMenu();
        void OrderBy();
        void WherePart();
        void ShowOnlyKindParts();


    }
}
