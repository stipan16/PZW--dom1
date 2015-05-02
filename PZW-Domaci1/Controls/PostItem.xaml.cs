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

namespace PZW_Domaci1.Controls
{
    /// <summary>
    /// Interaction logic for PostItem.xaml
    /// </summary>
    public partial class PostItem : UserControl
    {
        public PostItem()
        {
            InitializeComponent();
        }

        

        public string PostText
        {
            get { return (string)GetValue(PostTextProperty); }
            set { SetValue(PostTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PostText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostTextProperty =
            DependencyProperty.Register("PostText", typeof(string), typeof(PostItem), new PropertyMetadata("PostText"));




        public string PostDugiText
        {
            get { return (string)GetValue(PostDugiTextProperty); }
            set { SetValue(PostDugiTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PostDugiText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostDugiTextProperty =
            DependencyProperty.Register("PostDugiText", typeof(string), typeof(PostItem), new PropertyMetadata("PostDugiText"));



        public string PostSlika
        {
            get { return (string)GetValue(PostSlikaProperty); }
            set { SetValue(PostSlikaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PostSlika.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostSlikaProperty =
            DependencyProperty.Register("PostSlika", typeof(string), typeof(PostItem), new PropertyMetadata("PostSlika"));

         


        public static RoutedEvent DeletePostEvent = EventManager.RegisterRoutedEvent(
           "DeletePost",
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(PostItem)
           );

        public static RoutedEvent EditPostEvent = EventManager.RegisterRoutedEvent(
            "EditPost",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(PostItem)
            );


        public event RoutedEventHandler EditPost
        {
            add { AddHandler(EditPostEvent, value); }
            remove { RemoveHandler(EditPostEvent, value); }
        }

        public event RoutedEventHandler DeletePost
        {
            add { AddHandler(DeletePostEvent, value); }
            remove { RemoveHandler(DeletePostEvent, value); }
        }

        void RaiseDeletePostEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(PostItem.DeletePostEvent);
            RaiseEvent(newEventArgs);
        }

        void RaiseEditPostEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(PostItem.EditPostEvent);
            RaiseEvent(newEventArgs);
        }
        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeletePostIcon.MouseDown += new MouseButtonEventHandler(DeletePostIcon_MouseDown);
            this.EditPostIcon.MouseDown += new MouseButtonEventHandler(EditPostIcon_MouseDown);
        }

        private void DeletePostIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeletePostEvent();
        }

        private void EditPostIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditPostEvent();
        }
    }
}
