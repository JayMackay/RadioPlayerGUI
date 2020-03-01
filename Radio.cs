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
        private int _volume = 0;

        //CHANNEL PROPERTY
        public int Channel
        {
            get
            {
                return _channel;
            }

            set
            {
                if (value <= 4 && value > 0 && _on == true)
                {
                    _channel = value;
                }
            }
        }

        //VOLUME PROPERTY
        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value >= 0 && value <= 30 && _on == true)
                {
                    _volume = value;
                }
            }
        }

        //POWER ON METHOD
        public void TurnOn()
        {
            _on = true;
            //return "Radio is on";
        }

        //POWER OFF METHOD
        public string TurnOff()
        {
            _on = false;
            return "Radio is off";
        }


        //PLAY CHANNEL METHOD
        public string Play()
        {
            int channelNumber = _channel;

            if (_on == true)
            {
                return $"Playing channel {channelNumber}";
            }
            else
            {
                return "Radio is off";
            }

        }

        //VOLUME CONTROL
        public int volumeControl()
        {
            return _volume;
        }


        /*//SERIALIZE
        public void Write()
        {
            _channel = Channel;
            _volume = Volume;

            string output = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, output);
        }

        //DESERIALIZE
        public void Read()
        {
            string jsonfile = File.ReadAllText(path);
            var info = JsonConvert.DeserializeObject<Radio>(jsonfile);

        }*/
    }
}
