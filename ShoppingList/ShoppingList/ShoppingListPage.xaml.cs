using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using ShoppingList.Models;

namespace ShoppingList
{
    public partial class ShoppingListPage : ContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var shoppingListItems = new List<ShoppingListItem>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.shoppingList.txt");
            foreach (var filename in files)
            {
                shoppingListItems.Add(new ShoppingListItem
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    CreatedDate = File.GetCreationTime(filename)
                });
            }

            listView.ItemsSource = shoppingListItems
                .OrderBy(d => d.CreatedDate)
                .ToList();
        }

        async void OnShoppingListItemAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListItemEntryPage
            {
                BindingContext = new ShoppingListItem()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ShoppingListItemEntryPage
                {
                    BindingContext = e.SelectedItem as ShoppingListItem
                });
            }
        }
    }
}