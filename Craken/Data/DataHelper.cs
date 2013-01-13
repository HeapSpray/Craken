using System;

namespace Nerey.Craken.Data
{
    public static class DataHelper
    {
        public static byte[] CharsToBytes(char[] chars)
        {
            int l = chars.Length;
            byte[] temp = new byte[l];
            for (int i = 0; i < l; i++) { temp[i] = (byte)chars[i]; };
            return temp;
        }

        public static char[] BytesToChars(byte[] chars)
        {
            int l = chars.Length;
            char[] temp = new char[l];
            for (int i = 0; i < l; i++) { temp[i] = (char)chars[i]; };
            return temp;
        }

        public static void StrAlloc(CrakenString str, int newsize)
        {
            byte[] data = new byte[newsize];
            int l = str.Length;
            for (int i = 0; i < newsize; i++) { if (i < l) { data[i] = str[i]; } else { data[i] = 0; }; };
            str[false, null] = data;
        }
    }
}