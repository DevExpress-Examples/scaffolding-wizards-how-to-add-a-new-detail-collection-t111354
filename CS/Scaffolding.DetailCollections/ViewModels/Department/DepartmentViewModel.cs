﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using Scaffolding.DetailCollections.DepartmentContextDataModel;
using Scaffolding.DetailCollections.Common;
using Scaffolding.DetailCollections.Model;

namespace Scaffolding.DetailCollections.ViewModels {

    /// <summary>
    /// Represents the single Department object view model.
    /// </summary>
    public partial class DepartmentViewModel : SingleObjectViewModel<Department, int, IDepartmentContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of DepartmentViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DepartmentViewModel Create(IUnitOfWorkFactory<IDepartmentContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new DepartmentViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the DepartmentViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DepartmentViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DepartmentViewModel(IUnitOfWorkFactory<IDepartmentContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Departments, x => x.Name) {
        }


        /// <summary>
        /// The view model that contains a look-up collection of Courses for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Course> LookUpCourses
        {
            get
            {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (DepartmentViewModel x) => x.LookUpCourses,
                    getRepositoryFunc: x => x.Courses);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Employees for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Employee> LookUpEmployees
        {
            get
            {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (DepartmentViewModel x) => x.LookUpEmployees,
                    getRepositoryFunc: x => x.Employees);
            }
        }


        /// <summary>
        /// The view model for the DepartmentCourses detail collection.
        /// </summary>
        public CollectionViewModelBase<Course, Course, int, IDepartmentContextUnitOfWork> DepartmentCoursesDetails
        {
            get
            {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (DepartmentViewModel x) => x.DepartmentCoursesDetails,
                    getRepositoryFunc: x => x.Courses,
                    foreignKeyExpression: x => x.DepartmentID,
                    navigationExpression: x => x.Department);
            }
        }

        /// <summary>
        /// The view model for the DepartmentEmployees detail collection.
        /// </summary>
        public CollectionViewModelBase<Employee, Employee, int, IDepartmentContextUnitOfWork> DepartmentEmployeesDetails
        {
            get
            {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (DepartmentViewModel x) => x.DepartmentEmployeesDetails,
                    getRepositoryFunc: x => x.Employees,
                    foreignKeyExpression: x => x.DepartmentID,
                    navigationExpression: x => x.Department);
            }
        }
    }
}
