using System.Data;
using System.Data.SqlClient;

namespace MyCourses.Models.Services.Infrastructure
{
    public class SqlServerDabaseAccessor : IDatabaseAccessor
    {
        public async Task<DataSet> QueryAsync(FormattableString formattableQuery)
        {
            var queryArguments = formattableQuery.GetArguments();
            var sqlParameters = new List<SqlParameter>();
            for (int i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new SqlParameter(i.ToString(), queryArguments[i]);
                sqlParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }
            string sql = formattableQuery.ToString();

            string connStr = "Server=127.0.0.1,1433; Database=MyCourses.DB; User ID=sa; Password=My1Courses!;";
            using (var conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(sqlParameters.ToArray());
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataSet dataSet = new DataSet();
                        do
                        {
                            var dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);
                        return dataSet;
                    }
                }
            }
        }
    }
}