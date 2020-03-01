using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

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
            radio.Read(); //Deserialize
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

        //======================RADIO PLAYER FUNCTIONALITY======================

        //POWER ON
        private void PowerOnButton_Click(object sender, RoutedEventArgs e)
        {
            radio.PowerOn();
            RadioState.Text = $"{radio.PowerOn()}";
        }

        //POWER OFF
        private void PowerOffButton_Click(object sender, RoutedEventArgs e)
        {
            radio.PowerOff();
            RadioState.Text = $"{radio.PowerOff()}";
            Player.Stop();
            RadioStation.Text = "FM Radio";
            radio.Write(); //SERIALIZE
        }


        //PLAY RADIO BUTTON
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            radio.Play();
            RadioState.Text = $"{radio.Play()}";
            if (radio.on == true)
            {
                Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p", UriKind.RelativeOrAbsolute);
                Player.Play();
                RadioStation.Text = "BBC Radio One";
            }

        }

        //STOP RADIO BUTTON
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
            RadioState.Text = $"{radio.Stop()}";
        }

        //VOLUME SLIDER FUNCTIONALITY
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Volume = volumeSlider.Value;
            radio.Volume = volumeSlider.Value;
        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            Player.IsMuted = !Player.IsMuted;
        }

        //======================CHANNEL BUTTON FUNCTIONALITY======================

        //BBC Radio One
        private void ChannelOne_Click(object sender, RoutedEventArgs e)
        {
            radio.Channel = 1;
            RadioState.Text = $"{radio.Play()}";
            if(radio.on == true)
            {
                Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p", UriKind.RelativeOrAbsolute);
                Player.Play();
                RadioStation.Text = "BBC Radio One";
            }
        }

        //BBC Radio Two
        private void ChannelTwo_Click(object sender, RoutedEventArgs e)
        {
            radio.Channel = 2;
            RadioState.Text = $"{radio.Play()}";
            if (radio.on == true)
            {
                Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p", UriKind.RelativeOrAbsolute);
                Player.Play();
                RadioStation.Text = "BBC Radio Two";
            }
        }

        //BBC Radio Three
        private void ChannelThree_Click(object sender, RoutedEventArgs e)
        {
            radio.Channel = 3;
            RadioState.Text = $"{radio.Play()}";
            if (radio.on == true)
            {
                Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p", UriKind.RelativeOrAbsolute);
                Player.Play();
                RadioStation.Text = "BBC Radio Three";
            }
        }

        //BBC Radio Four    
        private void ChannelFour_Click(object sender, RoutedEventArgs e)
        {
            radio.Channel = 4;
            RadioState.Text = $"{radio.Play()}";
            if (radio.on == true)
            {
                Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4fm_mf_p", UriKind.RelativeOrAbsolute);
                Player.Play();
                RadioStation.Text = "BBC Radio Four";
            }
        }
    }
}
