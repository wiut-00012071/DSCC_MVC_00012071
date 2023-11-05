using DSCC_MVC_00012071.Models;

namespace DSCC_MVC_00012071.Services
{
    public class DepartmentService
    {
        private readonly RestClientService _restClientService;

        public DepartmentService( RestClientService restClientService )
        {
            _restClientService = restClientService;
        }

        public IEnumerable<Department> GetAll()
        {
            try
            {
                IEnumerable<Department> departments = _restClientService.Get<List<Department>>("departments");

                return departments;
            }
            catch
            {
                return new List<Department> { };
            }
        }

        public Department? GetOne( int id )
        {
            try
            {
                Department department = _restClientService.Get<Department>($"departments/{id}");

                return department;
            }
            catch
            {
                return null;
            }
        }

        public Department? Insert( Department department )
        {
            try
            {
                Department createdDepartment = _restClientService.Post("departments", department);

                return createdDepartment;
            }
            catch
            {
                return null;
            }
        }

        public Department? Update( Department department )
        {
            try
            {
                Department updatedDepartment = _restClientService.Put("departments", department);

                return updatedDepartment;
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
                string status = _restClientService.Delete($"departments/{id}");

                return status == "200";
            }
            catch
            {
                return false;
            }
        }
    }
}
