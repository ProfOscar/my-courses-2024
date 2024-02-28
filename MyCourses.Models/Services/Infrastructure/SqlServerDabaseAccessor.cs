using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyCourses.Models.Services.Infrastructure
{
    public class SqlServerDabaseAccessor : IDatabaseAccessor
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<SqlServerDabaseAccessor> logger;

        public SqlServerDabaseAccessor(IConfiguration configuration, ILogger<SqlServerDabaseAccessor> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<DataSet> QueryAsync(FormattableString formattableQuery)
        {
            var queryArguments = formattableQuery.GetArguments();
            logger.LogInformation(formattableQuery.Format, queryArguments);
            var sqlParameters = new List<SqlParameter>();
            for (int i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new SqlParameter(i.ToString(), queryArguments[i]);
                sqlParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }
            string sql = formattableQuery.ToString();

            // string connStr = Configuration.GetConnectionString("Default")!;
            string connStr = configuration["ConnectionStrings:Default"]!;
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