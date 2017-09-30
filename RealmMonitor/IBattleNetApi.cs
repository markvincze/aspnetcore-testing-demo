using System.Collections.Generic;
using System.Threading.Tasks;
using RealmMonitor.Models;

namespace RealmMonitor
{
    public interface IBattleNetApi
    {
        Task<IEnumerable<Realm>> GetRealms();
    }
}