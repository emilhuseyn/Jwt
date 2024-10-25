using App.Core.Entities;
using App.DAL.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Handlers.Implementations
{
    public class ContactUsHandler : Handler<ContactUs>, IContactUsHandler { }
}
