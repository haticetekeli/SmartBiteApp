using SmartBite.Core.ResponseManager;
using SmartBite.DataAccess.Repositories.Abstract;
using System.Data;

namespace SmartBite.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void OpenTransaction();
        void OpenTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
        int SaveChanges();
        Task<BaseResponseModel<int>> SaveChangesAsync();
        TRepo Repository<TRepo>() where TRepo : IBaseRepository;
    }
}
