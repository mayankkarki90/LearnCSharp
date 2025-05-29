using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp.DesignPatterns
{
    //IDisposable pattern
    internal class DisposePattern : IDisposable
    {
        private bool _disposed = false;
        private FileStream? _fileStrem;

        public DisposePattern(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            _fileStrem = new FileStream(filePath, FileMode.Append, FileAccess.ReadWrite);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting resources.
        /// This method is automaticalled called if class is initialzed with using.
        /// Even if some error is encountered while executing the using block, this method
        /// will be invoked.
        /// </summary>
        public void Dispose()
        {
            //Pass true when explicitly disposing
            Dispose(true);

            //Tells GC that object has been explicitly cleaned up and no need to add it to finalizer queue
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// Make it virtual, so it can be override by inherited classed, if required
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.
        /// When Dispose is called explicitly, then it make sense to release both managed and unmanaged resources.
        /// But when Dispose is called from destructor, it is already being finalized. So dispose only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _fileStrem?.Dispose();
                _fileStrem = null;
            }

            //handle unmanaged resources here

            _disposed = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DisposePattern"/> class.
        /// In case Dispose is not explicitly called, or not used "using" to call it automatically.
        /// In that case finalizer will handle the Dispose, but now as object is already being finalized,
        /// or GC has already released managed resources before calling destructor. So only umanaged 
        /// resources need to be disposed properly.
        /// </summary>
        ~DisposePattern()
        {
            Dispose(false);
        }
    }
}
