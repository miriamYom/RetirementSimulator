using BL.DTO;

namespace BL.PensionServices;
    internal class PensionService
{
    public static double ReturnDouble(Employee emp)
    {
        return emp.NumberOfDaysOfRecoveryToBePaid;
    }
}

