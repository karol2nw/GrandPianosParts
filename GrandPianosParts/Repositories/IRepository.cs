﻿

using GrandPianosParts.Entities;

namespace GrandPianosParts.Repositories
{
    internal interface IRepository<T> : IReadRepository<T> , IWriteRepository<T> where T : class , IEntity 
    {                  
    }
}
