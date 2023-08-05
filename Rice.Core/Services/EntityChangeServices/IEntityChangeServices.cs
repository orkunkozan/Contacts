using Rice.Core.Context.Model;

namespace Rice.Core.Services.EntityChangeServices
{
    public interface IEntityChangeServices
    {

        public List<ChangeEntityModel> ChangeEntriesList { get; set; }
    }
}
