using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DiceRollerUITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
                return ConfigureApp
                .Android
                .InstalledApp("com.irsupera.diceroller")
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                .StartApp();

        }
    }
}
