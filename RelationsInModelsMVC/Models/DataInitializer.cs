namespace RelationsInModelsMVC.Models
{
    public class DataInitializer
    {
        public static List<Department> SeedDepartment()
        {
            List<Department> departments = new List<Department>
            {
                new Department {Id= 1, Name= "HR"},
                new Department {Id= 2, Name= "IT"},
                new Department {Id= 3, Name= "Finances"}
            };
            return departments;
        }
        public static List<Employee> SeedEmployee()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id= 1,Name = "John", Position = "Manager", Department = new Department { Name = "HR" } },
                new Employee { Id= 2,Name = "Jane", Position = "Staff", Department = new Department { Name = "HR" } },
                new Employee { Id= 3,Name = "Doe", Position = "Manager", Department = new Department { Name = "IT" } },
                new Employee { Id= 4,Name = "Smith", Position = "Staff", Department = new Department { Name = "IT" } },
                new Employee { Id= 5,Name = "Alex", Position = "Manager", Department = new Department { Name = "Finance" } },
                new Employee { Id= 6,Name = "Ava", Position = "Staff", Department = new Department { Name = "Finance" } }
            };
            return employees;
        }
    }
}
