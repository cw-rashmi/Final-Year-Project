using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Gms.Iid;
using Android.Gms.Gcm;
namespace AISCM.Droid
{
    [Service(Exported = false)]
    class RegistrationIntentService : IntentService
    {
        static object locker = new object();

        public RegistrationIntentService() : base("RegistrationIntentService") { }

        protected override void OnHandleIntent(Intent intent)
        {
            try
            {
                Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");
                lock (locker)
                {
                    var instanceID = InstanceID.GetInstance(this);
                    var token = instanceID.GetToken(
                        "613279052266", GoogleCloudMessaging.InstanceIdScope, null);

                    Log.Info("RegistrationIntentService", "GCM Registration Token: " + token);
                    System.Diagnostics.Debug.WriteLine("token:" + token);
                    SendRegistrationToAppServer(token);
                    Subscribe(token);
                }
            }
            catch (Exception e)
            {
                Log.Debug("RegistrationIntentService", "Failed to get a registration token");
                System.Diagnostics.Debug.WriteLine("Failed to get a registration token"+e);
                return;
            }
        }

        void SendRegistrationToAppServer(string token)
        {
            // Add custom implementation here as needed
            //net.azurewebsites.agc20171.AISCM a = new net.azurewebsites.agc20171.AISCM();
            net.azurewebsites.aiscm.WebService1 w = new net.azurewebsites.aiscm.WebService1();
            //a.update_gcm_token(Global_portable.email,token);
            System.Diagnostics.Debug.WriteLine("email:"+Global_portable.email+"token"+token);
            w.update_gcm_token(Global_portable.email, token);
        }

        void Subscribe(string token)
        {
            var pubSub = GcmPubSub.GetInstance(this);
            pubSub.Subscribe(token, "/topics/global", null);
        }
    }
    }