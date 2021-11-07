using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface IClientGenerator
    {
        event EventHandler<Person> ClientChange;

        Person CurrentClient { get; }

        void ChangeClient();
    }
}
