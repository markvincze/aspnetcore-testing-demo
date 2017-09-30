using System.Threading.Tasks;
using System.Collections.Generic;
using RealmMonitor.Models;

namespace RealmMonitor
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alert>> List();

        Task InsertAlert(Alert alert);
    }
}