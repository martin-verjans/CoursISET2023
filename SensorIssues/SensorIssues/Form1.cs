using Sensor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorIssues
{
    public partial class Form1 : Form
    {
        TemperatureSensor sensor1, sensor2, sensor3;
        public Form1()
        {
            InitializeComponent();
            sensor1 = SensorFactory.CreateSensor();
            sensor1.SensorUpdated += Sensor_SensorUpdated;
            lblSensor1.Tag = sensor1.GetSensorId();
            sensor2 = SensorFactory.CreateSensor();
            sensor2.SensorUpdated += Sensor_SensorUpdated;
            lblSensor1.Tag = sensor2.GetSensorId();
            sensor3 = SensorFactory.CreateSensor();
            sensor3.SensorUpdated += Sensor_SensorUpdated;
            lblSensor3.Tag = sensor3.GetSensorId();
        }

        private void Sensor_SensorUpdated(object sender, double e)
        {
            int id = ((TemperatureSensor)sender).GetSensorId();
            if ((int)lblSensor1.Tag == id)
            {
                lblSensor1.Text = "Sensor 1 : " + Math.Round(e, 1);
            }
            else if ((int)lblSensor3.Tag == id)
            {
                lblSensor2.Text = "Sensor 2 : " + Math.Round(e, 1);
            }
            else if ((int)lblSensor2.Tag == id)
            {
                lblSensor2.Text = "Sensor 3 : " + Math.Round(e, 1);
            }
        }
    }
}
