using System.Collections.Generic;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface ILoader<TValue>
    {
        IEnumerable<TValue> Load();
    }
}
