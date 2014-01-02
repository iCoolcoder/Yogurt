using System;
using System.IO;
using System.Xml.Serialization;

namespace TV.VOD
{
    public class IPTVMetadataLoader
    {
        public VodMetadata GetMetadata(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return Load(stream);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VodMetadata Load(Stream streamMetadata)
        {
            if (!streamMetadata.CanSeek)
            {
                MemoryStream streamTemp = new MemoryStream();
                int b = streamMetadata.ReadByte();
                while (b != -1)
                {
                    streamTemp.WriteByte(Convert.ToByte(b));
                    b = streamMetadata.ReadByte();
                }

                streamMetadata = streamTemp;
                streamMetadata.Position = 0;
            }

            if (streamMetadata.CanSeek)
            {
                streamMetadata.Position = 0;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(VodMetadata));
            return (VodMetadata)serializer.Deserialize(new StreamReader(streamMetadata, System.Text.Encoding.UTF8, true));
        }
    }
}
