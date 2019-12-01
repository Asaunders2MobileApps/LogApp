using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LogApp
{
    class Constants
    {
        public static readonly Font Font;

        public static readonly Color Background = Color.FromHex("7CDEDC");

        public static readonly Color FontColor = Color.FromHex("010202");

        public static readonly Color ConfirmButton = Color.FromHex("368723");
        public static readonly Color WarnButton = Color.FromHex("D9CC3B");
        public static readonly Color DeleteButton = Color.FromHex("AF2B29");

        static Constants()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Font = Font.SystemFontOfSize(25, FontAttributes.None);
                    break;

                case Device.Android:
                    Font = Font.SystemFontOfSize(25, FontAttributes.None);
                    break;

                case Device.UWP:
                    Font = Font.SystemFontOfSize(22, FontAttributes.None);
                    break;
            }
        }

    }
}
