using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XOClient.Api
{
    static class XmlPacketDecoder
    {
        public static TTTpacket Decode(string xmlStr)
        {
            TTTpacket inPacket = null;
            XmlSerializer serializer = new XmlSerializer(typeof(TTTpacket));
            using (StringReader textReader = new StringReader(xmlStr))
            {
                inPacket = (TTTpacket)serializer.Deserialize(textReader);
            }
            return inPacket;
        }

        public static string Encode(TTTpacket packet)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(TTTpacket));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, packet);
                result = textWriter.ToString();
            }
            return result.Replace("\r\n", "");
        }
    }
}
