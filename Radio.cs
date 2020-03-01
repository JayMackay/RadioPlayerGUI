using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioApplication
{
    [Serializable]
    class Radio
    {
        //FIELDS
        private int _channel = 1;
        private bool _on = false;
        private double _volume = 25;
        private string path = @"C:\Users\Jarvis\Desktop\RadioApplication\RadioStateConfig\RadioState.json";

        //CHANNEL PROPERTY
        public int Channel
        {
            get { return _channel; }
            set
            {
                if (value <= 4 && value > 0 && _on == true)
                {
                    _channel = value;
                }
            }
        }

        //RADIO ON PROPERTY
        public bool on
        {
            get { return _on; }
            set { on = _on; }
        }

        //POWER ON METHOD
        public string PowerOn()
        {
            _on = true;
            return "Radio is on";
        }

        //POWER OFF METHOD
        public string PowerOff()
        {
            _on = false;
            return "Radio is off";
        }

        //VOLUME PROPERTY
        public double Volume
        {
            get { return _volume; }
            set
            {
                if(value >= 0 && value <= 50 && _on == true)
                {
                    _volume = value;
                }
            }
        }

        //READ CHANNEL METHOD FOR SERIALIZATION 
        public int readChannel
        {
            get { return _channel; }
            set
            {
                if(value <= 4 && value > 0)
                {
                    _channel = value;
                }

            }
        }

        //READ VOLUME METHOD FOR SERIALIZATION
        public double readVolume
        {
            get { return _volume; }
            set
            {
                if(value >= 0 && value <= 50)
                {
                    _volume = value;
                }
            }
        }

        //PLAY METHOD
        public string Play()
        {
            int channelNumber = _channel;

            if(_on == true)
            {
                return $"Radio is on & playing on channel {channelNumber}";
            }
            else
            {
                return "Please turn on the radio to play music";
            }

        }

        //STOP METHOD
        public string Stop()
        {
            int channelNumber = _channel;

            if(_on == true)
            {
                return $"Radio is currently paused on channel {channelNumber}";
            }
            else
            {
                return "Radio is off";
            }
        }

        //VOLUME CONTROL
        public double volumeControl()
        {
            return _volume;
        }

        //SERIALIZATION
        public void Write()
        {
            _channel = Channel;
            _volume = Volume;

            string jsonFileOutput = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, jsonFileOutput);
        }

        //DESERIALIZATION
        public void Read()
        {
            string filePath = File.ReadAllText(path);
            Radio radio = JsonConvert.DeserializeObject<Radio>(filePath);
            Channel = radio.readChannel;
            Volume = radio.readVolume;
        }
    }
}