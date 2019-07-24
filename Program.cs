using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            ////saving file to stream
            Stream raw = File.OpenRead(@"C:\Users\sweet\OneDrive\Desktop\GITRepo\ImageComparer\RawImages\sino801_540x1200.raw");
            //raw.Close();
            Console.WriteLine("raw "+"= "+raw);
            FileStream raw1 = File.OpenRead(@"C:\Users\sweet\OneDrive\Desktop\GITRepo\ImageComparer\RawImages\sino800_540x1200.raw");
            //str1.Close();
            Console.WriteLine("raw1 "+ "= "+ raw1);

            var ms1 = raw.ReadByte();
            var ms2 = raw1.ReadByte();
            if (ms1 != -1 && ms2 != -1)
            {
                Console.WriteLine("ReadByte: Stream raw = var ms1 " + "= " + ms1);
                Console.WriteLine("ReadByte: FileStream raw1 = var ms2 " + "= " + ms2);
            }
            else if(ms1 == -1 && ms2 == -1 )
            {
                Console.WriteLine("ReadByte: raw & raw1 not converted to FileStream");
            }
            else if(ms1 == ms1 && ms2 != -1)
            {
                Console.WriteLine("ReadByte: Stream raw : var ms1 " + "= " + ms1);
                Console.WriteLine("ReadByte: raw1 not converted to FileStream");

            }else if(ms1 ==-1 && ms2 == ms2)
            {
                Console.WriteLine("ReadByte: Stream raw1 : var ms2 " + "= " + ms1);
                Console.WriteLine("ReadByte: raw not converted to FileStream");
            }


            ////Converting Stream to ByteArray
            byte[] streamToByteArry(Stream strm)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    strm.CopyTo(ms);
                    return ms.ToArray();
                }
            }

            ////////////byte[] imageData;

            ////////////// Create the byte array.
            ////////////var originalImage = File.OpenRead(@"C:\Users\sweet\OneDrive\Desktop\GITRepo\ImageComparer\RawImages\sino800_540x1200.raw");
            ////////////using (var ms = new MemoryStream())
            ////////////{
            ////////////   Image.FromStream(originalImage).Save(ms, ImageFormat.MemoryBmp);
            ////////////    imageData = ms.ToArray();
            ////////////}
            ////////////Console.WriteLine("imagesData byte array" + imageData);
            byte[] newByteArray = streamToByteArry(raw);

           var nBA = BitConverter.ToUInt16(newByteArray, 0 );
            Console.WriteLine("BitConverter.ToInt32 : Stream raw : var nBA " + "= " + nBA);
            var nBA1 = BitConverter.ToUInt16(streamToByteArry(raw1), 0);
            Console.WriteLine("BitConverter.ToInt32 : Stream raw1 : var nBA1 " + "= " + nBA1);


            int Nba = nBA;
            Console.WriteLine("HEX String: " + Convert.ToString(Nba, 16));

            //Bitmap bm;
            //using (var byteMs = new MemoryStream(newByteArray))
            //{
            //    bm = new Bitmap(byteMs);
            //}
            //Console.WriteLine(bm);


            var ms3 = streamToByteArry(raw1);
            Console.WriteLine("streamToByteArry: FileStream raw1 : var ms2 " + "= "+ms3);
            string hex = BitConverter.ToString(ms3);
            //Console.WriteLine(hex);


            //Console.WriteLine("BitConverter.ToString "+"= "+ms2);
            //Console.WriteLine(hex);

            //open file and read bytes
            //byte[] raw = File.ReadAllBytes(@"C:\Users\sweet\OneDrive\Desktop\GITRepo\ImageComparer\RawImages\sino800_540x1200.raw");
            //string bmp = Encoding.ASCII.GetString(raw, 0, raw.Length);

            //Console.WriteLine(raw.ToString());
            //Console.WriteLine(streamToByteArry(raw));
            //Console.WriteLine(bmp);
            Console.ReadLine();
        }
    }
}
