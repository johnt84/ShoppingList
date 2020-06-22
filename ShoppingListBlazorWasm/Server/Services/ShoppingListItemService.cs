using Dapper;
using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingListBlazorWasm.Server.Services
{
    public class ShoppingListItemService : IShoppingListItemService
    {
        private readonly SqlConnectionConfiguration _configuration;

        private IDbConnection Connection => new SqlConnection(_configuration.Value);

        public ShoppingListItemService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ShoppingListItem> Get(int shoppingListID)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var shoppingListItems = connection.
                                            Query<ShoppingListItem>(
                                                "procShoppingListItemsGet",
                                                new { shoppingListID },
                                                commandType: CommandType.StoredProcedure).
                                            ToList();


                return shoppingListItems;
            }
        }

        public ShoppingListItem GetItem(int shoppingListItemID)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var shoppingListItem = connection.
                                            Query<ShoppingListItem>(
                                                "procShoppingListItemsGet",
                                                new { shoppingListItemID },
                                                commandType: CommandType.StoredProcedure).
                                            FirstOrDefault();


                return shoppingListItem;
            }
        }

        public void Add(ShoppingListItem shoppingListItem)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"exec procShoppingListItemCreate 
                                        @shoppingListID, 
                                        @itemName, 
                                        @price, 
                                        @quantity, 
                                        @itemPicked";

                try
                {
                    int newShoppingListItemID = connection.
                                                    Query<int>(query, shoppingListItem).
                                                    Single();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Update(ShoppingListItem shoppingListItem)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"exec procShoppingListItemUpdate 
                                        @shoppingListItemID, 
                                        @shoppingListID, 
                                        @itemName, 
                                        @price, 
                                        @quantity, 
                                        @itemPicked";

                try
                {
                    connection.Query<int>(query, shoppingListItem);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Delete(int shoppingListItemID)
        {
            using (IDbConnection connection = Connection)
            {
                string query = "exec procShoppingListItemDelete @shoppingListItemID";

                connection.Query<int>(query, new { shoppingListItemID = shoppingListItemID });
            }
        }
    }
}
