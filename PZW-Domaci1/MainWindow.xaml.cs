using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PZW_Domaci1.Controls;

namespace PZW_Domaci1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //this.LiviBotun.Click += new RoutedEventHandler(LiviBotun_Click);
           // this.DesniBotun.Click += new RoutedEventHandler(DesniBotun_Click);


            
            var mainchild = this.mainBorder.Child;
                var userMainItem = mainchild as UserItem;
                userMainItem.Delete += OnUserItem_Delete;
                userMainItem.Edit += OnUserItem_Edit;
                userMainItem.UserSlika = "/Resources/Users/Lobo.jpg";
                userMainItem.UserText = "Lobo";
            

            foreach (var child in this.LiviRectangleContainer.Children)
            {
                if (!(child is UserItem)) { continue; }
                var userItem = child as UserItem;
                userItem.Delete += OnUserItem_Delete;
                userItem.Edit += OnUserItem_Edit;
                userItem.UserSlika = "/Resources/Users/Lobo.jpg";
                userItem.UserText = "Lobo";
            }

            foreach (var child in this.DesniRectangleContainer.Children)
            {
                if (!(child is PostItem)) { continue; }
                var postItem = child as PostItem;
                postItem.DeletePost += OnPostItem_Delete;
                postItem.EditPost += OnPostItem_Edit;
                postItem.PostText = "Joker";
                postItem.PostDugiText = "Dobro Došli";
                postItem.PostSlika = "/Resources/Users/joker.jpg";
            }

        }

        private void OnPostItem_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is PostItem)) { return; }
            var postItem = sender as PostItem;
            int index = this.DesniRectangleContainer.Children.IndexOf(postItem);

            postItem.PostText = "Lobo";
            postItem.PostDugiText = "hej pa može to puno bolje";
            postItem.PostSlika = "/Resources/Users/Lobo.jpg";

           
        }

        private void OnPostItem_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is PostItem)) { return; }
            var postItem = sender as PostItem;
            
            this.DesniRectangleContainer.Children.Remove(postItem);

        }

        private void OnUserItem_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is UserItem)) { return; }
            var userItem = sender as UserItem;
            int index = this.LiviRectangleContainer.Children.IndexOf(userItem);
            userItem.UserText = "Joker";
            userItem.UserSlika="/Resources/Users/joker.jpg";
            
           
        }

        void OnUserItem_Delete(object sender,RoutedEventArgs e)
        {
            if (!(sender is UserItem)) { return; }
            var userItem = sender as UserItem;
            this.LiviRectangleContainer.Children.Remove(userItem);
        }

        private void LiviBotun_Click_1(object sender, RoutedEventArgs e)
        {
            //kreirat objekt i spremit ga u memoriju
            UserItem user = new UserItem();
            //dodat eventove
            user.Delete += OnUserItem_Delete;
            user.Edit += OnUserItem_Edit;
            user.UserSlika = "/Resources/Users/likeASir.jpeg";
            user.UserText = "Like a Sir";
            //prikazat ga
            LiviRectangleContainer.Children.Add(user);
        }

        private void DesniBotun_Click_1(object sender, RoutedEventArgs e)
        {
            PostItem post = new PostItem();
            post.DeletePost += OnPostItem_Delete;
            post.EditPost += OnPostItem_Edit;
            post.PostText = "Seljak";
            post.PostDugiText = "Jeste li spremni";
            post.PostSlika = "/Resources/Users/Seljak.jpg";
            DesniRectangleContainer.Children.Add(post);
        }
    }
}
