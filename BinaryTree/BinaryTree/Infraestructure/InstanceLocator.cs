
using BinaryTree.ViewModels;

namespace BinaryTree.Infraestructure
{
    public class InstanceLocator
    {
        #region PROPERTIES
        public MainViewModel Main
        {
            get;
            set;
        }

        #endregion

        #region CONTRUCTOR
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
