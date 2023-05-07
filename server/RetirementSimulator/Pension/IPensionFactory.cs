using BL.DTO;

namespace BL.Pension;

public interface IPensionFactory
{
    string Create(string pensionType, Employee employee);
}