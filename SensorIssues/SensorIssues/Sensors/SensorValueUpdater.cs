using System;

namespace SensorIssues.Sensors
{
    /// <summary>
    /// This class will update the values for the statistics
    /// </summary>
    internal class SensorValueUpdater : IDisposable
    {
        private readonly SensorUpdateStatistics statistics;
        private readonly SensorUpdateValidator validator;

        private bool disposedValue;

        public event EventHandler<SensorUpdateStatistics> StatisticsHaveChanged;

        public SensorValueUpdater(SensorUpdateStatistics statistics, SensorUpdateValidator validator)
        {
            this.statistics = statistics;
            this.validator = validator;
            validator.SensorValueUpdated += Validator_SensorValueUpdated;
            validator.SensorErrorOccured += Validator_SensorErrorOccured;
        }

        private void Validator_SensorErrorOccured(object sender, Exception e)
        {
            statistics.IncrementFailedCount();
            RaiseUpdate();
        }

        private void Validator_SensorValueUpdated(object sender, double e)
        {
            statistics.LastSensorValue = e;
            statistics.IncrementOKCount();
            RaiseUpdate();
        }

        private void RaiseUpdate()
        {
            StatisticsHaveChanged?.Invoke(this, statistics);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    validator.SensorValueUpdated -= Validator_SensorValueUpdated;
                    validator.SensorErrorOccured -= Validator_SensorErrorOccured;
                    validator.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~SensorValueUpdater()
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
