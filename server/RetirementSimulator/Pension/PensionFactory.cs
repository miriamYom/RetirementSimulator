using BL.DTO;
using System.Text.Json;

namespace BL.Pension;
public class PensionFactory : IPensionFactory
{
    public PensionFactory()
    {
    }
    public string Create(string pensionType, Employee employee)
    {
        Employee pensionEmployee;

        var json = JsonSerializer.Serialize(employee);
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        switch (pensionType)
        {
            case "AccrualPension":
                pensionEmployee = new Employee(dictionary);
                break;
            case "BudgetPension":
                pensionEmployee = new BudgetPensionEmployee();
                //pensionEmployee = employee;
                pensionEmployee = (BudgetPensionEmployee)employee;
                break;
            case "BPSForSenior":
                pensionEmployee = new BudgetPensionEmployee();
                break;
            default:
                throw new InvalidParameterException();
        }
        string jsonEmployee = JsonSerializer.Serialize(employee);
        return pensionEmployee.Clculates();
        //pensionService.SetEmployee(jsonEmployee);
        //return GetCalculates(pensionService);
    }

}