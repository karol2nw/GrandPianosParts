using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using System.Reflection.Metadata;

namespace GrandPianosParts.DataProviders
{
    public class PartsProvider : IPartsProvider
    {

        private readonly IRepository<Hammer> _hammerRepository;
        private readonly IRepository<Schank> _schankRepository;
        private readonly IRepository<DamperFilz> _damperRepository;


        public PartsProvider
            (IRepository<Hammer> hammerRepository,
            IRepository<Schank> schankRepository,
            IRepository<DamperFilz> DamperRepository)

        {
            _hammerRepository = hammerRepository;
            _schankRepository = schankRepository;
            _damperRepository = DamperRepository;
        }



        public List<Hammer> OrderHammersByName()
        {
            var parts = _hammerRepository.GetAll();
            return parts.OrderBy(x => x.PartName).ToList();
        }
        public List<Schank> OrderSchanksByName()
        {
            var parts = _schankRepository.GetAll();
            return parts.OrderBy(x => x.PartName).ToList();
        }
        public List<DamperFilz> OrderDampersByName()
        {
            var parts = _damperRepository.GetAll();
            return parts.OrderBy(x => x.PartName).ToList();
        }

        public List<Hammer> ShowAllHammers()
        {
            return _hammerRepository.GetAll().ToList();
        }
        public List<Schank> ShowAllSchanks()
        {
            return _schankRepository.GetAll().ToList();
        }
        public List<DamperFilz> ShowAllDampers()
        {
            return _damperRepository.GetAll().ToList();
        }

        public List<string> ShowAllHammerNumbers()
        {
            var hammers = _hammerRepository.GetAll();
            return hammers.Select(x => x.PartNumber).ToList();
        }
        public List<string> ShowAllSchanksNumbers()
        {
            var schanks = _schankRepository.GetAll();
            return schanks.Select(x => x.PartNumber).ToList();
        }
        public List<string> ShowAllDampersNumbers()
        {
            var dampers = _damperRepository.GetAll();
            return dampers.Select(x => x.PartNumber).ToList();
        }

        public List<string> ShowAllHammersName()
        {
            var hammers = _hammerRepository.GetAll();
            return hammers.Select(x => x.PartName).ToList();
        }
        public List<string> ShowAllSchanksName()
        {
            var schanks = _schankRepository.GetAll();
            return schanks.Select(x => x.PartName).ToList();
        }
        public List<string> ShowAllDampersName()
        {
            var dampers = _damperRepository.GetAll();
            return dampers.Select(x => x.PartName).ToList();
        }

        public List<string> ShowAllHammersNumber()
        {
            var hammers = _hammerRepository.GetAll();
            return hammers.Select(x => x.PartNumber).ToList();
        }
        public List<string> ShowAllSchanksNumber()
        {
            var schanks = _schankRepository.GetAll();
            return schanks.Select(x => x.PartNumber).ToList();
        }
        public List<string> ShowAllDampersNumber()
        {
            var dampers = _damperRepository.GetAll();
            return dampers.Select(x => x.PartNumber).ToList();
        }
        public List<Hammer> WhereHammerNumberIs(string number)
        {
            var hammers = _hammerRepository.GetAll();
            return hammers.Where(x => x.PartNumber == number).ToList();
        }
        public List<Schank> WhereSchankNumberIs(string number)
        {
            var schanks = _schankRepository.GetAll();
            return schanks.Where(x => x.PartNumber == number).ToList();
        } 
        public List<DamperFilz> WhereDamperNumberIs(string number)
        {
            var dampers = _damperRepository.GetAll();
            return dampers.Where(x => x.PartNumber == number).ToList();
        }
    }
}
