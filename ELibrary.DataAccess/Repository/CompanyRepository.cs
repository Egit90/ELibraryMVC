using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public sealed class CompanyRepository(DataContext dataContext) : Repository<Company>(dataContext), ICompanyRepository
{
    public void Update(Company company)
    {
        _dataContext.Companies.Update(company);
    }
}