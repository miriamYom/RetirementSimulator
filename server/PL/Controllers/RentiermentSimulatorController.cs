using BL;
using BL.BLImplements;
using BL.DTO;
using BL.Pension;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace UI.Controllers;

[ApiController]
[Route("[controller]")]
public class RentiermentSimulatorController : ControllerBase
{
    IUserServiceBL userServiceBL;

    IPensionFactory pensionFactory;
    public RentiermentSimulatorController(IUserServiceBL us, IPensionFactory pf)
    {
        userServiceBL = us;
        pensionFactory = pf;
    }

    [HttpGet("GetAll")]
    public List<UserDTO> GetAll()
    {
        return userServiceBL.GetAllAsync().Result;
    }

    [HttpPost("GetDetails")]
    public UserDTO GetDetails(UserDTO user)
    {
        return userServiceBL.GetAsync(user).Result;
    }

    [HttpPost("CreateUser")]
    public bool CreateUser(UserDTO user)
    {
        return userServiceBL.CreateAsync(user).Result;
    }

    [HttpDelete("DeleteUser")]
    public bool DeleteUser(UserDTO user)
    {
        return userServiceBL.DeleteAsync(user).Result;
    }

    [HttpPut("Update")]
    public bool UpdateUser(params UserDTO[] user)
    {
        return userServiceBL.UpdateAsync(user[0], user[1]).Result;
    }

    [HttpPost("Login")]
    public UserDTO Login(string email, [FromBody] string pass)
    {
        return userServiceBL.Login(email, pass);
    }
    [HttpPost("GetPensionCalculates")]
    public string CreatePensionService(string pensionType, [FromBody] object employee)
    {
        try
        {
            var o = employee;
            return pensionFactory.Create(pensionType, employee);
        }
        catch (InvalidParameterException ex)
        {
            throw ex;
        }
    }
    [HttpPost("GetBudgetEmp")]
    public Employee GetBudgetEmp()
    {
        return new BudgetPensionEmployee();
    }

    [HttpPost("GetEmp")]
    public Employee GetEmp()
    {
        return new Employee();
    }
    /*
    private static DataTable ToDataTable<T>(this T[] students)
    {
        if (students == null || students.Length == 0) return null;

        DataTable table = new DataTable();
        var student_tmp = students[0];
        table.Columns.AddRange(student_tmp.GetType().GetFields().Select(field => new DataColumn(field.Name, field.FieldType)).ToArray());
        int fieldCount = student_tmp.GetType().GetFields().Count();

        students.All(student =>
        {
            table.Rows.Add(Enumerable.Range(0, fieldCount).Select(index => student.GetType().GetFields()[index].GetValue(student)).ToArray());
            return true;
        });

        return table;
    }*/
    [HttpGet("dtbl")]
    public DataTable GetDataTable(object[] students)
    {
        if (students == null || students.Length == 0) return null;

        DataTable table = new DataTable();
        var student_tmp = students[0];
        table.Columns.AddRange(student_tmp.GetType().GetFields().Select(field => new DataColumn(field.Name, field.FieldType)).ToArray());
        int fieldCount = student_tmp.GetType().GetFields().Count();

        students.All(student =>
        {
            table.Rows.Add(Enumerable.Range(0, fieldCount).Select(index => student.GetType().GetFields()[index].GetValue(student)).ToArray());
            return true;
        });

        return table;
    }
    
}

