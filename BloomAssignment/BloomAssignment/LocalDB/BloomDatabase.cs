using BloomAssignment.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomAssignment.LocalDB
{
   public class BloomDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        public BloomDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(LocalItemsModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(LocalItemsModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
        public Task<int> SaveItemAsync(LocalItemsModel item)
        {
                if (item.ItemId != 0)
                {
                    return Database.UpdateAsync(item);
                }
                else
                {
                    return Database.InsertAsync(item);
                }
        }
        public async Task<List<LocalItemsModel>> GetItemsAsync()
        {
            return await Database.Table<LocalItemsModel>().ToListAsync();
        }
    }
}
