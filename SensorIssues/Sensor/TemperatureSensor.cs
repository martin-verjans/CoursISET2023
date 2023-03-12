using System;

namespace Sensor
{
    public interface TemperatureSensor
    {
        int GetSensorId();
        double GetCurrentTemperature();

        event EventHandler<double> SensorUpdated;
    }
}
