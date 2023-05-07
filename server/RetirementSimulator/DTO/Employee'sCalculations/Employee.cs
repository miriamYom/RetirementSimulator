using BL.Enums;
using BL.PensionServices;
using System.Reflection;

namespace BL.DTO;

public class Employee
{
    public Employee()
    {
       
    }

    public virtual string Clculates()
    {
        string json = "{";
        object[] param = { this };
        foreach (var methodInfo in typeof(PensionService).GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            var result = methodInfo.Invoke(null, param);
            json += $" '{methodInfo.Name}' : '{result}'";
        }
        json += "}";
        return json.Replace("'", "\"");
    }
    public string Name { get; set; }
    public int ID { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime StartWorkDate { get; set; }
    /// <summary>
    /// תאריך פרישה צפוי
    /// </summary>
    public DateTime RetirementDate { get; set; }
    /// <summary>
    /// סוג הפרישה
    /// </summary>
    private RetirementReason reason;
    public RetirementReason Reason
    {
        get { return reason; }
        set { reason = (RetirementReason)Enum.Parse(typeof(RetirementReason), value.ToString()); }
    }


    /// <summary>
    /// בפיטורין
    /// חלף הודעה מוקדמת
    /// </summary>
    //public MonthOrTwoOrTree AdvanceNotice { get; set; }
    private MonthOrTwoOrTree advanceNotice;
    public MonthOrTwoOrTree AdvanceNotice
    {
        get { return advanceNotice; }
        set { advanceNotice = (MonthOrTwoOrTree)Enum.Parse(typeof(MonthOrTwoOrTree), value.ToString()); }
    }

    //ביגוד
    /// <summary>
    ///  זכאות העובד לביגוד
    ///   ביגוד למקבלי קהל או ביגוד לפועלים
    /// </summary>

    public bool IsClothingForAudienceMembers { get; set; }
    /// <summary>
    /// אופן תשלום הביגוד
    /// monthly / yearly
    /// </summary>
    public bool IsMonthlyClothingPayment { get; set; }

    /// <summary>
    /// רמת הביגוד
    /// רמה 3 או רמה 4
    /// </summary>
    public bool IsThreeLevel { get; set; }
    /// <summary>
    /// חודש תשלום הביגוד
    /// </summary>
    //public Months MonthOfClothingPayment { get; set; }
    private Months monthOfClothingPayment;
    public Months MonthOfClothingPayment
    {
        get { return monthOfClothingPayment; }
        set { monthOfClothingPayment = (Months)Enum.Parse(typeof(Months), value.ToString()); }
    }

    /// <summary>
    /// השנה עבורה משולם הביגוד
    /// שנה נוכחית או שנה קנדרית קודמת
    /// </summary>
    public bool IsCurrentYear { get; set; }
    //הבראה
    /// <summary>
    /// monthly / yearly
    /// </summary>
    public bool IsMonthlyRecoveryPayment { get; set; }
    /// <summary>
    /// מספר ימי הבראה לתשלום
    /// </summary>
    private int numberOfDaysOfRecoveryToBePaid;
    public int NumberOfDaysOfRecoveryToBePaid
    {
        get { return numberOfDaysOfRecoveryToBePaid; }
        set
        {
            if (value > 13 || value < 8)
            {
                throw new InvalidParameterException("The number of recovery days to be paid must be between 8 and 13.");
            }
            numberOfDaysOfRecoveryToBePaid = value;
        }
    }
    //public Months RecoveryPaymentMonth { get; set; }
    private Months recoveryPaymentMonth;

    public Months RecoveryPaymentMonth
    {
        get { return recoveryPaymentMonth; }
        set { recoveryPaymentMonth = (Months)Enum.Parse(typeof(Months), value.ToString()); } 
    }



}
