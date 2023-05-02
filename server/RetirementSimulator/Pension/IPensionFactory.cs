using BL.DTO;
using BL.PensionService;

namespace BL.Pension;

public interface IPensionFactory
{
     string Create(string pensionType, object employee);
}