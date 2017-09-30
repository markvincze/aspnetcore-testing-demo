using System.Collections.Generic;
using System.Threading.Tasks;
using Demo1.Models;

namespace Demo1
{
    public interface IBattleNetApi
    {
        Task<IEnumerable<Realm>> GetRealms();
    }
}