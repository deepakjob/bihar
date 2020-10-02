using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPage.Models
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> AllMenu { get; }
    }
}
 