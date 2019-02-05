using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TestCQRSProject.Locations.Models;

namespace TestCQRSProject.Locations.Notifications
{
    public class LocationCreatedModel : INotification
    {
        public int Id { get; set; }
    }
}
