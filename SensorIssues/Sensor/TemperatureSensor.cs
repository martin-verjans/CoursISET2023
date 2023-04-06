using System;

namespace Sensor
{
    public interface TemperatureSensor : IDisposable
    {
        int GetSensorId();
        double GetCurrentTemperature();

        event EventHandler<double> SensorUpdated;
    }
}
