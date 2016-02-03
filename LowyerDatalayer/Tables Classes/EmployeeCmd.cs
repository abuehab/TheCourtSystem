using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;


namespace LowyerDatalayer.Tables_Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeCmd : DataBase
    {
        public bool NewEmployee(Employee employee)
        {
           
            DbContext.Employees.InsertOnSubmit(employee);
            DbContext.SubmitChanges();

            return true;
        }
        public bool EditEmployee(Employee emp, int xid)
        {
            emp.Id = xid;
            var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                                             db.Employees.Single(d => d.Id == i));
            var newEmp = q(DbContext, xid);
      
            newEmp.EmployeeName = emp.EmployeeName;
            newEmp.Address = emp.Address;
            newEmp.IdCard = emp.IdCard;
            newEmp.Phone = emp.Phone;
            newEmp.Email = emp.Email;
            newEmp.Mobile = emp.Mobile;
            newEmp.Salary = emp.Salary;
      
            DbContext.SubmitChanges();

            return true;
        }
        public List<Employee> AllEmplyees()
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db) => 
                      db.Employees.Where (c=> c.Status == "Active")
                  );
                var employees = q(DbContext).ToList();

                return employees;

            }
            catch (Exception)
            {
                return null;
            }
        }
       

        /// <summary>
        /// Get  One Employee By hIS  Name Use  this method check if existed or not 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Employee> ListEmplyee_ByName(string name)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db, string n) =>
                         db.Employees.Where(c => c.EmployeeName.Contains(n) && c.Status == "Active"));
                var employees = q(DbContext, name).ToList();

                return employees;

            }
            catch (Exception)
            {

                return null;
            }
        }
        public Employee GetEmployeeByName(string name)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db, string n) =>
                                     db.Employees.Where(c => c.EmployeeName == n && c.Status == "Active")
                                     );
                var employee = q(DbContext, name).Single();
                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Employee GetEmployeeById(int employeeid)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                       db.Employees.Where(c => c.Id == i));
                var employee = q(DbContext, employeeid).Single();
                return employee;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool RemoveEmployee(Employee emp, int xid)
        {
            emp.Id = xid;
            var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                     db.Employees.Single(d => d.Id == i));
            var employee = q(DbContext, xid);
            employee.Status = "Disactive";
            DbContext.SubmitChanges();
            return true;
        }
    }
}
