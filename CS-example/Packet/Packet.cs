using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using System.Net.Mime;

namespace insta_packet
{
    public class Class1
    {
    }

    public enum PacketType
    {
        flag = 0,
        member = 1,
        post = 2
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
        public bool success;

        public Flag()
        {
            this.success = false;
        }
    }

    [Serializable]
    public class Member : Packet
    {
        public string ID;
        public string password;
        public byte[] profile_pic;
        public string comment;
        public int post_count;
        public int purpose;
        //for sign up : 1
        //for log in : 2
        //for member id : 3
        //for member info : 4
        //for member id, profile_pic : 5
        //for modify : 6
        public Member()
        {
            this.ID = null;
            this.password = null;
            this.profile_pic = null;
            this.comment = null;
            this.post_count = 0;
            this.purpose = 0;
        }
    }

    [Serializable]
    public class Post : Packet
    {
        public string ID;
        public byte[] picture;
        public string comment;
        public DateTime time;
        public int purpose;
        //for upload : 1
        //for all post : 2

        public Post()
        {
            this.ID = null;
            this.picture = null;
            this.comment = null;
            this.time = DateTime.Now;
            this.purpose = 0;
        }
    }
}
