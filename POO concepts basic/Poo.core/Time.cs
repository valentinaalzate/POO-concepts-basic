namespace Poo.core
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }

        // overloads
        public Time(int hour)
        {
            Hour = hour;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = 0;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        public int Hour {
            get => _hour;
            set {
                _hour = ValidHour(value);
            }
        }

        public int Millisecond
        {
            get => _millisecond;
            set {
                _millisecond = ValidMillisecond(value);
            }
        }

        public int Minute
        {
            get => _minute;
            set {
                _minute = ValidMinute(value);
            }
        }


        public int Second
        {
            get => _second;
            set {
                _second = ValidSecond(value);
            }
        }

        public Time Add(Time anotherT)
        {
            int millisecond = this.Millisecond + anotherT.Millisecond;
            int second = this.Second + anotherT.Second;
            int minute = this.Minute + anotherT.Minute;
            int hour = this.Hour + anotherT.Hour;

            if (millisecond >= 1000)
            {
                second += millisecond / 1000;
                millisecond %= 1000;
            }

            if (second >= 60)
            {
                minute += second / 60;
                second %= 60;
            }

            if (minute >= 60)
            {
                hour += minute / 60;
                minute %= 60;
            }

            hour %= 24;

            return new Time(hour, minute, second, millisecond);
        }
        public bool IsOtherDay(Time anotherT)
        {
            int totalMilliseconds = this.ToMilliseconds() + anotherT.ToMilliseconds();
            int totalHours = totalMilliseconds / 3600000;

            return totalHours >= 24;
        }
        public  int ToMilliseconds() {
           // 1h= 3600000ms, 1m =60000ms, 1s=1000ms
            return (((Hour*3600000)+(Minute*60000)+(Second*1000)) + Millisecond);
        }

        public int ToMinutes()
        {
            // 1h= 60m
            return ((Hour * 60) + Minute);
        }

        public int ToSeconds()
        {
            // 1h= 3600s, 1m=60s
            return ((Hour * 3600) + (Minute * 60) + Second);
        }

        public override string ToString()
        {
            int hour2 = Hour % 12;
            if (hour2 == 0)
            {
                hour2 = 12;
            }
            var type= String.Empty; 
            if (Hour < 12)
            {
                type = "AM";
            }
            else
            {
                type = "PM";
            }
            return $"{hour2:D2}:{Minute:D2}:{Second:D2}.{Millisecond:D3} {type}";
        }

        public int ValidHour(int hour)
        {
            if (hour<0 || hour > 23) {
                throw new Exception($"The hour: {hour}, is not valid");
            }
            return hour;
        
        }

        public int ValidMillisecond(int milisecond)
        {
            if (milisecond < 0 || milisecond > 999)
            {
                throw new Exception($"The miliseconds: {milisecond}, is not valid");
            }
            return milisecond;

        }

        public int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new Exception($"The minutes: {minute}, is not valid");
            }
            return minute;

        }

        public int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new Exception($"The seconds: {second}, is not valid");
            }
            return second;

        }
    }

   
}
