using System;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using Scaffolding.DetailCollections.Common.Utils;
using Scaffolding.DetailCollections.Common.DataModel;

namespace Scaffolding.DetailCollections.Common.ViewModel {
    public partial class ReadOnlyLookUpCollectionViewModel<TMasterEntity, TEntity, TUnitOfWork> : ReadOnlyLookUpCollectionViewModelBase<TMasterEntity, TEntity, TUnitOfWork>
        where TMasterEntity : class
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {
        public ReadOnlyLookUpCollectionViewModel(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IReadOnlyRepository<TEntity>> getRepositoryFunc, Expression<Func<TEntity, bool>> filterExpression)
            : base(unitOfWorkFactory, getRepositoryFunc, filterExpression) {
        }
    }
    public abstract class ReadOnlyLookUpCollectionViewModelBase<TMasterEntity, TEntity, TUnitOfWork> : ReadOnlyCollectionViewModel<TEntity, TUnitOfWork>
        where TMasterEntity : class
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        public ReadOnlyLookUpCollectionViewModelBase(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IReadOnlyRepository<TEntity>> getRepositoryFunc, Expression<Func<TEntity, bool>> filterExpression)
            : base(unitOfWorkFactory, getRepositoryFunc, filterExpression) {
        }
    }
}