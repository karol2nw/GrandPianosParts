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

       
        List<Hammer> OrderHammersByName();
        List<Schank> OrderSchanksByName();
        List<DamperFilz> OrderDampersByName();

       
        List<Hammer> ShowAllHammers();
        List<Schank> ShowAllSchanks();
        List<DamperFilz> ShowAllDampers();

        List<string> ShowAllHammersName();
        List<string> ShowAllSchanksName();
        List<string> ShowAllDampersName();

        List<string> ShowAllHammersNumber();
        List<string> ShowAllSchanksNumber();
        List<string> ShowAllDampersNumber();

        public List<Hammer> WhereHammerNumberIs(string number);
        List<Schank> WhereSchankNumberIs(string number);
        List<DamperFilz> WhereDamperNumberIs(string number);


    }
}
