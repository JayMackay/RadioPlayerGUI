using NUnit.Framework;
using RadioApplication;

namespace RadioApplicationUnitTests
{
    public class RadioOnTesting
    {
        private Radio radio;
        [SetUp]
        public void Setup()
        {
            radio = new Radio();
            radio.PowerOn();
        }

        //CHANGE TO VALID CHANNEL
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ChangeToValidChannelTest(int newChannel)
        {
            radio.Channel = newChannel;
            Assert.AreEqual(newChannel, radio.Channel);
        }

        //CHANGE TO INVALID CHANNEL
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        public void ChangeToInvalidChannelTest(int newChannel)
        {
            radio.Channel = newChannel;
            Assert.AreEqual(newChannel, radio.Channel);
        }

        //PLAY TEST
        [Test]
        public void PlayTest()
        {
            radio.Channel = 4;
            var message = radio.Play();
            Assert.AreEqual("Radio is on & playing on channel 4", message);
        }

        //RADIO OFF TEST
        [Test]
        public void TurnOffTest()
        {
            radio.PowerOff();
            Assert.AreEqual("Please turn on the radio to play music", radio.Play());
        }

        //VOLUME TEST
        [TestCase(0)]
        [TestCase(30)]
        public void VolumeTest(double newVolume)
        {
            radio.Volume = newVolume;
            Assert.AreEqual(newVolume, radio.Volume);

        }

        //INVALID VOLUME TEST
        [TestCase(-15)]
        [TestCase(100)]
        public void InvalidVolumeTest(double newVolume)
        {
            radio.Volume = newVolume;
            Assert.AreEqual(newVolume, radio.Volume);
        }
    }
}