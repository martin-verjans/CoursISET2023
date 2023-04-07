using Sensor;
using System.Windows.Forms;

namespace SensorIssues.Sensors
{
    /// <summary>
    /// This class can build mulitple sensors and retains them in a mapping object 
    /// </summary>
    internal class SensorBuilder
    {
        public SensorDisplayerCollection Sensors { get; } = new SensorDisplayerCollection();

        public void BuildSensor(Label valueLabel, Label erroRateLabel)
        {
            TemperatureSensor sensor = SensorFactory.CreateSensor();
            SensorUpdateStatistics stats = new SensorUpdateStatistics();

            /*
             * In the real world, you would not jump directly to the Graphical thread.
             * 
             * You would :
             * - jump to a intermediate thread (so you don't occupy the sensor thread too long)
             * - then do all the processing
             * - then finally jump on the graphical thread
             */

            //To jump to the Graphical thread
            SensorUpdateToFormInvoker invoker = new SensorUpdateToFormInvoker(sensor, valueLabel);

            //To validate the update is correct
            SensorUpdateValidator validator = new SensorUpdateValidator(invoker);

            //To update statistics
            SensorValueUpdater updater = new SensorValueUpdater(stats, validator);

            //To display the update on the form
            SensorUpdateDisplayer displayer = new SensorUpdateDisplayer(updater, valueLabel, erroRateLabel);

            //To keep a reference to our displayer object
            Sensors.Add(displayer);
        }
    }
}
