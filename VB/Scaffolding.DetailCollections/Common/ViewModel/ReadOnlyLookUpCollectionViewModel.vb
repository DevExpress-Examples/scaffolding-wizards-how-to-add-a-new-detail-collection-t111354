Imports Microsoft.VisualBasic
Imports System
Imports System.Linq.Expressions
Imports DevExpress.Mvvm
Imports Scaffolding.DetailCollections.Common.Utils
Imports Scaffolding.DetailCollections.Common.DataModel

Namespace Scaffolding.DetailCollections.Common.ViewModel
	Partial Public Class ReadOnlyLookUpCollectionViewModel(Of TMasterEntity As Class, TEntity As Class, TUnitOfWork As IUnitOfWork)
		Inherits ReadOnlyLookUpCollectionViewModelBase(Of TMasterEntity, TEntity, TUnitOfWork)
		Public Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal filterExpression As Expression(Of Func(Of TEntity, Boolean)))
			MyBase.New(unitOfWorkFactory, getRepositoryFunc, filterExpression)
		End Sub
	End Class
	Public MustInherit Class ReadOnlyLookUpCollectionViewModelBase(Of TMasterEntity As Class, TEntity As Class, TUnitOfWork As IUnitOfWork)
		Inherits ReadOnlyCollectionViewModel(Of TEntity, TUnitOfWork)

		Public Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal filterExpression As Expression(Of Func(Of TEntity, Boolean)))
			MyBase.New(unitOfWorkFactory, getRepositoryFunc, filterExpression)
		End Sub
	End Class
End Namespace