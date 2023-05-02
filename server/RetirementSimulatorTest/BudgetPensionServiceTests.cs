

using DL.Tables;
using System.Data;

namespace RetirementSimulatorTest;

[TestClass]
public class BudgetPensionServiceTests
{
    [TestMethod]
    public void TestMethod1()
    {
        BudgetPensionService service = new BudgetPensionService();
        DataTable table = ReadFromExcel.RaedToTable("S:/exel/e1.csv");
        DataTable table2 = ReadFromExcel.RaedToTable("S:/exel/e2.csv");

        var actual = service.AveragePartTimeJobForRetirement(table2);
        Assert.AreEqual(actual, 31);
        //Assert.AreSame(table2, actual);
    }

}