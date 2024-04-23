using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public sealed class ApplicationUserRepository(DataContext dataContext) : Repository<ApplicationUser>(dataContext), IApplicationUserRepository
{
}