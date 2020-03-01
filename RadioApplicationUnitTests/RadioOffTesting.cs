using NUnit.Framework;
using RadioApplication;

namespace RadioApplicationUnitTests
{
    class RadioOffTesting
    {
        private Radio radio;
        [SetUp]
        public void Setup()
        {
            radio = new Radio();
            radio.PowerOff();
        }

        //CHANGE TO VALID CHANNEL
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ChangeToValidChannelWhenOffTest(int newChannel)
        {
            radio.Channel = newChannel;
            Assert.AreEqual(1, radio.Channel);
        }

        //CHANGE TO INVALID CHANNEL
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        public void ChangeToInvalidChannelWhenOffTest(int newChannel)
        {
            radio.Channel = newChannel;
            Assert.AreEqual(newChannel, radio.Channel);
        }

        //RADIO OFF TEST
        [Test]
        public void PlayTest()
        {
            var message = radio.Play();
            Assert.AreEqual("Please turn on the radio to play music", message);
        }

        //PLAY TEST
        [Test]
        public void TurnOnTest()
        {
            radio.PowerOn();
            Assert.AreEqual("Radio is on & playing on channel 1", radio.Play());
        }

        //VOLUME TEST
        [TestCase(0)]
        [TestCase(30)]
        [TestCase(40)]
        public void VolumeTest(double newVolume)
        {
            radio.Volume = newVolume;
            Assert.AreEqual(newVolume, radio.Volume);

        }

        //INVALID VOLUME TEST
        [TestCase(-15)]
        [TestCase(90)]
        public void InvalidVolumeTestWhenOff(double newVolume)
        {
            radio.Volume = newVolume;
            Assert.AreEqual(newVolume, radio.Volume);
        }
    }
}
