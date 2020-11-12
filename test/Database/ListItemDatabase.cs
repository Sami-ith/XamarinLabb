using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using test;

namespace List
{
    public class ListItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        internal Task GetNotesAsync()
        {
            throw new NotImplementedException();
        }

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ListItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ListItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ListItem)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<ListItem>> GetItemsAsync()
        {
            return Database.Table<ListItem>().ToListAsync();
        }

        public Task<List<ListItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<ListItem>("SELECT * FROM [ListItem]");
        }

        internal Task SaveItemAsync(string cname)
        {
            throw new NotImplementedException();
        }

        public Task<ListItem> GetItemAsync(int id)
        {
            return Database.Table<ListItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ListItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ListItem item)
        {
            return Database.DeleteAsync(item);
        }
        
    }
}


/*
var saveButton = new Button { Text = "Save" };
saveButton.Clicked += async (sender, e) =>
{
    var todoItem = (TodoItem)BindingContext;
    await App.Database.SaveItemAsync(todoItem);
    await Navigation.PopAsync();
};
 * 
 */
