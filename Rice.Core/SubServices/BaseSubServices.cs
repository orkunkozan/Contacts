using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Rice.Core.Context.Abstraction;

namespace Rice.Core.SubServices
{
    public class BaseSubServices<TContext> : ICapSubscribe where TContext : DbContext, ISubscribeDbContext
    {
        protected readonly TContext _context;
        protected BaseSubServices(ISubscribeDbContext context)
        {
            _context = (TContext)context;
        }
    }
}
