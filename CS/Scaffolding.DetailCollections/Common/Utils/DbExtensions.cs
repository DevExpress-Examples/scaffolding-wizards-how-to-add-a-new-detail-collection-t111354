using System;
using System.Collections;
using System.Linq;

namespace Scaffolding.DetailCollections.Common.Utils {
    public static class DbExtensions {
        public static void Load(this IQueryable source) {
            IEnumerator enumerator = source.GetEnumerator();
            while(enumerator.MoveNext()) {
            }
        }
    }
}
