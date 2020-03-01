using System.Windows.Media;

namespace RadioApplication
{
    public class ChannelModel
    {
        //FIELDS
        private string channelName = "";
        private Brush brush = Brushes.Transparent;

        //PROPERTIES
        public string ChannelName { get => channelName; set => channelName = value; }
        public Brush Brush { get => brush; set => brush = value; }

        //CHANNEL MODEL CONSTRUCTOR
        public ChannelModel()
        {
        }
    }
}
