using System.Data;

namespace MyCourses.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        DataSet Query(FormattableString sql);
    }
}