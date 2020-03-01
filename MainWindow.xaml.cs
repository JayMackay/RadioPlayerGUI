using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace RadioApplication
{
    public partial class MainWindow : Window, INotifyPropertyChanged 
    {
        //OBJECT INITIALIZATION
        private ObservableCollection<ChannelModel> currentChannel = new ObservableCollection<ChannelModel>();
        Radio radio = new Radio();

        public MainWindow()
        {
            InitializeComponent();
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.Gray, ChannelName = "Channel One" });
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.CornflowerBlue, ChannelName = "Channel Two" });
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.CadetBlue, ChannelName = "Channel Three" });
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.LightBlue, ChannelName = "Channel Four" });
        }

        //CHANNEL COLLECTION
        public ObservableCollection<ChannelModel> CurrentChannel 
        { 
            get { return currentChannel; }
            set
            {
                currentChannel = value;
                NotifyPropertyChanged("CurrentChannel");
            }
        }

        //CHANNEL EVENT HANDLER
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //CHANNEL ONE (BBC RADIO ONE)
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p", UriKind.RelativeOrAbsolute);
            Player.Play();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SkipPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SkipNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
