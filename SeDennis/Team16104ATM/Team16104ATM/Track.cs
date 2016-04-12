using System;

namespace Team16104ATM
{
    public class Track : ITrack
    {
        private string _tag;

        public string Tag
        {
            get { return _tag;}
            set { _tag = value.Length == 6 ? value : "xxxxxx"; }
        }

        public Position Position { get; set; }
        public Position OldPosition { get; set; }
        public double Velocity { get; set; }
        public double CurCompasCourse { get; set; }
        public TimeStamp TimeStamp { get; set; }
        public TimeStamp OldTimeStamp { get; set; }

        public Track(string tag, int x , int y, int z, TimeStamp timestamp)
        {
            OldPosition = new Position();
            Position = new Position();
            Tag = tag;
            Position.XKoordinate = x;
            Position.YKoordinate = y;
            Position.ZKoordinate = z;
            TimeStamp = new TimeStamp("00000000000000000");
            OldTimeStamp = new TimeStamp("00000000000000000");
            TimeStamp = timestamp;
        }

        public void UpdateTrack(string tag, int x, int y, int z, TimeStamp timestamp)
        {
            PutIntoOld(Position, TimeStamp); 
            Position.XKoordinate = x;
            Position.YKoordinate = y;
            Position.ZKoordinate = z;
            TimeStamp = timestamp;
            CalculateVelocity();
            CalculateCompasCourse();
        }

        private void PutIntoOld(Position pos, TimeStamp time)
        {
            OldPosition.YKoordinate = pos.YKoordinate;
            OldPosition.XKoordinate = pos.XKoordinate;
            OldPosition.ZKoordinate = pos.ZKoordinate;
            OldTimeStamp.Day = time.Day;
            OldTimeStamp.Hour = time.Hour;
            OldTimeStamp.MilliSecond = time.MilliSecond;
            OldTimeStamp.Minute = time.Minute;
            OldTimeStamp.Month = time.Month;
            OldTimeStamp.Second = time.Second;
            OldTimeStamp.Year = time.Year;
        }

        private void CalculateCompasCourse()
        {
            if (OldPosition.XKoordinate == Position.XKoordinate && OldPosition.YKoordinate == Position.YKoordinate)
            {
                CurCompasCourse = double.NaN;
                return;
            }
            var x = (Math.Atan2(Position.YKoordinate - OldPosition.YKoordinate,
                    Position.XKoordinate - OldPosition.XKoordinate) * 180 / Math.PI);
            
            var temp = Math.Round(x - 90, 2);

            if (temp > 0)
                CurCompasCourse = 360 - temp;
            else
                CurCompasCourse = Math.Abs(temp);
        }

        private void CalculateVelocity()
        {

            var distance = Math.Sqrt(Math.Pow(Position.XKoordinate - OldPosition.XKoordinate, 2) + Math.Pow(Position.YKoordinate - OldPosition.YKoordinate, 2) +
                            Math.Pow(Position.ZKoordinate - OldPosition.ZKoordinate, 2));
            var timeDiffInSec = TimeStamp.CalculateTimeDiffrenceinSeconds(OldTimeStamp);

            Velocity = Math.Round(distance / timeDiffInSec, 2);
            
        }
    }
}
