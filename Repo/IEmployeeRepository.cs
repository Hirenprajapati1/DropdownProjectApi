using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropdownProject.Repo
{
    public interface IEmployeeRepository
    {
        public List<Models.Commen.Employee> GetEmployees();
        public int SaveEmployee(Models.Commen.Employee EmployeeModel);
        public List<Models.Commen.Department> GetDepartment();
    }
}
