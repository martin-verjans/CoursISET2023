using Sensor;
using System;
using System.Windows.Forms;

namespace SensorIssues.Sensors
{
    /// <summary>
    /// The job of this class is only to jump from the sensor thread to the graphical thread, 
    /// nothing more, nothing less
    /// </summary>
    internal class SensorUpdateToFormInvoker : IDisposable
    {
        private readonly Control control;
        private readonly TemperatureSensor sensor;

        private bool disposedValue;
        private bool controlHandleCreated = false;

        public event EventHandler<double> SensorValueUpdated;

        public SensorUpdateToFormInvoker(TemperatureSensor sensor, Control control)
        {
            this.sensor = sensor;
            sensor.SensorUpdated += Sensor_SensorUpdated;
            this.control = control;
            control.HandleCreated += Control_HandleCreated;
            control.HandleDestroyed += Control_HandleDestroyed;
        }

        private void Sensor_SensorUpdated(object sender, double e)
        {
            if (!controlHandleCreated)
            {
                //This means the form is not displayed (yet or anymore)
                return;
            }
            control.Invoke(new Action(() => SensorValueUpdated(sender, e)));
        }
        private void Control_HandleDestroyed(object sender, EventArgs e)
        {
            controlHandleCreated = false;
        }

        private void Control_HandleCreated(object sender, EventArgs e)
        {
            controlHandleCreated = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    sensor.SensorUpdated -= Sensor_SensorUpdated;
                    sensor.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~SensorUpdateToFormInvoker()
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
