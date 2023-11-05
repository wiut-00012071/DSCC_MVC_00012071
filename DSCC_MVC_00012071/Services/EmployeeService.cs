using DSCC_MVC_00012071.Models;

namespace DSCC_MVC_00012071.Services
{
    public class EmployeeService
    {
        private readonly RestClientService _restClientService;

        public EmployeeService( RestClientService restClientService )
        {
            _restClientService = restClientService;
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                IEnumerable<Employee> employees = _restClientService.Get<List<Employee>>("employees");

                return employees;
            }
            catch
            {
                return new List<Employee> { };
            }
        }

        public Employee? GetOne( int id )
        {
            try
            {
                Employee employee = _restClientService.Get<Employee>($"employees/{id}");

                return employee;
            }
            catch
            {
                return null;
            }
        }

        public Employee? Insert( Employee employee )
        {
            try
            {
                Employee createdEmployee = _restClientService.Post("employees", employee);

                return createdEmployee;
            }
            catch
            {
                return null;
            }
        }

        public Employee? Update( Employee employee )
        {
            try
            {
                Employee updatedEmployee = _restClientService.Put("employees", employee);

                return updatedEmployee;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete( int id )
        {
            try
            {
                string status = _restClientService.Delete($"employees/{id}");

                return status == "200";
            }
            catch
            {
                return false;
            }
        }
    }
}
