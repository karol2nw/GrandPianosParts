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
    public class PartsProvider : IPartsProvider
    {

        private readonly IRepository<Hammer> _repository;

        public PartsProvider(IRepository<Hammer> hammerRepository,
            IRepository<Schank> shankRepository,
            IRepository<DamperFilz> DamperRepository)
        {

            this._repository = hammerRepository;
        }

        public List<PianoParts> OrderByProducer()
        {
            var parts = _repository.GetAll();
            return parts.OrderBy(x => x.Producer).ToList();
        }
        public List<PianoParts> OrderById()
        {
            var parts = _repository.GetAll();
            return parts.OrderBy(x => x.Id).ToList();
        }
        public List<PianoParts> OrderByName()
        {
            var parts = _repository.GetAll();
            return parts.OrderBy(x => x.PartName).ToList();
        }
        public List<PianoParts> WhereProdcerIs(char producer)
        {
            var parts = _repository.GetAll();
            return parts.Where(x => x.Producer == producer).ToList();
        }
        public List<PianoParts> WhereNumberIs(string number)
        {
            var parts = _repository.GetAll();
            return parts.Where(x => x.PartNumber == number).ToList();
        }
        public List<Hammer> ShowAllHammers()
        {
            var parts = _repository.GetAll();
            return parts.OfType<Hammer>().ToList();
        }
        public List<Schank> ShowAllSchanks()
        {
            var parts = _repository.GetAll();
            return parts.OfType<Schank>().ToList();
        }
        public List<DamperFilz> ShowAllDampers()
        {
            var parts = _repository.GetAll();
            return parts.OfType<DamperFilz>().ToList();
        }
        public List<string> ShowPartsNumbers()
        {
            var parts = _repository.GetAll();
            return parts.Select(x => x.PartNumber).ToList();
        }

        public List<string> ShowPartsNames()
        {
            var parts = _repository.GetAll();
            return parts.Select(x => x.PartName).ToList();
        }
        public List<char> ShowProducersDistinct()
        {
            var parts = _repository.GetAll();
            return parts.Select(x => x.Producer).Distinct().ToList();
        }

    }
}
