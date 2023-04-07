using Sensor;
using System;

namespace SensorIssues.Sensors
{
    /// <summary>
    /// The job of this class is to validate a sensor update, then forward it, 
    /// either as error or update
    /// </summary>
    internal class SensorUpdateValidator : IDisposable
    {
        private readonly SensorUpdateToFormInvoker invoker;

        private bool disposedValue;

        public event EventHandler<double> SensorValueUpdated;
        public event EventHandler<Exception> SensorErrorOccured;

        public SensorUpdateValidator(SensorUpdateToFormInvoker invoker)
        {
            this.invoker = invoker;
            invoker.SensorValueUpdated += Invoker_SensorValueUpdated;
        }

        private void Invoker_SensorValueUpdated(object sender, double e)
        {
            try
            {
                ValidateObjectIsTemperatureSensor(sender);
                SensorValueUpdated?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                SensorErrorOccured?.Invoke(this, ex);
            }
        }

        private void ValidateObjectIsTemperatureSensor(object sensor)
        {
            if (sensor is null)
            {
                throw new Exception("sensor is null");
            }

            if (!(sensor is TemperatureSensor))
            {
                throw new Exception($"Object received is not a TemperatureSensor (object is {sensor.GetType()}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    invoker.SensorValueUpdated -= Invoker_SensorValueUpdated;
                    invoker.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~SensorUpdateValidator()
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
