using AspCrud.Data;
using AspCrud.Interface;
using AspCrud.Models;
using AspCrud.Models.Domain;

namespace AspCrud.Implementations
{
    public class SqlEmployeeRepository :IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public SqlEmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee Update(int id)
        {
            var emp=_context.Employees.Where(x=>x.Id==id).FirstOrDefault();
            return emp;
        }

        public void Edited(Employee employee)
        {
            var emp = _context.Employees.Attach(employee);
            emp.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Employee emp) 
        {
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }
    }
}
