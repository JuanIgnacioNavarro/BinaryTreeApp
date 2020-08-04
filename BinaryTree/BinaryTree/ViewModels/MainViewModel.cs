using BinaryTree.Views;

namespace BinaryTree.ViewModels
{
    public class MainViewModel
    {
        #region PROPERTIES
        public CreateTreeViewModel CreateTree
        {
            get;
            set; 
        }
        #endregion

        #region CONSTRUCTOR
        public MainViewModel()
        {
            this.CreateTree = new CreateTreeViewModel();
        }
        #endregion
    }
}
