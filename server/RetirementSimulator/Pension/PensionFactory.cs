using BL.DTO;
using BL.PensionServices;
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
            case "AccrualPension":
                pensionEmploee = new Employee();
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