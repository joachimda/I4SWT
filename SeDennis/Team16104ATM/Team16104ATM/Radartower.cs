﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TransponderReceiver;

namespace Team16104ATM
{
    public class Radartower
    {
        ITransponderReceiver _transponderReceiver;

        public delegate void TrackEnteredAirspaceHandler();

        public delegate void TrackLeftAirspaceHandler();


        public event TrackEnteredAirspaceHandler TrackEnteredAirspace;
        protected virtual void OnTrackEnteredAirspace()
        {
            TrackEnteredAirspace?.Invoke();
            Console.WriteLine("Herro!");
        }

        public List<ITrack> Tracks { get; set; }

        public Radartower(ITransponderReceiver transponderReceiver)
        {
            _transponderReceiver = transponderReceiver;
            Tracks = new List<ITrack>();

            transponderReceiver.TransponderDataReady += OnTransponderDataReady; // subscribe to event
        }

        private void OnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            // formatting data for use
            foreach (string rawdata in rawTransponderDataEventArgs.TransponderData)
            {
                string[] rawData = rawdata.Split(';');
                List<string> data = rawData.ToList();

                if (int.Parse(data[1]) >= 10000 && int.Parse(data[1]) <= 90000 &&
                    int.Parse(data[2]) >= 10000 && int.Parse(data[2]) <= 90000 &&
                    int.Parse(data[3]) >= 500 && int.Parse(data[3]) <= 20000)
                {
                    if (Tracks.Any(track => track.Tag == data[0])) // checks if track appears multiple times in list
                    {
                        Track AlreadyKnownTrack = (Track)Tracks.First(track => track.Tag == data[0]); // finds existing track with 'Tag'
                        AlreadyKnownTrack.UpdateTrack(data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), new TimeStamp(data[4])); // updated old track instead of making new entry
                        OnTrackEnteredAirspace();
                    }
                    else
                    {
                        Tracks.Add(new Track(data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), new TimeStamp(data[4])));
                    }
                }

                // determine type of event

                // log event to file

                // render current events to screen
            }
        }
    }
}