using System;
using System.IO;
using System.Text;

namespace LB2_SHARP
{
    class Time
    {
        public int hour;
        public int min;
        public Time(int h, int m)
        {
            hour = h;
            min = m;
        }
        Time()
        {
        }
        public static Time operator+ (Time t1, Time t2) 
        {
            Time res = new Time();
            res.min = (t1.min + t2.min)%60;
            res.hour = (t1.hour + t2.hour + (res.min/60))%24;
            return res;
        }
    public static Time operator- (Time t1, Time t2)
    {
        Time res = new Time();
        res.min = (t1.min - t2.min) % 60;
        res.hour = (t1.hour - t2.hour) % 24;
        if (res.min < 0)
        {
            res.min += 60;
            res.hour -= 1;
        }
        if (res.hour < 0) res.hour += 24;
        return res;
    }
    public override string ToString()
    {
        return hour.ToString() + ":" + min.ToString();
    }
    };





    class Program
   {
       static void Main(string[] args)
        {
            Time time= new Time(0,0);
            Time testtime;
            Time time1 = new Time(8,29);
            Time time2 = new Time(10, 29);
            Time time3 = time2 + time1;
            Console.WriteLine("Введите время. Сначала час, потом энтер и минуты");
            time.hour = Convert.ToInt32(Console.ReadLine());
            time.min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(time3);

            //filestream
            string path="text.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(time);
            }

            string s;
            using (StreamReader sr = new StreamReader(path))
            {
                //Console.WriteLine(sr.ReadToEnd());
                s=sr.ReadLine();
            }
            Console.WriteLine(time);
        }
    }
}
