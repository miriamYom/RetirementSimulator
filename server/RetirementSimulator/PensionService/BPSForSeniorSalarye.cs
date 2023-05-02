using BL.DTO;
using System.Text.Json;

namespace BL.PensionService;

/// <summary>
/// Budget Pension Service for Senior salary
/// </summary>
public class BPSForSeniorSalarye : BudgetPensionService
{
    BPEForSeniorSalary Employee { get; set; }
    public BPSForSeniorSalarye()
    {
        this.Employee = new BPEForSeniorSalary();
    }
    public void SetEmployee(string employee)
    {
        var current = JsonSerializer.Deserialize<BPEForSeniorSalary>(employee);
        this.Employee = current;
    }
    /// <summary>
    /// 
    /// לא נבדקו מקרי קצה :(
    /// </summary>
    /// <returns></returns>
    public double TotalEstimatedAllowanceAmount()
    {
        double collectiveAgreementSalary = Employee.DeterminedSalaryByCollectiveAgreement;
        double seniorSalary = Employee.SalaryDeterminesBySeniorSalary;
        double yearsInSeniorSalary = Employee.YersInSeniorSalary;
        double yearsInACollectiveAgreement = Employee.YersInACollectiveAgreement;
        // פונקציה לא גמורה. מחשבת את הקיצבה לעובד המועסק בהסכם קיבוצי + שכר בכירים
        if (yearsInACollectiveAgreement + yearsInSeniorSalary > 35)
        {
            double allowancePercentageSalary = yearsInSeniorSalary * 0.02;
            double allowancePercentageCollective = (35 - yearsInACollectiveAgreement) * 0.02;
            return allowancePercentageSalary + allowancePercentageCollective;
        }
        else
        {
            double allowancePercentageSalary = yearsInSeniorSalary * 0.02;
            double allowancePercentageCollective = yearsInACollectiveAgreement * 0.02;
            return allowancePercentageSalary * seniorSalary + allowancePercentageCollective * collectiveAgreementSalary;
        }
    }

    public double PercentagOfAllowanceInACollectiveAgreement()
    {
        return TotalPeriodOfWorkAtTheAuthority() * AveragePartTimeJobForRetirement();
    }
    public double AveragePartTimeJobForRetirement()
    {
        return AveragePartTimeJob(Employee.WorkPriodsForSeniorSalary);
    }
    public double PercentagOfAllowanceInACollectiveAgreementForSeniorSalaty()
    {
        return Employee.YersInSeniorSalary * AveragePartTimeJobForRetirement();
    }
    public double SumOfAlowance()
    {
        return PercentagOfAllowanceInACollectiveAgreement() * TotalWorkingPeriodForRetirement() +
            PercentagOfAllowanceInACollectiveAgreementForSeniorSalaty() * TotalPeriodOfWork(Employee.WorkPriodsForSeniorSalary);
    }
}
