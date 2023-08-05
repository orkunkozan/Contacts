using Rice.Core.Context.Model;

namespace Rice.Core.Services.EntityChangeServices
{
    public class EntityChangeServices : IEntityChangeServices
    {
        public EntityChangeServices( )
        { 
        }

        public List<ChangeEntityModel> ChangeEntriesList { get; set; } = new();

    }
}
