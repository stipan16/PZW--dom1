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
    /// Interaction logic for UserItem.xaml
    /// </summary>
    public partial class UserItem : UserControl
    {
        public UserItem()
        {
            InitializeComponent();
        }


        public string UserSlika
        {
            get { return (string)GetValue(UserSlikaProperty); }
            set { SetValue(UserSlikaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserSlika.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserSlikaProperty =
            DependencyProperty.Register("UserSlika", typeof(string), typeof(UserItem), new PropertyMetadata("UserSlika"));



        public string UserText
        {
            get { return (string)GetValue(UserTextProperty); }
            set { SetValue(UserTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserTextProperty =
            DependencyProperty.Register("UserText", typeof(string), typeof(UserItem), new PropertyMetadata("UserText"));

        
                      
        public static RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent(
            "Delete",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(UserItem)
            );

        public static RoutedEvent EditEvent = EventManager.RegisterRoutedEvent(
            "Edit",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(UserItem)
            );


        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        public event RoutedEventHandler Delete
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(UserItem.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(UserItem.EditEvent);
            RaiseEvent(newEventArgs);
        }
        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += new MouseButtonEventHandler(DeleteIcon_MouseDown);
            this.EditIcon.MouseDown += new MouseButtonEventHandler(EditIcon_MouseDown);
        }

        private void DeleteIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

        private void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }
    }
}
