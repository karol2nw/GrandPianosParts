using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts
{
    public class App : IApp
    {
        private readonly IUserCommunication _userCommunication;
        private readonly IEventHandler _eventHandler;

        public App(IUserCommunication userCommunication,
            IEventHandler eventHandler)
        {
            this._userCommunication = userCommunication;
            this._eventHandler = eventHandler;
        }

        public void Run()
        {
            Console.WriteLine("I'm into Run App()");
            _eventHandler.Subscribe();
            _userCommunication.Communication();
        }


    }
}
