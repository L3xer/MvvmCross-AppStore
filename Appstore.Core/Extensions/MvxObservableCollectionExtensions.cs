using MvvmCross.Core.ViewModels;
using System.Collections.Generic;

namespace Appstore.Core.Extensions
{
    public static class MvxObservableCollectionExtensions
    {
        public static void ReplaceRange<T>(this MvxObservableCollection<T> collection, IEnumerable<T> enumerable)
        {
            collection.Clear();
            collection.AddRange(enumerable);
        }
    }
}
