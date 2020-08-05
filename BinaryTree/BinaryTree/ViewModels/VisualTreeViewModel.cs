using System.Windows.Input;
using BinaryTree.Models;
using BinaryTree.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BinaryTree.ViewModels
{
    public class VisualTreeViewModel: BaseViewModel
    {

        #region ATTRIBUTES

        //NODE
        private Node father;

        //TEXT
        private string fatherNodeText;

        private string leftNodeText;

        private string rightNodeText;

        private string inOrderText;

        private string preOrderText;

        private string postOrderText;

        private string depthText1;

        private string depthText2;

        //BOOLEAN
        private bool isVisibleLeft;

        private bool isVisibleRight;

        private bool hasChilren;
        #endregion


        #region PROPERTIES

        //TEXT
        public string FatherNodeText
        {
            get { return this.fatherNodeText; }
            set { SetValue(ref this.fatherNodeText, value); }
        }

        public string LeftNodeText
        {
            get { return this.leftNodeText; }
            set { SetValue(ref this.leftNodeText, value); }
        }

        public string RightNodeText
        {
            get { return this.rightNodeText; }
            set { SetValue(ref this.rightNodeText, value); }
        }

        public string InOrderText
        {
            get { return this.inOrderText; }
            set { SetValue(ref this.inOrderText, value); }
        }

        public string PreOrderText 
        {
            get { return this.preOrderText; }
            set { SetValue(ref this.preOrderText, value); }
        }

        public string PostOrderText 
        {
            get { return this.postOrderText; }
            set { SetValue(ref this.postOrderText, value); }
        }

        public string DepthText1 
        {
            get { return this.depthText1; }
            set { SetValue(ref this.depthText1, value); }
        }

        public string DepthText2
        {
            get { return this.depthText2; }
            set { SetValue(ref this.depthText2, value); }
        }


        //BOOLEAN
        public bool IsVisibleLeft
        {
            get { return this.isVisibleLeft; }
            set { SetValue(ref this.isVisibleLeft, value); }
        }

        public bool IsVisibleRight
        {
            get { return this.isVisibleRight; }
            set { SetValue(ref this.isVisibleRight, value); }
        }

        public bool HasChildren
        {
            get { return this.hasChilren; }
            set { SetValue(ref this.hasChilren, value); }
        }

        //COMMAND
        public ICommand LeftNodeCommand
        {
            get { return new RelayCommand(LeftNode); }
        }

        public ICommand RightNodeCommand
        {
            get { return new RelayCommand(RightNode); }
        }


        #endregion

        public VisualTreeViewModel(Node father, int depth)
        {
            this.DepthText1 = depth.ToString();
            this.DepthText2 = (depth + 1).ToString();
            this.father = father;

            this.FatherNodeText = this.father.Value.ToString();

            if (this.father.Left != null)
            {
                this.LeftNodeText = this.father.Left.Value.ToString();
                this.IsVisibleLeft = true;
            }

            if (this.father.Right != null)
            {
                this.RightNodeText = this.father.Right.Value.ToString();
                this.IsVisibleRight = true;
            }

            if (this.IsVisibleRight || this.IsVisibleRight)
            {
                this.HasChildren = true;
            }
            
            this.PrintInOrder(CreateTreeViewModel.rootStatic);
            this.PrintPreOrder(CreateTreeViewModel.rootStatic);
            this.PrintPostOrder(CreateTreeViewModel.rootStatic);
        }

        #region METHODS

        private async void LeftNode()
        {
            int newDepth = System.Int32.Parse(this.DepthText2);
            MainViewModel.getInstance().VisualTree = new VisualTreeViewModel(this.father.Left, newDepth);
            await Application.Current.MainPage.Navigation.PushAsync(new VisualTreePage());
        }

        private async void RightNode()
        {
            int newDepth = System.Int32.Parse(this.DepthText2);
            MainViewModel.getInstance().VisualTree = new VisualTreeViewModel(this.father.Right, newDepth);
            await Application.Current.MainPage.Navigation.PushAsync(new VisualTreePage());
        }

        private void PrintInOrder(Node node)
        {
            if (node == null)
                return;

            PrintInOrder(node.Left);

            this.InOrderText += node.Value + ", ";

            PrintInOrder(node.Right);
        }

        private void PrintPreOrder(Node node)
        {
            if (node == null)
                return;

            this.PreOrderText += node.Value + ", ";

            PrintPreOrder(node.Left);

            PrintPreOrder(node.Right);
        }

        private void PrintPostOrder(Node node)
        {
            if (node == null)
                return;

            PrintPostOrder(node.Left);

            PrintPostOrder(node.Right);

            this.PostOrderText += node.Value + ", ";
        }
        #endregion
    }
}
