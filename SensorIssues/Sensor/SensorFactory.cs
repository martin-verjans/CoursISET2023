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
