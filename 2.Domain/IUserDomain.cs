using _3.Data.Models;

namespace _2.Domain;

public interface IUserDomain
{
    Task<int> SaveAsync(User data);
}