using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPage.Models
{
    public class MockMenuRepository: IMenuRepository
    {
        public IEnumerable<Menu> AllMenu =>
            new List<Menu>
            {
                new Menu{ report_Name= "Crop Coverage", report_Url= "https://app.powerbi.com/view?r=eyJrIjoiNDVjYjEwMTktMWZjMi00YTU4LTk0NDUtNWExNzNhYTU4ZDkyIiwidCI6ImYwMDU5NzBmLTFiODEtNDc1OS1hODBmLWU2ZDA0MDZiNTFlZSJ9" },
                new Menu{ report_Name= "Crop Damage", report_Url="https://app.powerbi.com/view?r=eyJrIjoiNzNkNDBjZjYtYTI4MS00MmFkLWI0YTAtZjFhZmNmMGViNGVjIiwidCI6ImYwMDU5NzBmLTFiODEtNDc1OS1hODBmLWU2ZDA0MDZiNTFlZSJ9"}
            };
    }
}
