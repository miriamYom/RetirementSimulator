using BL.DTO;
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
    protected static double TotalYears(DateTime date_1, DateTime date_2)
    {
        // well done
        try
        {
            //double result;
            //var date1 = DateTime.Parse(date_1);
            //var date2 = DateTime.Parse(date_2);
            TimeSpan interval = date_2 - date_1;
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
}

