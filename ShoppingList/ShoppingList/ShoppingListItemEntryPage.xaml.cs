using System;
using System.IO;
using Xamarin.Forms;
using ShoppingList.Models;

namespace ShoppingList
{
    public partial class ShoppingListItemEntryPage : ContentPage
    {
        public ShoppingListItemEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var shoppingListItem = (ShoppingListItem)BindingContext;

            if (string.IsNullOrWhiteSpace(shoppingListItem.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.shoppingList.txt");
                File.WriteAllText(filename, shoppingListItem.Text);
            }
            else
            {
                // Update
                File.WriteAllText(shoppingListItem.Filename, shoppingListItem.Text);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var shoppingListItem = (ShoppingListItem)BindingContext;

            if (File.Exists(shoppingListItem.Filename))
            {
                File.Delete(shoppingListItem.Filename);
            }

            await Navigation.PopAsync();
        }
    }
}