using System;
using System.Threading;

namespace Sensor
{
    internal class RandomTemperatureSensor : TemperatureSensor
    {
        private static int sensorCount = 0;
        private const double MIN = -500;
        private const double MAX = 500;
        private const int FAILRATE = 999000;
        private readonly Random random;
        private double temp = 0;
        private readonly int sensorId;

        public event EventHandler<double> SensorUpdated;

        public RandomTemperatureSensor()
        {
            sensorId = ++sensorCount;
            random = new Random();
            ThreadPool.QueueUserWorkItem(WorkLoop);
        }

        public double GetCurrentTemperature()
        {
            return temp;
        }

        public int GetSensorId()
        {
            return sensorId;
        }

        private void WorkLoop(object state)
        {
            while (true)
            {
                temp = (random.NextDouble() * (MAX - MIN)) + MIN;
                ThreadPool.QueueUserWorkItem(SendSensorUpdatedEvent, temp);
                Thread.Sleep(100);
            }
        }

        private void SendSensorUpdatedEvent(object state)
        {
            double newTemp = (double)state;
            try
            {
                if (random.Next(1000000) > FAILRATE)
                {
                    SensorUpdated?.Invoke(null, double.NaN);
                }
                else
                {
                    SensorUpdated?.Invoke(this, newTemp);
                }
            }
            catch (Exception) { }
        }
    }
}
