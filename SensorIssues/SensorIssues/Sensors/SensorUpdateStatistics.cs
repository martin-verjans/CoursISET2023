namespace SensorIssues.Sensors
{
    /// <summary>
    /// This class retains statistics of OK/Failed messages
    /// </summary>
    internal class SensorUpdateStatistics
    {
        public long UpdateOKCount { get; private set; } = 0; 
        public long UpdateFailedCount { get; private set; } = 0;
        public double LastSensorValue { get; set; } = 0.0;
        /// <summary>
        /// Theorically there could be a DivideByZeroException.
        /// But we know that this Property will be called after a StatisticsHaveChanged event
        /// Therefore at least of the two values will be incremented.
        /// </summary>
        public double ErrorRate => (double)UpdateFailedCount / (UpdateOKCount + UpdateFailedCount);

        public void IncrementOKCount()
        {
            UpdateOKCount++;
        }

        public void IncrementFailedCount()
        {
            UpdateFailedCount++;
        }
    }
}
