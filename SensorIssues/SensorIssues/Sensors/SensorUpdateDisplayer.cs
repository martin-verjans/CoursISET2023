using System;
using System.Windows.Forms;

namespace SensorIssues.Sensors
{
    /// <summary>
    /// This class updates the given labels when statistics have changed
    /// </summary>
    internal class SensorUpdateDisplayer : IDisposable
    {
        private readonly SensorValueUpdater updater;
        private readonly Label valueLabel;
        private readonly Label errorLabel;

        private bool disposedValue;

        public SensorUpdateDisplayer(SensorValueUpdater updater, Label valueLabel, Label errorLabel)
        {
            this.valueLabel = valueLabel;
            this.errorLabel = errorLabel;
            this.updater = updater;
            updater.StatisticsHaveChanged += Updater_StatisticsHaveChanged;
        }

        private void Updater_StatisticsHaveChanged(object sender, SensorUpdateStatistics e)
        {
            UpdateLabel(valueLabel, FormatSensorValue(e.LastSensorValue));
            UpdateLabel(errorLabel, FormatStatistics(e));
        }

        private void UpdateLabel(Label toUpdate, string text)
        {
            toUpdate.Text = text;
        }

        private string FormatSensorValue(double value)
        {
            return $"{value:0.##}";
        }

        private string FormatStatistics(SensorUpdateStatistics stats)
        {
            return $"{stats.ErrorRate:0.##} ({stats.UpdateOKCount} / {stats.UpdateFailedCount})";
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    updater.StatisticsHaveChanged -= Updater_StatisticsHaveChanged;
                    updater.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~SensorUpdateDisplayer()
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
