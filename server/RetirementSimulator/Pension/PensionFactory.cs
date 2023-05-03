using BL.DTO;
using BL.PensionService;
using System.Text.Json;

namespace BL.Pension;
public class PensionFactory : IPensionFactory
{
    public PensionFactory()
    {

    }
    public string Create(string pensionType, object employee)
    {
        Employee pensionEmploee;

        switch (pensionType)
        {
            case "AccrualPensionService":
                pensionEmploee = new Employee();
                break;
            case "BudgetPensionService":
                var temp = JsonSerializer.Serialize(employee);
                var current = JsonSerializer.Deserialize<BudgetPensionEmployee>(temp);
                pensionEmploee = current;
                //pensionEmploee = new BudgetPensionEmployee();
                break;
            case "BPSForSeniorSalarye":
                pensionEmploee = new BudgetPensionEmployee();
                break;
            default:
                throw new InvalidParameterException();
        }
        string jsonEmployee = JsonSerializer.Serialize(employee);
       return pensionEmploee.Clculates();
        //pensionService.SetEmployee(jsonEmployee);
        //return GetCalculates(pensionService);
    }

    public string GetCalculates(IPensionService pensionService)
    {
        string json = "{";
        foreach (var methodInfo in pensionService.GetType().GetMethods())
        {
            if (methodInfo.GetParameters().Length == 0)
            {
                var result = methodInfo.Invoke(pensionService, null);
                json += $" '{methodInfo.Name}' : '{result}'";
            }
        }
        json += "}";
        return json.Replace("'", "\"");
    }

}