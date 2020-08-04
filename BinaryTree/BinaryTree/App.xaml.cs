using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BinaryTree
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new BinaryTree.Views.CreateTreePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
