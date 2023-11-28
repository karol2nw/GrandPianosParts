using GrandPianosParts.Data.Entities;
using GrandPianosParts.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts.Services
{
    public class EventHandler : IEventHandler
    {
        private IRepository<Hammer> _hammerRepository;
        private readonly IRepository<Schank> _schankRepository;
        private readonly IRepository<DamperFilz> _damperRepository;

        public EventHandler(IRepository<Hammer> hammerRepository,
            IRepository<Schank> schankRepository,
            IRepository<DamperFilz> damperRepository)
        {
            _hammerRepository = hammerRepository;
            _schankRepository = schankRepository;
            _damperRepository = damperRepository;
        }

        const string auditFile = "Audit.txt";

        public void Subscribe()
        {
            _hammerRepository.ItemAdded += ItemAdded;
            _damperRepository.ItemAdded += ItemAdded;
            _schankRepository.ItemAdded += ItemAdded;

            _hammerRepository.ItemRemoved += ItemRemoved;
            _schankRepository.ItemRemoved += ItemRemoved;
            _damperRepository.ItemRemoved += ItemRemoved;

            _hammerRepository.ItemSaved += ItemSaved;
            _schankRepository.ItemSaved += ItemSaved;
            _damperRepository.ItemSaved += ItemSaved;
        }

        public void ItemAdded(object sender, IEntity item)
        {
            Console.WriteLine();
            Console.WriteLine($"{item.PartName} id: {item.Id} added");
            using (var writer = File.AppendText(auditFile))
            {
                writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} added");
            }
        }
        public void ItemRemoved(object sender, IEntity item)
        {
            Console.WriteLine();
            Console.WriteLine($"{item.PartName} id: {item.Id} removed");
            using (var writer = File.AppendText(auditFile))
            {
                writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} removed");
            }
        }
        public void ItemSaved(object sender, IEntity item)
        {
            Console.WriteLine();
            Console.WriteLine($"{item.PartName} id: {item.Id} saved");
            using (var writer = File.AppendText(auditFile))
            {
                writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} saved");
            }
        }
    }
}
