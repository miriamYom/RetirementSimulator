namespace BL.Pension;

public interface IPensionFactory
{
    string Create(string pensionType, object employee);
}