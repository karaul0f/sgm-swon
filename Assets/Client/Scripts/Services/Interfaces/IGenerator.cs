using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface IGenerator<TValue>
    {
        event EventHandler<TValue> Change;

        TValue Current { get; }

        void Next();
    }
}
