using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras.Data;

public static class Database
{
    private static SQLiteDatabaseHelper? _database;

    public static SQLiteDatabaseHelper Current
    {
        get
        {
            if (_database is null)
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "minhascompras.db3");
                _database = new SQLiteDatabaseHelper(path);
            }

            return _database;
        }
    }
}
