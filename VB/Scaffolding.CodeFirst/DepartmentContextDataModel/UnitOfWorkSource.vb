﻿Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataModel
Imports DevExpress.Mvvm.DataModel.DesignTime
Imports DevExpress.Mvvm.DataModel.EF6
Imports Scaffolding.CodeFirst.Model
Imports System
Imports System.Collections
Imports System.Linq
Namespace DepartmentContextDataModel
    ''' <summary>
    ''' Provides methods to obtain the relevant IUnitOfWorkFactory.
    ''' </summary>
    Public Module UnitOfWorkSource
        ''' <summary>
        ''' Returns the IUnitOfWorkFactory implementation based on the current mode (run-time or design-time).
        ''' </summary>
        Public Function GetUnitOfWorkFactory() As IUnitOfWorkFactory(Of IDepartmentContextUnitOfWork)
            Return GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode)
        End Function
        ''' <summary>
        ''' Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        ''' </summary>
        ''' <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        Public Function GetUnitOfWorkFactory(ByVal isInDesignTime As Boolean) As IUnitOfWorkFactory(Of IDepartmentContextUnitOfWork)
            If isInDesignTime Then
                Return New DesignTimeUnitOfWorkFactory(Of IDepartmentContextUnitOfWork)(Function() New DepartmentContextDesignTimeUnitOfWork())
            End If
            Return New DbUnitOfWorkFactory(Of IDepartmentContextUnitOfWork)(Function() New DepartmentContextUnitOfWork(Function() New DepartmentContext()))
        End Function
    End Module
End Namespace
