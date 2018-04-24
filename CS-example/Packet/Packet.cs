using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace insta_packet
{
    public class Class1
    {
    }

    public enum PacketType
    {
        flag = 0,
        member = 1,
        info = 2,
        home = 3
    }

    public enum PacketSendERROR
    {
        normal = 0,
        error
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt) ms.WriteByte(b);

            Console.WriteLine(bt);

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
    
    [Serializable]
    public class Flag : Packet
    {
        public bool seccess;

        public Flag()
        {
            this.seccess = false;
        }
    }

    [Serializable]
    public class Member : Packet
    {
        public string ID;
        public string password;

        public Member()
        {
            this.ID = null;
            this.password = null;
        }
    }
}
