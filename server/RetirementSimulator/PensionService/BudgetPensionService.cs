﻿using BL.DTO;
using System.Data;
using System.Text.Json;
using static BL.PensionService.Consts;

namespace BL.PensionService;

public class BudgetPensionService : IPensionService
//תקציבית
{
    BudgetPensionEmployee Employee { get; set; }
    public BudgetPensionService()
    {
        this.Employee = new BudgetPensionEmployee();
    }
    public void SetEmployee(string employee)
    {
        var current = JsonSerializer.Deserialize<BudgetPensionEmployee>(employee);
        this.Employee = current;
    }

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

    /// <summary>
    /// function to calculate the age of the employee at retirment
    /// </summary>
    /// <returns></returns>
    public double EmployeesAgeAtRetirement()
    {
        //well done
        return TotalYears(Employee.BirthDate, Employee.RetirementDate);
    }

    /// <summary>
    /// function to calculate how time the employee worked in the authory
    /// </summary>
    /// <returns></returns>
    public double YearsOfWorkAtTheAuthority()
    {
        //well done
        return TotalYears(Employee.StartWorkDate, Employee.RetirementDate);
    }
    /*
    /// <summary>
    /// משכורת קובעת לפנסיה תקציבית למשרה מלאה
    /// במקרה שהזינו סכום תוספת שכר פנסיוני שלא מחושב לתקציבית,
    /// אז יהי שנוי.
    /// </summary>
    /// <returns></returns>
    public double SalaryDetermines()
    {
        Employee.SalaryDetermines -= Employee.SalaryIncreasesThatAreNotCalculated;
        return Employee.SalaryDetermines;
    }
    */
    /// <summary>
    /// function to calculate work period between 2 days
    /// </summary>
    /// <returns>Total working time</returns>
    /// 
    protected static double WorkPeriod(string start, string end)
    {
        //????????????????????????????????
        return TotalYears(start, end);
    }

    /// <summary>
    /// get data table with start date, end date and part time job and calculate the work periods.
    /// </summary>
    /// <returns> data table with the calculated column</returns>
    public DataTable TotalWorkPeriods()
    {
        DataTable table = Employee.WorkPeriods;
        // well done!!!
        try
        {
            DataColumn column = table.Columns.Add("Total work period", typeof(double));
            //column.AllowDBNull = false;

            var numOfRows = table.Rows.Count;
            for (int i = 0; i < numOfRows; i++)
            {
                var TotalWorkPeriod = WorkPeriod(table.Rows[i][0].ToString(), table.Rows[i][1].ToString());
                table.Rows[i][3] = Math.Round(TotalWorkPeriod, 2);
            }
        }
        catch (Exception ex) { }
        Employee.WorkPeriods = table;
        return table;

    }

    /// <summary>
    /// calculate the total periods of work at the authority
    /// </summary>
    /// <returns>sum of work periods work</returns>
    /// <exception cref="InvalidDataException">if the value in the table is not a number</exception>
    public double TotalPeriodOfWorkAtTheAuthority()
    {
        DataTable table = Employee.WorkPeriods;
        // well done!!!
        return TotalPeriodOfWork(table);
    }
    protected double TotalPeriodOfWork(DataTable table)
    {
        // well done!!!
        var numOfRows = table.Rows.Count;
        double sumOfWorkPeriods = 0;

        for (int i = 0; i < numOfRows; i++)
        {
            double doubleValue;
            string? cellValue = table?.Rows[i][3].ToString();
            if (double.TryParse(cellValue, out doubleValue))
            {
                sumOfWorkPeriods += doubleValue;
            }
            else
            {
                throw new InvalidDataException("work period must be number");
            }
        }
        return Math.Round(sumOfWorkPeriods, 2);
    }
    /// <summary>
    /// function to calculate full work period according to partiality
    /// </summary>
    /// <param name="totalWorkPeriod"> work period in current job</param>
    /// <param name="partTimeJob">part time job</param>
    /// <returns></returns>
    public double FullWorkPeriodAccordingToPartiality()
    {
        // change this func
        return TotalPeriodOfWorkAtTheAuthority() * AveragePartTimeJobForRetirement();
    }

    /// <summary>
    /// calculate the work periods that accruals to pension
    /// The years of work must be added up according to whether the employee worked 1/3 of a job or more
    /// </summary>
    /// <returns>Total working period for retirement</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public double TotalWorkingPeriodForRetirement()
    {
        DataTable table = ((BudgetPensionEmployee)this.Employee).WorkPeriods;
        var numOfRows = table.Rows.Count;
        double sumOfPeriods = 0;
        double doubleValue;
        double workPreiod;
        for (int i = 0; i < numOfRows; i++)
        {
            string cellValue = table.Rows[i][2].ToString();
            if (double.TryParse(cellValue, out doubleValue))
            {
                if (doubleValue >= 0.3329)
                {
                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
                        sumOfPeriods += workPreiod;
                    else
                    {
                        throw new InvalidDataException("work period must be number");
                    }
                }
            }
            else
            {
                throw new InvalidDataException("work period must be number");
            }
        }
        return Math.Round(sumOfPeriods, 2);
    }

    /// <summary>
    /// Calculation of the periods in which the employee did not work at all
    /// </summary>
    /// <returns>The total number of periods in which the employee was on unpaid vacation</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public double UnpaidVacation()
    {
        DataTable table = ((BudgetPensionEmployee)this.Employee).WorkPeriods;
        var numOfRows = table.Rows.Count;
        double sumOfPeriods = 0;
        double doubleValue;
        double workPreiod;
        for (int i = 0; i < numOfRows; i++)
        {
            string cellValue = table.Rows[i][2].ToString();
            if (double.TryParse(cellValue, out doubleValue))
            {
                if (doubleValue == 0)
                {
                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
                        sumOfPeriods += workPreiod;
                    else
                    {
                        throw new InvalidDataException("work period must be number");
                    }
                }
            }
            else
            {
                throw new InvalidDataException("work period must be number");
            }
        }
        return Math.Round(sumOfPeriods, 2);
    }

    /// <summary>
    /// Total period of work for which he is entitled to compensation
    /// </summary>
    /// <returns>The total work periods in which the employee worked less than 1/3 of a job</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public double WorkingPeriodForCompensation()
    {
        DataTable table = ((BudgetPensionEmployee)this.Employee).WorkPeriods;
        var numOfRows = table.Rows.Count;
        double sumOfPeriods = 0;
        double doubleValue;
        double workPreiod;
        for (int i = 0; i < numOfRows; i++)
        {
            string cellValue = table.Rows[i][2].ToString();
            if (double.TryParse(cellValue, out doubleValue))
            {
                if (doubleValue < 0.3329)
                {
                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
                        sumOfPeriods += workPreiod;
                    else
                    {
                        throw new InvalidDataException("work period must be number");
                    }
                }
            }
            else
            {
                throw new InvalidDataException("work period must be number");
            }
        }
        return Math.Round(sumOfPeriods, 2);
    }

    /// <summary>
    /// Calculation of the part-time job for pension - for periods of work from 1/3 of a job and above
    /// </summary>
    /// <returns> the Average part-time job for retirement</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    /// 
    public double AveragePartTimeJobForRetirement()
    {
        return AveragePartTimeJob(Employee.WorkPeriods);
    }
    public double AveragePartTimeJob(DataTable table)
    {
        var numOfRows = table.Rows.Count;
        double sumOfPeriods = 0;
        double doubleValue;
        double workPreiod;
        for (int i = 0; i < numOfRows; i++)
        {
            string cellValue = table.Rows[i][2].ToString();
            if (double.TryParse(cellValue, out doubleValue))
            {
                if (doubleValue >= 0.3329)
                {
                    if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
                        sumOfPeriods += workPreiod * doubleValue;
                    else
                    {
                        throw new InvalidDataException("work period must be number");
                    }
                }
            }
            else
            {
                throw new InvalidDataException("work period must be number");
            }
        }
        return Math.Round(sumOfPeriods, 2);
    }
    /*
    // Calculating the allowance
    // חישוב הקצבה

    /// <summary>
    /// A fixed salary for a full-time budget pension,
    /// It will appear only in the case that you have entered a pension salary supplement amount that is not calculated for the budget pension.
    /// The calculation: the total determining salary for a full-time position minus a pension supplement that does not constitute a basis for the budget pension.
    /// </summary>
    /// <param name="fixedSalaryForAFullTimePosition">Salary Determines At Age 60</param>
    /// <param name="pensionSupplement">Salary Increases That Are Not Calculated</param>
    /// <returns>A fixed salary for a full-time budget pension</returns>
    public double FixedSalaryForAFullTimePosition(double fixedSalaryForAFullTimePosition, double pensionSupplement)
    {
        // well done ...
        return fixedSalaryForAFullTimePosition - pensionSupplement;
    }
    /// <summary>
    /// calculate the full pension percentage
    /// אחוז קצבה מלא
    /// </summary>
    /// <param name="yearsOfWork"> sum of years that the employee worked</param>
    /// <returns>full pension percentage</returns>
    public double FullPensionPercentage(double yearsOfWork) => Math.Round(yearsOfWork * 0.2, 2);

    /// <summary>
    /// calculate the annuity percentage calculated
    /// אחוז קצבה מחושב
    /// </summary>
    /// <param name="fullPensionPercentage"> full pension percentage </param>
    /// <param name="averagePartTimeJob"> average part-time job </param>
    /// <returns> annuity percentage calculated </returns>
    public double AnnuityPercentageCalculated(double fullPensionPercentage, double averagePartTimeJob, bool isIDFRetires)
    {
        double annuity = fullPensionPercentage * averagePartTimeJob;
        if (annuity > 0.7)
        {
            if (!isIDFRetires)
            {
                annuity = 0.7;
            }
            else if (annuity > 0.76)
            {
                annuity = 0.76;
            }
        }
        return annuity;
    }

    /// <summary>
    /// sum of the allowance
    /// </summary>
    /// <param name="allowancePercentage"> Annuity percentage calculated </param>
    /// <param name="fixedSalary"> fixed salary</param>
    /// <returns>sum of the allowance</returns>
    public double AllowanceAmount(double allowancePercentage, double fixedSalary) => allowancePercentage * fixedSalary;

    /// <summary>
    /// cost of living allowance
    /// תוספת יוקר
    /// </summary>
    /// <param name="fixedSalary">fixed salary</param>
    /// <returns>cost of living allowance</returns>
    public double CostOfLivingAllowance(double fixedSalary)
        => Math.Round(fixedSalary * 0.382);

    /// <summary>
    /// Total estimated allowance amount
    /// סה"כ סכום הקצבה המשוערת
    /// </summary>
    /// <param name="AllowanceAmount"> allowance amount</param>
    /// <param name="costOfLivingAllowance">cost of living allowance</param>
    /// <returns>Total estimated allowance amount</returns>
    public virtual double TotalEstimatedAllowanceAmount(double AllowanceAmount, double costOfLivingAllowance)
        => AllowanceAmount + costOfLivingAllowance;

    */
}
