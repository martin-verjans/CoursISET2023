using System;
using System.Diagnostics;
using System.Threading;

namespace Sensor
{
    internal class RandomTemperatureSensor : TemperatureSensor
    {
        private static int sensorCount = 0;
        private const double MIN = -500;
        private const double MAX = 500;
        private const int FAILRATE = 700000;
        private readonly Random random;
        private double temp = 0;
        private bool disposedValue;
        private bool stopRequired;
        private readonly int sensorId;

        public event EventHandler<double> SensorUpdated;

        public RandomTemperatureSensor()
        {
            sensorId = ++sensorCount;
            random = new Random();
            Thread.Sleep(100); //Just to make sure 2 calls in a row will generate different Randoms
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
            while (!stopRequired)
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
            catch (Exception ex) 
            {
                //This is to make sure that if client code throws, we don't blow up the app.
                //Do not do that in real life..
                //For the exercise, if the following shows up, your applciation has crashed.
                Debug.Fail($"Uncaught Exception {ex.GetType()} : {ex.Message}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    stopRequired = true;
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~RandomTemperatureSensor()
        // {
        //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
