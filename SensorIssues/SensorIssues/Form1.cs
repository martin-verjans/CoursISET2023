using Sensor;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SensorIssues
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitSensors();
        }

        private void InitSensors()
        {
            CreateSensor(lblSensor1);
            CreateSensor(lblSensor2);
            CreateSensor(lblSensor3);
        }

        private void CreateSensor(Label attachToLabel)
        {
            TemperatureSensor sensor = SensorFactory.CreateSensor();
            sensor.SensorUpdated += Sensor_SensorUpdated;
            //We attach the sensor to the label so it doesn't get disposed
            attachToLabel.Tag = sensor;
        }

        private void Sensor_SensorUpdated(object sender, double e)
        {
            Invoke(new Action(() => TryUpdateSensorValue((TemperatureSensor)sender, e)));
        }

        private void TryUpdateSensorValue(object sensor, double newValue)
        {
            try
            {
                TemperatureSensor validSensor = ValidateObjectIsTemperatureSensor(sensor);
                UpdateSensorValue(validSensor, newValue);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        private TemperatureSensor ValidateObjectIsTemperatureSensor(object sensor)
        {
            if (sensor is null)
            {
                throw new Exception("sensor is null");
            }

            if (!(sensor is TemperatureSensor))
            {
                throw new Exception($"Object received is not a TemperatureSensor (object is {sensor.GetType()}");
            }

            return (TemperatureSensor)sensor;
        }

        private void UpdateSensorValue(TemperatureSensor sensor, double newValue)
        {
            int id = sensor.GetSensorId();
            Label toUpdate = FindLabelForSensorId(id);
            UpdateSensorLabel(toUpdate, id, newValue);
        }

        private Label FindLabelForSensorId(int id)
        {
            switch (id)
            {
                case 1: return lblSensor1;
                case 2: return lblSensor2;
                case 3: return lblSensor3;
                default: throw new Exception($"No label matches sensor Id {id}");
            }
        }

        private void UpdateSensorLabel(Label toUpdate, int id, double newValue)
        {
            toUpdate.Text = $"Sensor {id} : {Math.Round(newValue, 1)}";
        }
        private static void DisplayException(Exception ex)
        {
            Debug.WriteLine($"Exception (Type {ex.GetType()}) : {ex.Message}");
            Debug.WriteLine($"StackTrace :{Environment.NewLine}{ex.StackTrace}");
            MessageBox.Show($"An exception occured : {ex.Message}", ex.GetType().ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //We will dispose the sensors, so the threads don't keep running in background
            DisposeSensor((TemperatureSensor)lblSensor1.Tag);
            DisposeSensor((TemperatureSensor)lblSensor2.Tag);
            DisposeSensor((TemperatureSensor)lblSensor3.Tag);
        }

        private void DisposeSensor(TemperatureSensor sensor)
        {
            sensor.Dispose();
        }
    }
}
