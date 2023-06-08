using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain
{
    public static class Events
    {
        public static string Image => "Image";
        public static string TurnLightOn => "TurnLightOn";
        public static string TurnLightOff => "TurnLightOff";
        public static string BatteryStatus => "BatteryStatus";
        public static string GPSStatus => "GPSStatus";
        public static string PersonInvasion => "PersonInvasion";
        public static string LowBattery => "LowBattery";
        public static string Startup => "Startup";
        public static string GPSMovement => "GPSMovement";
        public static string Truck => "Truck";
        public static string PowerLoss => "PowerLoss";
    }
}
