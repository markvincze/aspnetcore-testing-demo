using System.Threading.Tasks;
using System.Collections.Generic;
using Demo1.Models;

namespace Demo1
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alert>> List();

        Task InsertAlert(Alert alert);
    }
}