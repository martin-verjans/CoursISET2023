using System;
using System.Collections.ObjectModel;

namespace SensorIssues.Sensors
{
    /// <summary>
    /// This class will map a sensor id to a label/error label
    /// </summary>
    internal class SensorDisplayerCollection : Collection<SensorUpdateDisplayer>, IDisposable
    {
        private bool disposedValue;

        private void DisposeAllItems()
        {
            foreach (SensorUpdateDisplayer displayer in Items)
            {
                displayer.Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    DisposeAllItems();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~SensorLabelMapper()
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
