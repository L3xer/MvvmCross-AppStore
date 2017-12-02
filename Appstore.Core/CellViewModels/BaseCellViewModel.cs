namespace Appstore.Core.CellViewModels
{
    public class BaseCellViewModel<T, K>
    {
        public T ViewModel { get; set; }
        public K Item { get; set; }
    }
}
