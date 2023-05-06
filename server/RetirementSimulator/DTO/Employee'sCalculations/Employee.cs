using BL.Enums;
using BL.PensionServices;
using System.Reflection;

namespace BL.DTO;

public class Employee
{
    public Employee()
    {

    }
    public Employee(Dictionary<string, object> dict)
    {
        #region ctor
        Name = dict.ContainsKey("name") ? dict["name"].ToString()
            : throw new InvalidParameterException("emeployee Name is not defined.");
        BirthDate = dict.ContainsKey("birthDate") ? DateTime.Parse(dict["birthDate"].ToString())
            : throw new InvalidParameterException("emeployee BirthDate is not defined.");
        StartWorkDate = dict.ContainsKey("startWorkDate") ? DateTime.Parse(dict["startWorkDate"].ToString())
            : throw new InvalidParameterException("emeployee StartWorkDate is not defined.");
        RetirementDate = dict.ContainsKey("retirementDate") ? DateTime.Parse(dict["retirementDate"].ToString())
            : throw new InvalidParameterException("emeployee RetirementDate is not defined.");
        Reason = dict.ContainsKey("reason") ?
            (RetirementReason)Enum.Parse(typeof(RetirementReason), dict["reason"].ToString())
            : throw new InvalidParameterException("emeployee RetirementReason is not defined.");
        AdvanceNotice = dict.ContainsKey("advanceNotice") ?
            (MonthOrTwoOrTree)Enum.Parse(typeof(MonthOrTwoOrTree), dict["advanceNotice"].ToString())
            : throw new InvalidParameterException("emeployee AdvanceNotice is not defined.");
        MonthOfClothingPayment = dict.ContainsKey("monthOfClothingPayment") ?
           (Months)Enum.Parse(typeof(Months), dict["monthOfClothingPayment"].ToString())
           : throw new InvalidParameterException("emeployee MonthOfClothingPayment is not defined.");
        RecoveryPaymentMonth = dict.ContainsKey("recoveryPaymentMonth") ?
           (Months)Enum.Parse(typeof(Months), dict["recoveryPaymentMonth"].ToString())
           : throw new InvalidParameterException("emeployee RecoveryPaymentMonth is not defined.");
        IsClothingForAudienceMembers = dict.ContainsKey("isClothingForAudienceMembers") ?
           bool.Parse(dict["isClothingForAudienceMembers"].ToString())
           : throw new InvalidParameterException("emeployee IsClothingForAudienceMembers is not defined.");
        IsMonthlyClothingPayment = dict.ContainsKey("isMonthlyClothingPayment") ?
           bool.Parse(dict["isMonthlyClothingPayment"].ToString())
           : throw new InvalidParameterException("emeployee IsMonthlyClothingPayment is not defined.");
        IsThreeLevel = dict.ContainsKey("isThreeLevel") ?
           bool.Parse(dict["isThreeLevel"].ToString())
           : throw new InvalidParameterException("emeployee IsThreeLevel is not defined.");
        IsCurrentYear = dict.ContainsKey("isCurrentYear") ?
           bool.Parse(dict["isCurrentYear"].ToString())
           : throw new InvalidParameterException("emeployee IsCurrentYear is not defined.");
        IsMonthlyRecoveryPayment = dict.ContainsKey("isMonthlyRecoveryPayment") ?
           bool.Parse(dict["isMonthlyRecoveryPayment"].ToString())
           : throw new InvalidParameterException("emeployee IsMonthlyRecoveryPayment is not defined.");
        NumberOfDaysOfRecoveryToBePaid = dict.ContainsKey("numberOfDaysOfRecoveryToBePaid") ?
           Int32.Parse(dict["numberOfDaysOfRecoveryToBePaid"].ToString())
           : throw new InvalidParameterException("emeployee NumberOfDaysOfRecoveryToBePaid is not defined.");
        #endregion
    }

    public virtual string Clculates()
    {
        string json = "{";
        object[] perems = { this };
        foreach (var methodInfo in typeof(PensionService).GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            var result = methodInfo.Invoke(null, perems);
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
    public RetirementReason Reason { get; set; }

    /// <summary>
    /// בפיטורין
    /// חלף הודעה מוקדמת
    /// </summary>
    public MonthOrTwoOrTree AdvanceNotice { get; set; }

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
    public Months MonthOfClothingPayment { get; set; }
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
    public Months RecoveryPaymentMonth { get; set; }


}
