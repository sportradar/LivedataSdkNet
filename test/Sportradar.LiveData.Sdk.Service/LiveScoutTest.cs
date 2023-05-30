using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;
using log4net;
using Sportradar.LiveData.Sdk.Common;
using Sportradar.LiveData.Sdk.FeedProviders.LiveScout.Events;

namespace Sportradar.LiveData.Sdk.Service
{
    public class LiveScoutTest
    {
        private static readonly ILog g_log = CommonLoggerManager.GetLogger(typeof(LiveScoutTest));

        public LiveScoutTest()
        {
            Services.Sdk.Instance.LiveScout.OnOpened += LiveScout_OnOpened;
            Services.Sdk.Instance.LiveScout.OnClosed += LiveScout_OnClosed;
            Services.Sdk.Instance.LiveScout.OnMatchList += OnMatchList;
            Services.Sdk.Instance.LiveScout.OnMatchStop += OnMatchStop;
            Services.Sdk.Instance.LiveScout.OnMatchUpdate += OnMatchUpdate;
            Services.Sdk.Instance.LiveScout.OnScoutInfo += OnScoutInfo;
            Services.Sdk.Instance.LiveScout.OnMatchBookingReply += OnMatchBookingReply;
            Services.Sdk.Instance.LiveScout.OnMatchData += OnMatchData;
        }

        void LiveScout_OnClosed(object sender, ConnectionChangeEventArgs e)
        {
            g_log.Warn("Disconnected");
        }

        void LiveScout_OnOpened(object sender, ConnectionChangeEventArgs e)
        {
            g_log.Warn("Connected");

            //Sdk.Instance.LiveOddsVfc.GetEventList(DateTime.UtcNow.AddHours(-4), DateTime.Now.AddHours(4), true);
            Services.Sdk.Instance.LiveScout.GetMatchList(12, 14, true);
            Services.Sdk.Instance.LiveScout.Subscribe(new long[] { 14122064 });
            Services.Sdk.Instance.LiveScout.Subscribe(new long[] { 15927002 });
            Services.Sdk.Instance.LiveScout.Subscribe(new long[] { 1823059241 });
        }

        void OnMatchBookingReply(object sender, MatchBookingReplyEventArgs event_args)
        {
            g_log.InfoFormat("MatchBooking: result {0}, msg {1}", event_args.MatchBooking.Result, event_args.MatchBooking.Message);

            if (event_args.MatchBooking == null)
            {
                return;
            }

            g_log.InfoFormat("onMatchBooked result: " + event_args.MatchBooking.Result + "\n");

            if (event_args.MatchBooking.MatchId != null)
            {
                g_log.InfoFormat(event_args.MatchBooking.MatchId.Value.ToString());
                g_log.InfoFormat(event_args.MatchBooking.Message);
            }
            else
            {
                g_log.InfoFormat("No eventIdentifier." + "\n");
            }
        }

        void OnScoutInfo(object sender, ScoutInfoEventArgs event_args)
        {
            g_log.InfoFormat("ScoutInfo: match id {0}", event_args.MatchId);

            foreach (var item in event_args.ScoutInfos)
            {
                g_log.InfoFormat(">  {0}", item);
            }
        }

        void OnMatchUpdate(object sender, MatchUpdateEventArgs event_args)
        {
            var match_update = event_args.MatchUpdate;
            if (match_update.Events != null)
            {
                foreach (var scout_event in match_update.Events)
                {
                    g_log.Info($"Event type: {scout_event.TypeId}-{scout_event.Type}");
                    var ms = new MemoryStream();
                    var bf = new BinaryFormatter();
                    bf.Serialize(ms, scout_event);
                    var x = ms.ToArray();
                }
            }
            g_log.Info(match_update);
        }

        void OnMatchData(object sender, MatchDataEventArgs event_args)
        {
            var matchData = event_args.MatchData;
            Services.Sdk.Instance.LiveScout.Subscribe(new[] { matchData.MatchId });
            g_log.Info(matchData);
        }

        void OnMatchStop(object sender, MatchStopEventArgs event_args)
        {
            g_log.InfoFormat("MatchStop: match id {0}, reason {1}", event_args.MatchId, event_args.Reason);
        }

        void OnMatchList(object sender, MatchListEventArgs event_args)
        {
            g_log.InfoFormat("MatchList: {0} match updates", event_args.MatchList.Length);
            Subscribe(event_args);
        }

        private void Subscribe(MatchListEventArgs e)
        {
            var to_subscribe = e.MatchList
                .Where(x => x.MatchHeader.IsBooked == true || x.MatchHeader.IsBooked == null)
                .Select(x => x.MatchHeader.MatchId)
                .ToList();
            g_log.InfoFormat("{0}: Subscribing to {1} events", "LiveScOut", to_subscribe.Count);
            g_log.InfoFormat("Subscribing to {0} events", to_subscribe.Count);
            //Max 100 events in single request
            var max_count = 100;
            while (to_subscribe.Any())
            {
                Services.Sdk.Instance.LiveScout.Subscribe(to_subscribe.Take(max_count));
                to_subscribe = to_subscribe.Skip(max_count).ToList();
            }
            Services.Sdk.Instance.LiveScout.Subscribe(new long[] { 14520934 });
        }

        public void Run()
        {
            g_log.InfoFormat("Running LiveScoutTest");

            var timer = new Timer();
            timer.AutoReset = true;
            timer.Interval = TimeSpan.FromHours(2).TotalMilliseconds;
            timer.Elapsed += (sender, args) => Services.Sdk.Instance.LiveScout.GetMatchList(3, 3, true);
            timer.Start();
            Services.Sdk.Instance.LiveScout.GetMatchList(12, 12, true);

            Services.Sdk.Instance.LiveScout.BookEvents(new long[] { 21796476 });
        }
    }
}