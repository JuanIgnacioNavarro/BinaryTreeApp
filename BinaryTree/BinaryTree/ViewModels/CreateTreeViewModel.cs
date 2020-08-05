using System;
using System.Windows.Input;
using BinaryTree.Models;
using BinaryTree.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BinaryTree.ViewModels
{
    public class CreateTreeViewModel: BaseViewModel
    {

        #region ATTRIBUTES
        public static Node rootStatic;

        Node root;

        private string numberText;

        #endregion


        #region PROPERTIES

        //TEXT
        public string NumberText
        {
            get { return this.numberText; }
            set { SetValue(ref this.numberText, value); }
        }

        //COMMAND
        public ICommand VisualTreeCommand
        {
            get { return new RelayCommand(VisualTree); }
        }

        //COMMAND
        public ICommand AddNodeCommand
        {
            get { return new RelayCommand(AddNode); }
        }


        #endregion


        #region METHODS

        private async void VisualTree()
        {
            if (this.root != null)
            {
                MainViewModel.getInstance().VisualTree = new VisualTreeViewModel(this.root);
                await Application.Current.MainPage.Navigation.PushAsync(new VisualTreePage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No elements in the tree", "Add new elements in the button of the page", "Ok");
            }

        }

        private async void AddNode()
        {
            int nodeValue;

            try
            {
                nodeValue = int.Parse(this.NumberText);
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a valid number", "Ok");
                return;
            }

            if (this.root == null)
            {
                this.root = new Node(nodeValue);
                rootStatic = this.root;
            }
            else
            {
                Node father = this.root;

                while (nodeValue != father.Value)
                {
                    if (nodeValue < father.Value)
                    {
                        if (father.Left == null)
                        {
                            father.Left = new Node(nodeValue);
                            break;
                        }
                        else
                        {
                            father = father.Left;
                        }
                    }
                    else
                    {
                        if (father.Right == null)
                        {
                            father.Right = new Node(nodeValue);
                            break;
                        }
                        else
                        {
                            father = father.Right;
                        }
                    }
                }
            }

            this.NumberText = string.Empty;
        }

        #endregion
    }
}
