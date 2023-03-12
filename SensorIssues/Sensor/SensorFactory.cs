using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    public static class SensorFactory
    {
        public static TemperatureSensor CreateSensor()
        {
            return new RandomTemperatureSensor();
        }
    }
}
