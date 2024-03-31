
using AutoMapper;

class program
{
    static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //app.MapGet("/", () => "Hello World!");

        
        // Create an Employee instance (source)
        var employee = new Employee
        {
            Name = "John Doe",
            Salary = 50000,
            Department = "Engineering",
            Address = new Address
            {
                City = "New York",
                PostalCode = 10001,
                Country = "USA"
            }
        };



        //Mapping Manually
        EmployeeHiddenSalary employeeWithoutSalary = new EmployeeHiddenSalary();
        employeeWithoutSalary.Name = employee.Name;
        employeeWithoutSalary.Address = employee.Address;
        employeeWithoutSalary.Dept= employee.Department;
        //Do this for every attribute of employeeWithoutSalary

        app.MapGet("/GetEmployeeTediously",()=>
        {
            var response = $"Manually mapping{Environment.NewLine}" +
                           $"Name: {employeeWithoutSalary.Name}{Environment.NewLine}" +
                           $"Department: {employeeWithoutSalary.Dept}{Environment.NewLine}" +
                           $"Country: {employeeWithoutSalary.Address.Country}{Environment.NewLine}" +
                           $"Postal code: {employeeWithoutSalary.Address.PostalCode}{Environment.NewLine}" +
                           $"City: {employeeWithoutSalary.Address.City}";

            return response;
        });






        //Using Mapper
        var mapper = MapperConfig.InitializeMapper<Employee,EmployeeHiddenSalary>();
        var config = new MapperConfiguration(cfig =>
        {
            cfig.CreateMap<Employee, EmployeeHiddenSalary>().ForMember(
               dest => dest.Dept, opt => opt.MapFrom(src => src.Department));
        });
        var mapper2 = new Mapper(config);
        EmployeeHiddenSalary employeeHiddenSalary= mapper2.Map<EmployeeHiddenSalary>(employee);
        app.MapGet("/GetEmployeeWithAutoMapper", () =>
        {
            var response = $"AutoMapper{Environment.NewLine}" +
                           $"Name: {employeeHiddenSalary.Name}{Environment.NewLine}" +
                           $"Department: {employeeHiddenSalary.Dept}{Environment.NewLine}" +
                           $"Country: {employeeHiddenSalary.Address.Country}{Environment.NewLine}" +
                           $"Postal code: {employeeHiddenSalary.Address.PostalCode}{Environment.NewLine}" +
                           $"City: {employeeHiddenSalary.Address.City}";

            return response;
        });

        app.Run();
    }

}
