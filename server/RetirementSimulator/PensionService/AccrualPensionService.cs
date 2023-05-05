using BL.DTO;
using System.Text.Json;

namespace BL.PensionService;

internal  class AccrualPensionService : PensionService
{
    public AccrualPensionService()
    {
    }
    //public void SetEmployee(string employee)
    //{
    //    var current  = JsonSerializer.Deserialize<Employee>(employee);
    //    this.Employee = current;
    //}
    /// <summary>
    /// חישוב הקצבה 
    /// סכום הקצבה יהיה: משכורת אחרונה * 2% לכל שנת עבודה * חלקיות המשרה
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, double> CalculatingAllowance(Employee employee)
    {
        //double lastSalary = employee.PensionSalaryFor100PercentPosition;
        double lastSalary = 12;
        //double partTime = employee.AverasionSalaryFor100PercentPosition;
        double partTime = 12;
        int years = employee.RetirementDate.Year - employee.StartWorkDate.Year;
        Dictionary<string, double> dict = new Dictionary<string, double>(); ;
        dict["FullPensionPercentage"] = lastSalary * partTime * 0.02 * years;
        dict["AveragePartiality"] = lastSalary * partTime * 0.02 * years;
        dict["AnnuityPercentageIsCalculated"] = lastSalary * partTime * 0.02 * years;
        dict["allowanceAmount"] = lastSalary * partTime * 0.02 * years;
        return dict;
    }
}
