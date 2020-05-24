using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DropdownProject.Models;
using DropdownProject.Models.Entity;

namespace DropdownProject.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public List<Models.Commen.Employee> GetEmployees()
        {
            List<Models.Commen.Employee> employees = new List<Models.Commen.Employee>();
            try
            {
                using (var dBContext = new database2Context())
                {
                    //GetEmployee
                    Models.Commen.Employee employee1;
                    foreach (var emp in dBContext.TblEmployee)
                    {
                        employee1 = new Models.Commen.Employee();
                        employee1.Id = emp.Id;
                        employee1.Name = emp.Name;
                        employee1.Department = emp.Department;
                        employees.Add(employee1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return employees;
        }



        public int SaveEmployee(Models.Commen.Employee EmployeeModel)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext = new database2Context())
                {
                    Models.Entity.TblEmployee employeeEntity;
                    //Add Employee
                    if (EmployeeModel.Id == 0)
                    {
                        employeeEntity = new TblEmployee();
                        employeeEntity.Name = EmployeeModel.Name;
                        employeeEntity.Department = EmployeeModel.Department;
                        dBContext.TblEmployee.Add(employeeEntity);
                    }
                    returnVal = dBContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;

        }


        //************************
        //Department
        //************************



        public List<Models.Commen.Department> GetDepartment()
        {
            List<Models.Commen.Department> departments = new List<Models.Commen.Department>();
            try
            {
                using (var dBContext = new database2Context())
                {
                    //GetDepartment
                    Models.Commen.Department department1;
                    foreach (var dept in dBContext.TblDepartment)
                    {
                        department1 = new Models.Commen.Department();
                        department1.DepartmentId = dept.DepartmentId;
                        department1.DepartmentName = dept.DepartmentName;
                        departments.Add(department1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return departments;

        }



    }
}
