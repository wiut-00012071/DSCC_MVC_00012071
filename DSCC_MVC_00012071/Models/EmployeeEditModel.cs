namespace DSCC_MVC_00012071.Models
{
    public class EmployeeEditModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}