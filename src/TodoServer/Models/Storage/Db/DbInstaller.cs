using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.IO;


namespace TodoServer.Models.Storage.Db
{
  public class DbInstaller
  {
    public static void Install(TodoStorageSettings settings)
    {
      if (!File.Exists(settings.SqlInstallFileName))
        return; // That's mean that a sql install file has been installed because after installation the file should delete

      var sql = File.ReadAllText(settings.SqlInstallFileName).Replace("__DBNAME__", settings.DbName);
      var server = new Server(new ServerConnection(new SqlConnection(settings.ConnectionString)));
      server.ConnectionContext.ExecuteNonQuery(sql);

      File.Move(settings.SqlInstallFileName, settings.SqlInstallFileName + ".executed");
    }
  }
}
