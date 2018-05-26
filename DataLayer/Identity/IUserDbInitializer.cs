using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Identity
{
    public interface IUserDbInitializer
    {
       Task Seed();
    }
}
