using Rice.Core.Context.Abstraction;

namespace Rice.Core.SubServices.Abstraction
{
    public interface ISubscribeEntityWriteOpreation<TReadOnlyEntity> where TReadOnlyEntity : IReadOnlyEntity
    {
        public Task Added(TReadOnlyEntity entity);
        public Task Updated(TReadOnlyEntity entity);
        public Task Deleted(TReadOnlyEntity entity);
    }
}
