using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using NSubstitute;
using TransponderReceiver;
using NUnit.Framework;
using Team16104ATM;

namespace Team16104ATM_Unittest
{
    [TestFixture]
    public class RadartowerUnittest
    {
        #region Setup

        ITransponderReceiver transponderReceiver;

        Radartower _uut;

        [SetUp]
        public void Setup()
        {
            transponderReceiver = Substitute.For<ITransponderReceiver>();

            _uut = new Radartower(transponderReceiver);
        }

        #endregion

        [Test]
        public void OnTransponderDataReady_RaiseEvent_OnTransponderDataReadyWasCalled()
        {
            bool wasCalled = false;

            transponderReceiver.TransponderDataReady += (sender, args) => wasCalled = true;

            transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>()));

            Assert.True(wasCalled);
        }

        [TestCase("ATR423", "39045", "12932", "14000", "20151006213456789")]
        [TestCase("ABC123", "90000", "50000", "10000", "20151006213456789")]
        [TestCase("ABC123", "10000", "50000", "10000", "20151006213456789")]
        [TestCase("ABC123", "50000", "90000", "10000", "20151006213456789")]
        [TestCase("ABC123", "50000", "10000", "10000", "20151006213456789")]
        [TestCase("ABC123", "50000", "50000", "20000", "20151006213456789")]
        [TestCase("ABC123", "50000", "50000", "500", "20151006213456789")]
        public void OnTransponderDataReady_SpawnTrackInside_TrackTagIsInList(string tag, string x, string y, string z, string time)
        {
            transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>() { tag + ";" + x + ";" + y + ";" + z + ";" + time }));

            Assert.That(_uut.Tracks[0].Tag, Is.EqualTo(tag));
        }
        
        [TestCase("ABC123", "90001", "50000", "10000", "20151006213456789")]
        [TestCase("ABC123", "9999", "50000", "10000", "20151006213456789")]
        [TestCase("ABC123", "50000", "90001", "10000", "20151006213456789")]
        [TestCase("ABC123", "50000", "9999", "10000", "20151006213456789")]
        [TestCase("ABC123", "50000", "50000", "20001", "20151006213456789")]
        [TestCase("ABC123", "50000", "50000", "499", "20151006213456789")]
        public void OnTransponderDataReady_SpawnTrackOutside_TrackTagIsNotInList(string tag, string x, string y, string z, string time)
        {
            transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>() { tag + ";" + x + ";" + y + ";" + z + ";" + time }));

            Assert.That(_uut.Tracks.Count, Is.EqualTo(0));
        }

        [TestCase("ABC123", "50000", "50000", "10000", "20151006213456789")]
        public void OnTransponderDataReady_NewTrackEntersAirspace_TrackEnteredEventIsFired(string tag, string x, string y, string z, string time)
        {
            bool wasCalled = false;
            transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>() { tag + ";" + x + ";" + y + ";" + z + ";" + time }));

            _uut.TrackEnteredAirspace += () => wasCalled = true;
           // transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>() { tag + ";" + x + ";" + y + ";" + z + ";" + time }));

            Assert.True(wasCalled);
        }

    }
}
