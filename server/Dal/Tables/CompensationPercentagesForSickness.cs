﻿namespace DL.Tables;

public class CompensationPercentagesForSickness
{
    static string PATH = "../../../אחוזי פיצוי לפדיון מחלה.csv";
    public Dictionary<int, string> AgesAndPercentsAccrualPension { get; }
    public Dictionary<int, string> AgesAndPercentsBudgetePension { get; }

    /// <summary>
    /// The ctor initializes the 2 dictionaries with the values it receives from data tables. 
    /// Key: age of the employee, 
    /// value: percentage of compensation for sickness benefits.
    /// One dictionary for budget pension and a second dictionary for accrued pension.
    /// Singleton class.
    /// </summary>
    public CompensationPercentagesForSickness()
    {
        AgesAndPercentsAccrualPension = new Dictionary<int, string>();
        AgesAndPercentsBudgetePension = new Dictionary<int, string>();

        DataTable dataTable = ReadFromExcel.RaedToTable(PATH);

        foreach (DataRow row in dataTable.Rows)
        {
            AgesAndPercentsAccrualPension.Add(Convert.ToInt16(row[0]), Convert.ToString(row[2]));
            AgesAndPercentsBudgetePension.Add(Convert.ToInt16(row[0]), Convert.ToString(row[1]));
        }

    }


}
