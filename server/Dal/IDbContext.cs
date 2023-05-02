
namespace DL;

public interface IDbContext
{
    public IMongoCollection<User> Users();
}
