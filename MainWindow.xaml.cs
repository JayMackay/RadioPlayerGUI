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
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.Gray, ChannelName = "Channel 1" });
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.CornflowerBlue, ChannelName = "Channel 2" });
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.CadetBlue, ChannelName = "Channel 3" });
            CurrentChannel.Add(new ChannelModel() { Brush = Brushes.LightBlue, ChannelName = "Channel 4" });
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

        //RADIO PLAYER FUNCTIONALITY
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //CHANELL BUTTON FUNCTIONALITY

        //BBC Radio One
        private void ChannelOne_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p", UriKind.RelativeOrAbsolute);
            Player.Play();
        }

        //BBC Radio Two
        private void ChannelTwo_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p", UriKind.RelativeOrAbsolute);
            Player.Play();
        }

        //BBC Radio Three
        private void ChannelThree_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p", UriKind.RelativeOrAbsolute);
            Player.Play();
        }

        //BBC Radio Four    
        private void ChannelFour_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4fm_mf_p", UriKind.RelativeOrAbsolute);
            Player.Play();
        }
    }
}
