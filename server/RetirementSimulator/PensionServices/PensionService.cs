using BL.DTO;
using System;
using static BL.PensionServices.Consts;

namespace BL.PensionServices;
internal class PensionService
{
    #region total years
    /// <summary>
    /// the func calculate the years between 2 dates
    /// </summary>
    /// <param name="date_1">from this date</param>
    /// <param name="date_2">to this date</param>
    /// <returns></returns>
    /// <exception cref="InvalidDateException"></exception>
    protected static double TotalYears(string date_1, string date_2)
    {
        // well done
        try
        {
            double result;
            var date1 = DateTime.Parse(date_1);
            var date2 = DateTime.Parse(date_2);
            TimeSpan interval = date2 - date1;
            result = interval.TotalDays / DaysAYear;
            return Math.Round(result, 5);
        }
        catch (InvalidDateException e)
        {
            throw e;
        }
        catch (Exception)
        {
            throw new InvalidDateException("the date format is invalid");
        }

    }
    protected static double TotalYears(DateTime start, DateTime end)
    {
        // well done
        try
        {
            //double result;
            //var date1 = DateTime.Parse(date_1);
            //var date2 = DateTime.Parse(date_2);
            TimeSpan interval = start - end;
            double result = interval.TotalDays / DaysAYear;
            return Math.Round(result, 5);
        }
        catch (InvalidDateException e)
        {
            throw e;
        }
        catch (Exception)
        {
            throw new InvalidDateException("the date format is invalid");
        }

    }
    #endregion
    /// <summary>
    /// function to calculate the age of the employee at retirment
    /// </summary>
    /// <returns></returns>
    public static double EmployeesAgeAtRetirement(Employee employee)
    {
        //well done
        return TotalYears(employee.BirthDate, employee.RetirementDate);
    }
    /// <summary>
    /// function to calculate how time the employee worked in the authory
    /// </summary>
    /// <returns></returns>
    public static double YearsOfWorkAtTheAuthority(Employee employee)
    {
        //well done
        return TotalYears(employee.StartWorkDate, employee.RetirementDate);
    }
    public static double NumberOfVacationDaysToBeRedeemed(BudgetPensionEmployee employee)
    {
        double days = employee.RemainingVacationDaysInRetirement;

        if (days < RemainingVacationDays + DateTime.Now.Month * 1.83)
        {
            return days;
        }
        return RemainingVacationDays + DateTime.Now.Month * 1.83;
    }

    /// <summary>
    /// ערך יום
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double ADaysWorth(BudgetPensionEmployee employee)
    {
        if (employee.IsFiveBusinessDays == true)
        {
            return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs5Days;
        }

        return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs6Days;
    }
    // --------------------------------חופשה-------------------------------
    /// <summary>
    /// מספר ימי חופשה לפדיון
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double NumberOfVacationDaysToBeRedeemed(Employee employee)
    {
        double days = employee.RemainingVacationDaysInRetirement;

        if (days < RemainingVacationDays + DateTime.Now.Month * 1.83)
        {
            return days;
        }
        return RemainingVacationDays + DateTime.Now.Month * 1.83;
    }

    /// <summary>
    /// ערך יום
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public static double ADaysWorth(Employee employee)
    {
        if (employee.IsFiveBusinessDays == true)
        {
            return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs5Days;
        }

        return employee.SalaryDetermines / AverageNumberDaysOfEmploymentPerMonthPerEmployeeIs6Days;
    }
    /// <summary>
    /// סה"כ פדיון ימי חופשה
    /// פונקציה חסרה
    /// מספר ימים לפדיון כפול ערך יום
    ///אם הצבירה היא מלאה, אז יש להכפיל בחלקיות משרה אחרונה
    /// </summary>
    /// <returns></returns>
    public static double TotalRedemptionOfVacationDays(Employee employee)
    {
        double redemption = NumberOfVacationDaysToBeRedeemed(employee) * ADaysWorth(employee);
        if (employee.IsAggregationByParts == false)
        {
            redemption *= employee.LastPartTimeJob; 
        }
        return redemption;
    }

   //-----------------------------פיצוי בגין ימי מחלה שלא נוצלו---------------------------------
   /// <summary>
   /// האם זכאי לפיצוי בכלל
   /// </summary>
   /// <param name="employee"></param>
   /// <returns></returns>
   protected static bool IsEntitled(Employee employee)
    {
        bool flag = false;
        if (employee.Reason == Enums.RetirementReason.dismissal)
        {
            if(YearsOfWorkAtTheAuthority(employee) >= 3)
            {
                flag = true;
            }
        }
        else if(employee.Reason == Enums.RetirementReason.retirementForHealthReasons)
        {
            if(YearsOfWorkAtTheAuthority(employee) >= 5)
            {
                flag = true;
            }
        }
        else if (EmployeesAgeAtRetirement(employee) >= 50)
        {
            if(YearsOfWorkAtTheAuthority(employee) >= 10)
            {
                flag = true;
            }
        }
        if (flag)
        {
            if(employee.IsAggregationByParts)
            {
                30 * YearsOfWorkAtTheAuthority(employee) *//נותר לחשב שלא ניצל יותר מ65 אחוז מימי המחלה שלו
            }
            
        }
        return false;
    }
}

