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
    public class LocationCreatedFirstHandler : INotificationHandler<LocationCreatedModel>
    {
        public Task Handle(LocationCreatedModel notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("First handler send some sms, emails, push notifications...");
            return Task.CompletedTask;
        }
    }
}
