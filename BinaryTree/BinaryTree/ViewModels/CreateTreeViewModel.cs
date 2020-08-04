
using BinaryTree.Models;
using CookTime.ViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BinaryTree.ViewModels
{
    public class CreateTreeViewModel: BaseViewModel
    {
        #region ATTRIBUTES
        private ObservableCollection<Number> items;

        private BinarySearchTree binaryTree;

        private int amount;
        #endregion

        #region PROPERTIES
        public ObservableCollection<Number> Items 
        {
            get { return this.items; }
            set { SetValue(ref this.items, value); }
        }

        public int Amount
        {
            get { return this.amount; }
            set { SetValue(ref this.amount, value); }
        }

        public ICommand IncreaseEntriesCommand 
        {
            get { return new RelayCommand(IncreaseEntries); }
        }

        public ICommand DecreaseEntriesCommand
        {
            get { return new RelayCommand(DecreaseEntries); }
        }

        public ICommand NewTreeCommand
        {
            get { return new RelayCommand(NewTree); }
        }
        #endregion

        #region CONSTRUCTOR
        public CreateTreeViewModel()
        {
            this.Items = new ObservableCollection<Number>()
            {
                new Number{ Value= "21" },
                new Number {Value = "20"}
            };
            //this.Items.Add(new Number { Value = 31 });
            
        }
        #endregion

        #region METHODS

        private void IncreaseEntries()
        {
            this.Items.Add(null);
        }

        private void DecreaseEntries()
        {
            var index = this.Items.Count() - 1;
            this.Items.RemoveAt(index);
        }

        private void NewTree()
        {
            this.binaryTree = new BinarySearchTree();

            foreach (Number number in Items)
            {
                var numberInt = Convert.ToInt32 (number.Value);
                this.binaryTree.Insert(numberInt);

            }

            this.binaryTree.Insert(12);
        }
        #endregion
    }
}
