using System;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Collections.Generic;
using Scaffolding.DetailCollections.Common.Utils;
using Scaffolding.DetailCollections.Common.DataModel;
using Scaffolding.DetailCollections.Common.DataModel.DesignTime;
using Scaffolding.DetailCollections.Common.DataModel.EntityFramework;
using Scaffolding.DetailCollections.Model;
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;

namespace Scaffolding.DetailCollections.DepartmentContextDataModel {
    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource {
        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the current mode (run-time or design-time).
        /// </summary>
        public static IUnitOfWorkFactory<IDepartmentContextUnitOfWork> GetUnitOfWorkFactory() {
            return GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<IDepartmentContextUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime) {
            if(isInDesignTime)
                return new DesignTimeUnitOfWorkFactory<IDepartmentContextUnitOfWork>(() => new DepartmentContextDesignTimeUnitOfWork());
            return new DbUnitOfWorkFactory<IDepartmentContextUnitOfWork>(() => new DepartmentContextUnitOfWork(() => new DepartmentContext()));
        }
    }
}