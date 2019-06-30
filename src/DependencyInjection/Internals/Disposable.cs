using System;

namespace Rocket.Surgery.Extensions.DependencyInjection.Internals
{
    /// <summary>
    /// Class Disposable.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    class Disposable : IDisposable
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Disposable"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public Disposable(Action action)
        {
            _action = action;
        }
        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _action();
        }
    }
}
