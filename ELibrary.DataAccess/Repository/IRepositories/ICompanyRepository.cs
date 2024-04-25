using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface ICompanyRepository : IRepository<Company>
{
    void Update(Company company);
}
