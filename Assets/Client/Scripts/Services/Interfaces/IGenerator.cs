using System;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface IGenerator<TValue>
    {
        event EventHandler<TValue> Change;

        TValue Current { get; }

        void Next();
    }
}
