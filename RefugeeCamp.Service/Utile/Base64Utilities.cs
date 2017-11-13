using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeeCamp.Service.utile
{
    public class Base64Utilities
    {
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                = System.Text.UTF8Encoding.UTF8.GetBytes(toEncode);
            string returnValue
                = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        static public string Decode64ToString(string toDecode)
        {
            string base64Decoded;
            byte[] data = null;
            try
            {
              data = System.Convert.FromBase64String(toDecode + "=");
                base64Decoded = System.Text.UTF8Encoding.UTF8.GetString(data);
                return base64Decoded;
            }
            catch (Exception e)
            {
                data = System.Convert.FromBase64String(toDecode);
                base64Decoded = System.Text.UTF8Encoding.UTF8.GetString(data);
                return base64Decoded;
            }
        }
    }
}
