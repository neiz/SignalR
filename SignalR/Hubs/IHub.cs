﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public interface IHub : IDisposable
    {
        /// <summary>
        /// Gets a dynamic object that represents the calling client.
        /// </summary>
        dynamic Caller { get; set; }

        /// <summary>
        /// Gets a <see cref="HubCallerContext"/>. Which contains information about the calling client.
        /// </summary>
        HubCallerContext Context { get; set; }

        /// <summary>
        /// Gets a dynamic object that represents all clients connected to this hub (not hub instance).
        /// </summary>
        dynamic Clients { get; set; }

        /// <summary>
        /// Called before a connection completes reconnecting to the <see cref="IHub"/> after a timeout.
        /// </summary>
        /// <param name="groups">The groups the reconnecting client claims to be a member of.</param>
        /// <returns>The groups the client will actually join.</returns>
        IEnumerable<string> RejoiningGroups(IEnumerable<string> groups);

        /// <summary>
        /// Gets the <see cref="IGroupManager"/> the hub instance.
        /// </summary>
        IGroupManager Groups { get; set; }

        /// <summary>
        /// Called when a new connection is made to the <see cref="IHub"/>.
        /// </summary>
        Task Connect();

        /// <summary>
        /// Called when a connection reconnects to the <see cref="IHub"/> after a timeout.
        /// </summary>
        Task Reconnect();

        /// <summary>
        /// Called when a connection is disconnected from the <see cref="IHub"/>.
        /// </summary>
        /// <remarks>
        /// This method is invoked from the server side which means the only valid property on the <see cref="HubCallerContext"/>
        /// is the connection id.
        /// </remarks>
        Task Disconnect();
    }
}

