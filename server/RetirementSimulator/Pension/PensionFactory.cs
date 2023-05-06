using BL.DTO;
using BL.PensionServices;
using MongoDB.Bson.IO;
using System.Text.Json;
using static MongoDB.Driver.WriteConcern;

namespace BL.Pension;
public class PensionFactory : IPensionFactory
{
    public PensionFactory()
    {

    }
    public string Create(string pensionType, object employee)
    {
        Employee pensionEmploee;

        var json = JsonSerializer.Serialize(employee);
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        switch (pensionType)
        {
            case "AccrualPension":
                pensionEmploee = new Employee(dictionary);
                break;
            case "BudgetPension":
                //var temp = JsonSerializer.Serialize(employee);
                //var current = JsonSerializer.Deserialize<BudgetPensionEmployee>(temp);
                //pensionEmploee = current;
                pensionEmploee = new BudgetPensionEmployee();
                break;
            case "BPSForSenior":
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

}