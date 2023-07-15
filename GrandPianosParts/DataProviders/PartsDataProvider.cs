using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts.DataProviders
{
    internal class PartsDataProvider : IPartsDataProvider
    {
        private readonly IUserCommunication _userCommunication;
        private readonly IRepository<PianoParts> _repository;

        public PartsDataProvider(IUserCommunication userCommunication,
            IRepository<PianoParts> repository) 
        {
            this._userCommunication = userCommunication;
            this._repository = repository;
        }
    }
}
