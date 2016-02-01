using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;


namespace AbuEhabCourtSystem.Tables_Classes
{
    public class EmployeeCmd : DataBase
    {
        public bool NewEmployee(Employee employee)
        {
            DbContext = new DbDataContext();
            DbContext.Employees.InsertOnSubmit(employee);
            DbContext.SubmitChanges();

            return true;
        }
        public bool EditEmployee(Employee emp, int xid)
        {
            emp.Id = xid;
            var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                                             db.Employees.Single(d => d.Id == i));
            var employee = q(DbContext, xid);
            employee.Id = emp.Id;
            employee.EmployeeName = emp.EmployeeName;
            employee.Address = emp.Address;
            employee.IdCard = emp.IdCard;
            employee.Phone = emp.Phone;
            employee.Email = emp.Email;
            employee.Mobile = emp.Mobile;
            employee.Salary = emp.Salary;
            employee.Status = emp.Status;
            employee.AccountId = emp.AccountId;
            DbContext.SubmitChanges();

            return true;
        }
        public List<Employee> AllEmplyees()
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db) =>
                                                                db.Employees
                                                               );
                var employees = q(DbContext).ToList();

                return employees;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Employee> ListEmplyee_ByName(string name)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db, string n) =>
                                                                db.Employees.Where(c => c.EmployeeName.Contains(n)
                                                             ));
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
                                     db.Employees.Where(c => c.EmployeeName == n)
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
        public bool DeleteEmployee(Employee emp, int xid)
        {
            emp.Id = xid;
            var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                                                          db.Employees.Single(d => d.Id == i));
            var employee = q(DbContext, xid);
            DbContext.Employees.DeleteOnSubmit(employee);
            DbContext.SubmitChanges();
            return true;
        }
    }
}
