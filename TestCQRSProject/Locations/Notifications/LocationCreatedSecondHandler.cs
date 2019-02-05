using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestCQRSProject.Locations.Models;

namespace TestCQRSProject.Locations.Notifications
{
    public class LocationCreatedSecondHandler : INotificationHandler<LocationCreatedModel>
    {
        public Task Handle(LocationCreatedModel notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Second handler processing here");
            return Task.CompletedTask;
        }
    }
}
