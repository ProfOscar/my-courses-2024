using System.Data;

namespace MyCourses.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        Task<DataSet> QueryAsync(FormattableString sql);
    }
}