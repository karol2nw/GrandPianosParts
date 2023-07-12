using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts.Services
{
    public class EventHandler : IEventHandler
    {
        private IRepository<PianoParts> _pianoPartsRepository;
        public EventHandler(IRepository<PianoParts> pianoPartsRepository)
        {
            _pianoPartsRepository = pianoPartsRepository;
        }

        const string auditFile = "Audit.txt";

        public void Subscribe()
        {
            _pianoPartsRepository.ItemAdded += ItemAdded;
            _pianoPartsRepository.ItemRemoved += ItemRemoved;
            _pianoPartsRepository.ItemSaved += ItemSaved;
        }

        public void ItemAdded(object sender, PianoParts item)
        {
            Console.WriteLine($"{item.PartName} id: {item.Id} added");
            using (var writer = File.AppendText(auditFile))
            {
                writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} added");
            }
        }
        public void ItemRemoved(object sender, PianoParts item)
        {
            Console.WriteLine($"{item.PartName} id: {item.Id} removed");
            using (var writer = File.AppendText(auditFile))
            {
                writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} removed");
            }
        }
        public void ItemSaved(object sender, PianoParts item)
        {
            Console.WriteLine($"{item.PartName} id: {item.Id} saved");
            using (var writer = File.AppendText(auditFile))
            {
                writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} saved");
            }
        }
    }
}
