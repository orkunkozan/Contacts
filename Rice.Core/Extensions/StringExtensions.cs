using Microsoft.EntityFrameworkCore;
using Rice.Core.Context.Abstraction;

namespace Rice.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GeneratePublishName(this IPublishEntity entity, EntityState entityState)
        {
            return entity.GetType().FullName + "_" + entityState;
        }
    }
}
