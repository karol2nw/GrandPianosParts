using GrandPianosParts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts.DataProviders
{
    public interface IPartsProvider
    {
        List<PianoParts> OrderByProducer();
        List<PianoParts> OrderById();
        List<PianoParts> OrderByName();
        List<PianoParts> WhereProdcerIs(char producer);
        List<PianoParts> WhereNumberIs(string number);
        IEnumerable<Hammer> ShowAllHammers();
        List<Schank> ShowAllSchanks();
        List<DamperFilz> ShowAllDampers();
        List<string> ShowPartsNumbers();
        List<string> ShowPartsNames();
        List<char> ShowProducersDistinct();

    }
}
