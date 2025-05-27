using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface INotificationService
    {
        Task SendNotificationToAllAsync(string title, string message);
    }
}

