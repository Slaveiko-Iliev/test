namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private const string _Brand = "Brand";
        private const double _Price = 100;
        private const int _ScreenWidth = 1920;
        private const int _ScreenHeigth = 1080;
        TelevisionDevice tv;

        [SetUp]
        public void Setup()
        {
            tv = new TelevisionDevice(_Brand, _Price, _ScreenWidth, _ScreenHeigth);
        }

        [Test]
        public void TestCreathingTelevisionDevice()
        {
            Assert.IsNotNull(tv);
            Assert.AreEqual(_Brand, tv.Brand);
            Assert.AreEqual(_Price, tv.Price);
            Assert.AreEqual(_ScreenWidth, tv.ScreenWidth);
            Assert.AreEqual(_ScreenHeigth, tv.ScreenHeigth);
            Assert.AreEqual(0, tv.CurrentChannel);
            Assert.AreEqual(13, tv.Volume);
            Assert.AreEqual(false, tv.IsMuted);
        }

        [Test]
        public void TestSwitchOn()
        {
            string sound = tv.IsMuted ? "Off" : "On";
            Assert.AreEqual($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound {sound}", tv.SwitchOn());
            tv.MuteDevice();
            sound = tv.IsMuted ? "Off" : "On";
            Assert.AreEqual($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound {sound}", tv.SwitchOn());
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void TestChangeInvalidChannel(int channel)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => tv.ChangeChannel(channel));
            Assert.AreEqual("Invalid key!", ex.Message);
            Assert.AreEqual(0, tv.CurrentChannel);
        }
        
        [TestCase(5)]
        public void TestChangeChannel(int channel)
        {
            Assert.AreEqual(channel, tv.ChangeChannel(channel));
            Assert.AreEqual(channel, tv.CurrentChannel);
        }

        [TestCase("UP", 3)]
        public void TestUpVolumeChange(string direction, int units)
        {
            string expected = tv.VolumeChange(direction, units);
            Assert.AreEqual($"Volume: {tv.Volume}", expected);
        }
        
        [TestCase("UP", 93)]
        public void TestUpVolumeChangeOver100(string direction, int units)
        {
            string expected = tv.VolumeChange(direction, units);
            Assert.AreEqual($"Volume: {tv.Volume}", expected);
            Assert.AreEqual(100, tv.Volume);
        }
        
        [TestCase("DOWN", 3)]
        public void TestDownVolumeChange(string direction, int units)
        {
            string expected = tv.VolumeChange(direction, units);
            Assert.AreEqual($"Volume: {tv.Volume}", expected);
        }
        
        [TestCase("DOWN", 93)]
        public void TestDownVolumeChangeUnder0(string direction, int units)
        {
            string expected = tv.VolumeChange(direction, units);
            Assert.AreEqual($"Volume: {tv.Volume}", expected);
            Assert.AreEqual(0, tv.Volume);
        }

        [Test]
        public void TestMuteDevice()
        {
            Assert.AreEqual(true, tv.MuteDevice());
        }
        
        [Test]
        public void TestMuteDevice2()
        {
            tv.MuteDevice();
            Assert.AreEqual(false, tv.MuteDevice());
        }

        [Test]
        public void TestToString()
        {
            Assert.AreEqual($"TV Device: {_Brand}, Screen Resolution: {_ScreenWidth}x{_ScreenHeigth}, Price {_Price}$", tv.ToString());
        }
    }
}