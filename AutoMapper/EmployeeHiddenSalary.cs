using AutoMapper.Configuration.Annotations;

namespace AutoMapper
{
    [AutoMap(typeof(Employee))]
    public class EmployeeHiddenSalary
    {
        public String Name { get; set; }
        public String Dept { get; set; }
        public Address Address { get; set; }

        //There are 50 more attributes in this class
    }
}
