using BL.Enums;
using BL.PensionServices;
using System.Data;
using System.Reflection;

namespace BL.DTO;

public class BudgetPensionEmployee : Employee
{
    public BudgetPensionEmployee()
    {

    }
    public override string Clculates()
    {
        string json = "{";
        object[] param = { this };
        foreach (var methodInfo in typeof(BudgetPensionService).GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            var result = methodInfo.Invoke(null, param);
            json += $" '{methodInfo.Name}' : '{result}'";
        }
        json += "}";
        return json.Replace("'", "\"");
    }
    // הבראה- מסך 4--------------------------------------------------------------------
    /// <summary>
    /// אחוז הפרשה לפיצויים
    /// Percentage provision for compensation
    /// 6% or 8.33%
    /// </summary>
    //public PercentageProvisionForCompensation PercentageProvisionForCompensation { get; set; }
    private PercentageProvisionForCompensation percentageProvisionForCompensation;
    public PercentageProvisionForCompensation PercentageProvisionForCompensation
    {
        get { return percentageProvisionForCompensation; }
        set { percentageProvisionForCompensation = (PercentageProvisionForCompensation)Enum.Parse(typeof(PercentageProvisionForCompensation), value.ToString()); }
    }

    /// <summary>
    /// יתרת פיצויים בקופה
    /// </summary>
    public double CompensationBalanceInTheCashRegister { get; set; }
    /// <summary>
    /// משכורת קובעת בגיל 60
    /// Determined salary
    /// </summary>
    public double SalaryDeterminesAtAge60 { get; set; }
    /// <summary>
    /// מתוך המשכורת הקובעת, סך תוספות השכר הפנסיוניות שאינן מחושבות לפנסיה התקציבית
    /// nullable
    /// From the determining salary, the total pensionable salary increases that are not calculated for the budget pension
    /// </summary>
    public double SalaryIncreasesThatAreNotCalculated { get; set; } = 0;

    public double SalaryDetermines { get; set; }
    /// <summary>
    /// אם נבחר המדינה \ הרשות המקומית \צה"ל \ כוחות בטחון
    /// </summary>uble percentagePensionFromPreviousWorkplace;

    private double percentagePensionFromPreviousWorkplace; 
    public double PercentagePensionFromPreviousWorkplace 
    {
        get { return percentagePensionFromPreviousWorkplace; }// PercentagePensionFromPreviousWorkplace; }
        set
        {
            if (value > 70)
            {
                throw new InvalidParameterException("Pension percentage from the previous workplace cannot be more than 70%.");
            }
            if (value < 0)
            {
                throw new InvalidParameterException("Pension percentage from the previous workplace cannot be less than 0.");
            }
            percentagePensionFromPreviousWorkplace = value;
        }
    }
    /// <summary>
    /// אם נבחר צה"ל / כוחות בטחון
    /// השכר קובע את הפנסיה בצה"ל:
    /// </summary>
    public double SalaryDeterminesPensionInIDF { get; set; }

    /// <summary>
    /// אם בחרו קרנות ותיקות:
    /// סכום הקצבה
    /// </summary>
    public double AmountOfAllowance { get; set; }
    /// <summary>
    /// אחוזי נכות- רק אם פורש מסיבות רפואיות
    /// </summary>
    public double DisabilityPercentages { get; set; }

    //public FamilyStatus FamilyStatus { get; set; }
    private FamilyStatus familyStatus;
    public FamilyStatus FamilyStatus
    {
        get { return familyStatus; }
        set { familyStatus = (FamilyStatus)Enum.Parse(typeof(FamilyStatus), value.ToString()); }
    }

    /// <summary>
    /// תקופות עבודה- טבלה בעלת 4 עמודות-
    /// תאריך תחילת עבודה, תאריך סיום עבודה, סה"כ תקופת עבודה וחלקיות משרה ממצועת 
    /// </summary>
    //public DataTable? WorkPeriods { get; set; } 
    private DataTable? workPeriods;

    public DataTable WorkPeriods
    {
        get { return workPeriods; }
        set { workPeriods = value; }//.ToDataTable(); }
    }


    /// <summary>
    /// משכורת קובעת
    /// </summary>
    public double DeterminedSalaryByCollectiveAgreement { get; set; }
   
    // מחלה--------------------------------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// יתרת ימי מחלה בפרישה
    /// </summary>
    public int RemainingSickDaysInRetirement { get; set; }
    /// <summary>
    /// אופן צבירת המחלה - צבירה מלאה / צבירה לפי חלקיות
    /// Full accrual / partial accrual
    /// </summary>
    public bool IsFullAccrual { get; set; }
   
    // חופשה---------------------------------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// יתרת ימי חופשה בפרישה
    /// </summary>
    public int RemainingVacationDaysInRetirement { get; set; }
    /// <summary>
    /// מספר ימי העסקה בשבוע
    ///Number of business days per week
    /// 6 or 5
    /// </summary>
    public bool IsFiveBusinessDays { get; set; }
    /// <summary>
    /// אופן צבירת החופשה- צבירה מלאה  - ללא קשר לחלקיות / צבירה לפי חלקיות
    /// How the vacation is accrued
    /// </summary>
    public bool IsAggregationByParts { get; set; }

}
