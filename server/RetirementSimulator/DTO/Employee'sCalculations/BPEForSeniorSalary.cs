using BL.Enums;
using System.Data;

namespace BL.DTO;

public class BPEForSeniorSalary : BudgetPensionEmployee
{
    public DataTable WorkPriodsForSeniorSalary { get; set; }
    /// <summary>
    /// האם חתם על רציפות זכויות
    /// </summary>ly TransitionDateForSeniorSalaries { get; set; }
    public bool SignedCopyrightContinuity { get; set; }

    /// <summary>
    /// אם חתם על רציפות זכויות:
    /// </summary>
    public TheSignedOwnership Ownership { get; set; }
    /// <summary>
    /// אם בחרו בהסכם קיבוצי ושכר בכירים יש למלא גם את הנתון הבא
    /// </summary>
    public double SalaryDeterminesBySeniorSalary { get; set; }
    /// <summary>
    /// האם בחוזה העסקה נקבע כי פדיון ימי המחלה ישולם לפי משכורת אחרונה?
    /// Does the employment contract stipulate that sick pay will be paid according to the last salary?
    /// </summary>
    public bool IsSickDayPaidAccordingToLastSalary { get; set; }
    /// <summary>
    /// אם כן- אין צורך בשאלה הבאה
    /// יתרת ימי מחלה במועד המעבר לשכר בכירים
    /// </summary>
    public int RemainingSickDaysAtTheTimeOfTransitionToSeniorSalary { get; set; }
    /// <summary>
    /// נתון שיואתחל מהטבלה
    /// </summary>
    public double YersInSeniorSalary { get; set; }
    public double YersInACollectiveAgreement { get; set; }
}

