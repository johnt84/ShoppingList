using Dapper;
using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingListBlazorWasm.Server.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly SqlConnectionConfiguration _configuration;

        private IDbConnection Connection => new SqlConnection(_configuration.Value);

        public ShoppingListService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ShoppingList> Get()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var shoppingListItems = connection.
                                            Query<ShoppingList>(
                                                "procShoppingListsGet",
                                                commandType: CommandType.StoredProcedure).
                                            ToList();


                return shoppingListItems;
            }
        }

        public ShoppingList Get(int shoppingListID)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var shoppingList = connection.
                                            Query<ShoppingList>(
                                                "procShoppingListsGet",
                                                new { shoppingListID },
                                                commandType: CommandType.StoredProcedure).
                                            FirstOrDefault();


                return shoppingList;
            }
        }

        public void Add(ShoppingList shoppingList)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"exec procShoppingListCreate 
                                        @shoppingDate, 
                                        @totalAmount, 
                                        @userID,
                                        @copyShoppingListID";

                try
                {
                    int newShoppingListItemID = connection.
                                                    Query<int>(query, shoppingList).
                                                    Single();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Update(ShoppingList shoppingList)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"exec procShoppingListUpdate  
                                        @shoppingListID, 
                                        @shoppingDate, 
                                        @totalAmount, 
                                        @dateCreated, 
                                        @userID";

                try
                {
                    connection.Query<int>(query, shoppingList);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Delete(int shoppingListID)
        {
            using (IDbConnection connection = Connection)
            {
                string query = "exec procShoppingListDelete @shoppingListID";

                connection.Query<int>(query, shoppingListID);
            }
        }
    }
}
