using System.Runtime.ConstrainedExecution;

namespace BL.PensionServices;
public static class Consts
{
    public const int Months = 12;
    public const int DaysAYear = 365;
    public const double CostOfLiving = 0.382; // תוספת יוקר
    public const double SalaryLimitedToCostIncrease = 45000; // גובה משכורת שממנה ומעלה הקצבה מוגבלת
    public const double AllowanceLimitedToCostOfLiving = 7824; // הגבלת הקצבה
    public const double AnnualAnnuityPercentage = 0.02; //  עבור אחוז קיצבה שנתי 2%  
    public const int RemainingVacationDays = 55; //יתרת ימי חופשה
    public const int SeventyPercent = 70;
    public const double AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs5Days = 21.67;
    public const double AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs6Days = 21.67;
}
