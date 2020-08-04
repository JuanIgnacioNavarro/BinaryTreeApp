using System;
namespace BinaryTree.ViewModels
{
    public class MainViewModel
    {
        #region ATTRIBUTES

        private static MainViewModel instance;

        #endregion


        #region VIEWMODELS
        public CreateTreeViewModel CreateTree { get; set; }

        public VisualTreeViewModel VisualTree { get; set; }

        #endregion


        public MainViewModel()
        {
            instance = this;
            this.CreateTree = new CreateTreeViewModel();
        }

        //SINGLETON (instance is never null)
        public static MainViewModel getInstance()
        {
            return instance;
        }
    }
}
