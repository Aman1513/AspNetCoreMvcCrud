using AspCrud.Models.Domain;

namespace AspCrud.Interface
{
    public interface IEmployeeRepository
    {
        void Add(Employee emp);
        IEnumerable<Employee> GetAll();
        Employee Update(int id);
        void Edited(Employee emp);
        void Delete(Employee emp);
    }
}
