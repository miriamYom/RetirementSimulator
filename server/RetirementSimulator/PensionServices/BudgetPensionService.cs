using BL.DTO;
using BL.Enums;
using static BL.PensionServices.Consts;

namespace BL.PensionServices;

internal class BudgetPensionService : PensionService
//תקציבית
{
    public BudgetPensionService()
    {

    }


    /// <summary>
    /// משכורת קובעת לפנסיה תקציבית למשרה מלאה
    /// במקרה שהזינו סכום תוספת שכר פנסיוני שלא מחושב לתקציבית,
    /// </summary>
    /// <returns></returns>
    public static double SalaryDetermines(BudgetPensionEmployee employee)
    {
        if (employee.SalaryIncreasesThatAreNotCalculated > 0)
        {
            employee.SalaryDetermines -= employee.SalaryIncreasesThatAreNotCalculated;
        }
        return employee.SalaryDetermines;
    }



    /// <summary>
    /// get data table with start date, end date and part time job and calculate the work periods.
    /// </summary>
    /// <returns> data table with the calculated column</returns>
    public static void TotalWorkPeriods(BudgetPensionEmployee employee)
    {
        //שהפונקציה תעדכן את הטבלה (שנמצאת בפרופרטיז של האמפלויי), אין צורך בהחזרתה
        //DataTable table = employee.WorkPeriods;

        //try
        //{
        //    datacolumn column = table.columns.add("total work period", typeof(double));
        //    //column.allowdbnull = false;

        //    var numofrows = table.rows.count;
        //    for (int i = 0; i < numofrows; i++)
        //    {
        //        var totalworkperiod = workperiod(table.rows[i][0].tostring(), table.rows[i][1].tostring());
        //        table.rows[i][3] = math.round(totalworkperiod, 2);
        //    }
        //}
        //catch (exception ex) { }
        //employee.workperiods = table;

        //return table;

    }

    /// <summary>
    /// calculate the total periods of work at the authority
    /// </summary>
    /// <returns>sum of work periods work</returns>
    /// <exception cref="InvalidDataException">if the value in the table is not a number</exception>
    public static double TotalPeriodAtTheAuthority(BudgetPensionEmployee employee)
    {
        /*
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
        */
        return 0;
    }

    /// <summary>
    /// function to calculate full work period according to partiality
    /// </summary>
    /// <param name="totalWorkPeriod"> work period in current job</param>
    /// <param name="partTimeJob">part time job</param>
    /// <returns></returns>
    public static void FullWorkPeriodAccordingToPartiality(BudgetPensionEmployee employee)
    {
        //שהפונקציה תעדכן את הטבלה (שנמצאת בפרופרטיז של האמפלויי), אין צורך בהחזרתה
    }

    /// <summary>
    /// calculate the work periods that accruals to pension
    /// The years of work must be added up according to whether the employee worked 1/3 of a job or more
    /// </summary>
    /// <returns>Total working period for retirement</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public static double TotalWorkingPeriodForRetirement(BudgetPensionEmployee employee)
    {
        /*
        DataTable table = employee.WorkPeriods;
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
        */
        return 1;
    }

    /// <summary>
    /// Calculation of the periods in which the employee did not work at all
    /// </summary>
    /// <returns>The total number of periods in which the employee was on unpaid vacation</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public static double UnpaidVacation(BudgetPensionEmployee employee)
    {
        /*
        DataTable table = employee.WorkPeriods;
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
        */
        return 2;
    }

    /// <summary>
    /// Total period of work for which he is entitled to compensation
    /// </summary>
    /// <returns>The total work periods in which the employee worked less than 1/3 of a job</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    public static double WorkingPeriodForCompensation(BudgetPensionEmployee employee)
    {
        /*
        DataTable table = employee.WorkPeriods;
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
        */
        return 3;
    }

    /// <summary>
    /// Calculation of the part-time job for pension - for periods of work from 1/3 of a job and above
    /// </summary>
    /// <returns> the Average part-time job for retirement</returns>
    /// <exception cref="InvalidDataException">if the data in the data table is not a number</exception>
    /// 
    public static double AveragePartTimeJobForRetirement(BudgetPensionEmployee employee)
    {
        return 4;//AveragePartTimeJob(employee.WorkPeriods);
    }

    //public static double AveragePartTimeJob(BudgetPensionEmployee employee)
    //{
    //    return AveragePartTimeJob(employee.WorkPeriods);
    //}
    //protected static double AveragePartTimeJob(DataTable table)
    //{
    //    /*
    //    var numOfRows = table.Rows.Count;
    //    double sumOfPeriods = 0;
    //    double doubleValue;
    //    double workPreiod;
    //    for (int i = 0; i < numOfRows; i++)
    //    {
    //        string cellValue = table.Rows[i][2].ToString();
    //        if (double.TryParse(cellValue, out doubleValue))
    //        {
    //            if (doubleValue >= 0.3329)
    //            {
    //                if (double.TryParse(table.Rows[i][3].ToString(), out workPreiod))
    //                    sumOfPeriods += workPreiod * doubleValue;
    //                else
    //                {
    //                    throw new InvalidDataException("work period must be number");
    //                }
    //            }
    //        }
    //        else
    //        {
    //            throw new InvalidDataException("work period must be number");
    //        }
    //    }
    //    return Math.Round(sumOfPeriods, 2);
    //    */
    //    return 5;
    //}

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // Calculating the allowance
    // חישוב הקצבה



    ///// <summary>
    ///// A fixed salary for a full-time budget pension,
    ///// It will appear only in the case that you have entered a pension salary supplement amount that is not calculated for the budget pension.
    ///// The calculation: the total determining salary for a full-time position minus a pension supplement that does not constitute a basis for the budget pension.
    ///// </summary>
    ///// <param name="fixedSalaryForAFullTimePosition">Salary Determines At Age 60</param>
    ///// <param name="pensionSupplement">Salary Increases That Are Not Calculated</param>
    ///// <returns>A fixed salary for a full-time budget pension</returns>
    //public static double FixedSalaryForAFullTimePosition(BudgetPensionEmployee employee)
    //{
    //    // well done ...
    //    return 0;// fixedSalaryForAFullTimePosition - pensionSupplement;
    //}






    /// <summary>
    /// calculate the full pension percentage
    /// אחוז קצבה מלא
    /// </summary>
    /// <param name="yearsOfWork"> sum of years that the employee worked</param>
    /// <returns>full pension percentage</returns>
    public static double FullPensionPercentage(BudgetPensionEmployee employee) => Math.Round(TotalWorkingPeriodForRetirement(employee) * 0.2, 2);

    /// <summary>
    /// calculate the annuity percentage calculated
    /// אחוז קצבה מחושב
    /// </summary>
    /// <returns> annuity percentage calculated </returns>
    public static double AnnuityPercentageCalculated(BudgetPensionEmployee employee)
    {
        double annuity = FullPensionPercentage(employee) * AveragePartTimeJobForRetirement(employee);
        if (annuity > 0.7)
        {
            if (employee.Ownership != TheSignedOwnership.IDFSecurityForces)
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
    /// <returns>sum of the allowance</returns>
    public static double AllowanceAmount(BudgetPensionEmployee employee) => AnnuityPercentageCalculated(employee) * SalaryDetermines(employee);

    /// <summary>
    /// cost of living allowance
    /// תוספת יוקר
    /// </summary>
    /// <returns>cost of living allowance</returns>
    public static double CostOfLivingAllowance(BudgetPensionEmployee employee)
    {
        double allowance;
        
        if (SalaryDetermines(employee) < SalaryLimitedToCostIncrease)
        {
            allowance = Math.Round(SalaryDetermines(employee) * CostOfLiving, 2);
        }
        else allowance = Math.Round(AllowanceLimitedToCostOfLiving * CostOfLiving, 2);
        return allowance;
    }
    /// <summary>
    /// Total estimated allowance amount
    /// סה"כ סכום הקצבה המשוערת
    /// </summary>
    /// <returns>Total estimated allowance amount</returns>
    public virtual double TotalEstimatedAllowanceAmount(BudgetPensionEmployee employee)
        => CostOfLivingAllowance(employee) * AllowanceAmount(employee);

}
