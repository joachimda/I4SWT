using NUnit.Framework;
using Team16104ATM;

namespace Team16104ATM_Unittest
{
    [TestFixture]
    class TestUnittest
    {
        private Track _track;

        [SetUp]
        public void Setup()
        {
            _track = new Track("ABCDEF", 39000, 42000, 14000, new TimeStamp("20160704093256789"));
        }

        [Test]
        public void Velocity_TestCordinatesxadd1000mover20sec_returns233ms()
        {
            _track.UpdateTrack("ABCDEF", 40000, 42000, 14000, new TimeStamp("20160704093326789"));
            Assert.That(_track.Velocity, Is.EqualTo(33.33));
        }

        [Test]
        public void Velocity_TestCordinatesxsubstract1000mover20sec_returns233ms()
        {
            _track.UpdateTrack("ABCDEF", 38000, 42000, 14000, new TimeStamp("20160704093326789"));
            Assert.That(_track.Velocity, Is.EqualTo(33.33));
        }

        [Test]
        public void Velocity_TestCordinatesadd1000toXAndminus500over2min_returns9dot32ms()
        {
            _track.UpdateTrack("ABCDEF", 40000, 42000, 13500, new TimeStamp("20160704093456789"));
            Assert.That(_track.Velocity, Is.EqualTo(9.32));
        }

        [Test]
        public void Velocity_TestCordinatesadd1000toXAndminus1000YAndadd500over1minAnd211ms_returns9dot32ms()
        {
            _track.UpdateTrack("ABCDEF", 40000, 41000, 14500, new TimeStamp("20160704093357000"));
            Assert.That(_track.Velocity, Is.EqualTo(24.59));
        }

        //[Test]
        //public void Velocity_TestTimeStampNotExsisting_returnsminuns1()
        //{
        //    _track.updateTrack("AAAAAA", 40000, 41000, 14500, new TimeStamp("20160704093357000"));
        //    Assert.That(_track.Velocity, Is.EqualTo(-1));
        //}

        [Test]
        public void Velocity_TestCordinatesAndTimeSame_returns0ms()
        {
            _track.UpdateTrack("ABCDEF", 39000, 42000, 14000, new TimeStamp("20160704093256789"));
            Assert.That(_track.Velocity, Is.EqualTo(double.NaN));
        }


        [Test]
        public void CurrentCompasCource_TestCordinatesxadd1000_returns90Degree()
        {
            _track.UpdateTrack("ABCDEF", 40000, 42000, 14000, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(90));
        }

        [Test]
        public void CurrentCompasCource_TestCordinatesxsubstract1000m_returns270Degree()
        {
            _track.UpdateTrack("ABCDEF", 38000, 42000, 14000, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(270));
        }

        [Test]
        public void CurrentCompasCource_TestCordinatesadd1000toXAndMinus1000Y_returns135Degree()
        {
            _track.UpdateTrack("ABCDEF", 40000, 41000, 14000, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(135));
        }

        [Test]
        public void CurrentCompasCource_TestCordinatesadd1000toXAndMinus1000YAndZAdd500_returns135Degree()
        {
            _track.UpdateTrack("ABCDEF", 40000, 41000, 14500, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(135));
        }

        [Test]
        public void CurrentCompasCource_TestCordinatesMinus1000toXAndminus1000Y_returns225Degree()
        {
            _track.UpdateTrack("ABCDEF", 38000, 41000, 14500, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(225));
        }

        [Test]
        public void CurrentCompasCource_TestCordinatesAndTimeSame_returnsNaN()
        {
            _track.UpdateTrack("ABCDEF", 39000, 42000, 14000, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(double.NaN));
        }
        [Test]
        public void CurrentCompasCource_TestCordinatesadd1000Y_returns0Degree()
        {
            _track.UpdateTrack("ABCDEF", 39000, 43000, 14000, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(0));
        }

        [Test]
        public void CurrentCompasCource_TestCordinatesMinus1000toXAndAdd1000Y_returns315Degree()
        {
            _track.UpdateTrack("ABCDEF", 38000, 43000, 14500, new TimeStamp("20160704093456789"));
            Assert.That(_track.CurCompasCourse, Is.EqualTo(315));
        }


    }
}
