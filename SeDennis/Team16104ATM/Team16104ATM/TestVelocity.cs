using System.Collections.Generic;
using System.Linq;
using TransponderReceiver;

namespace Team16104ATM
{
    public class TestVelocity
    {
        List<Track> TracksList = new List<Track>();

        public void AddTrack(Track track)
        {
            TracksList.Add(track);
        }

        private readonly ITransponderReceiver TransponderReceiver;

        public TestVelocity()
        {
            TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
        }

        public void getData()
        {
            TransponderReceiver.TransponderDataReady += Handledata;
        }

        private void Handledata(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var planeInfo in e.TransponderData)
            {
                //AAA123;12345;12345;12345;12345678901234567

                string[] words = planeInfo.Split(';');
                List<string> stringList = words.ToList();

                if (TracksList.Any(plane => plane.Tag == stringList[0]))
                {
                    var item = TracksList.First(track => track.Tag == stringList[0]);
                    item.UpdateTrack(stringList[0], int.Parse(stringList[1]), int.Parse(stringList[2]), int.Parse(stringList[3]), new TimeStamp(stringList[4]));
                }
                else
                {
                    AddTrack(new Track(stringList[0], int.Parse(stringList[1]), int.Parse(stringList[2]), int.Parse(stringList[3]), new TimeStamp(stringList[4]))); 
                }
            }
        }
    }
}
