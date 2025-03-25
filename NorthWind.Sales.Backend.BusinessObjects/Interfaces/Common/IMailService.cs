using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;

public interface IMailService
{
    Task SendEmailToAdministrator(string subject, string body);
}
