﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Rocket.Surgery.Extensions.DependencyInjection.Internals
{
    /// <summary>
    /// ServiceProviderObservable.
    /// Implements the <see cref="System.IObservable{System.IServiceProvider}" />
    /// </summary>
    /// <seealso cref="System.IObservable{System.IServiceProvider}" />
    class ServiceProviderObservable : IObservable<IServiceProvider>
    {
        private readonly ILogger _logger;
        private readonly List<IObserver<IServiceProvider>> _observers = new List<IObserver<IServiceProvider>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProviderObservable"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ServiceProviderObservable(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Notifies the provider that an observer is to receive notifications.
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <returns>A reference to an interface that allows observers to stop receiving notifications before the provider has finished sending them.</returns>
        public IDisposable Subscribe(IObserver<IServiceProvider> observer)
        {
            _observers.Add(observer);
            return new Disposable(() =>
            {
                _observers.RemoveAll(x => x == observer);
            });
        }

        /// <summary>
        /// Sends the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Send(IServiceProvider value)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnNext(value);
                    observer.OnCompleted();
                }
                catch (Exception e)
                {
                    _logger.LogError(0, e, "Failed to execute observer");
                }
            }
        }
    }
}
