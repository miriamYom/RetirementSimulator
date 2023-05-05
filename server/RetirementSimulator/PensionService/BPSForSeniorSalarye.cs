using BL.DTO;
using System.Text.Json;

namespace BL.PensionService;

/// <summary>
/// Budget Pension Service for Senior salary
/// </summary>
public  class BPSForSeniorSalarye : BudgetPensionService
{
    public BPSForSeniorSalarye()
    {
    }
    //public void SetEmployee(string employee)
    //{
    //    var current = JsonSerializer.Deserialize<BPEForSeniorSalary>(employee);
    //    this.Employee = current;
    //}
    /// <summary>
    /// 
    /// לא נבדקו מקרי קצה :(
    /// </summary>
    /// <returns></returns>
    public static double TotalEstimatedAllowanceAmount(BPEForSeniorSalary employee)
    {
        double collectiveAgreementSalary = employee.DeterminedSalaryByCollectiveAgreement;
        double seniorSalary = employee.SalaryDeterminesBySeniorSalary;
        double yearsInSeniorSalary = employee.YersInSeniorSalary;
        double yearsInACollectiveAgreement = employee.YersInACollectiveAgreement;
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

    public static double PercentagOfAllowanceInACollectiveAgreement(BPEForSeniorSalary employee)
    {
        return TotalPeriodOfWorkAtTheAuthority(employee) * AveragePartTimeJobForRetirement(employee);
    }
    public static double AveragePartTimeJobForRetirement(BPEForSeniorSalary employee)
    {
        return AveragePartTimeJob(employee.WorkPriodsForSeniorSalary);
    }
    public static double PercentagOfAllowanceInACollectiveAgreementForSeniorSalaty(BPEForSeniorSalary employee)
    {
        return employee.YersInSeniorSalary * AveragePartTimeJobForRetirement(employee);
    }
    public static double SumOfAlowance(BPEForSeniorSalary employee)
    {
        return PercentagOfAllowanceInACollectiveAgreement(employee) * TotalWorkingPeriodForRetirement(employee) +
            PercentagOfAllowanceInACollectiveAgreementForSeniorSalaty(employee) * TotalPeriodOfWork(employee.WorkPriodsForSeniorSalary);
    }
}
