using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<string> Employee = new List<string> {"emp1", "emp2"};

    [HttpGet]
    [Route("GetEmployee")]
    public List<string> GetEmployee()
    {
        return Employee;
    }


    [HttpPost]
    [Route("PostEmployee")]
    public List<string> PostEmployee(string emp)
    {
        Employee.Add(emp);
        return Employee;
    }
}