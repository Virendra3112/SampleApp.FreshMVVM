using Android.App;
using Android.Content;
using Android.Util;
using AndroidX.Core.App;
using Firebase.Messaging;
using System;
using System.Collections.Generic;

namespace SampleApp.FreshMVVM.Droid
{
    [Service(Name = "com.virendra.demo.MyFirebaseMessagingService")]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var body = message.GetNotification().Body;
            Log.Debug("test", "Notification Message Body: " + body);
            SendNotification(body, message.Data);
        }

        void SendNotification(string messageBody, IDictionary<string, string> data)
        {
            try
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                foreach (var key in data.Keys)
                {
                    intent.PutExtra(key, data[key]);
                }

                var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.OneShot);

                var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                                          .SetSmallIcon(Resource.Drawable.icon)
                                          .SetContentTitle("DemoApp")
                                          .SetContentText(messageBody)
                                          .SetAutoCancel(true)
                                          .SetContentIntent(pendingIntent);

                var notificationManager = NotificationManagerCompat.From(this);
                notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
            }

            catch(Exception ex)
            {

            }
        }
    }
}