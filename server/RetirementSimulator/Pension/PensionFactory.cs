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
        IPensionService pensionService;

        switch (pensionType)
        {
            case "AccrualPensionService":
                pensionService = new AccrualPensionService();
                break;
            case "BudgetPensionService":
                pensionService = new BudgetPensionService();
                break;
            case "BPSForSeniorSalarye":
                pensionService = new BPSForSeniorSalarye();
                break;
            default:
                throw new InvalidParameterException();
        }
        string jsonEmployee = JsonSerializer.Serialize(employee);
        pensionService.SetEmployee(jsonEmployee);
        return GetCalculates(pensionService);
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