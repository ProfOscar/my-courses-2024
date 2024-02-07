using System.Data;
using System.Data.SqlClient;

namespace MyCourses.Models.Services.Infrastructure
{
    public class SqlServerDabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string sql)
        {
            string connStr = "Server=127.0.0.1,1433; Database=MyCourses.DB; User ID=sa; Password=My1Courses!;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
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