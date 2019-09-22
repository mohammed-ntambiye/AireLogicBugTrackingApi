using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AireLogicBugTrackingApi.Models;

namespace AireLogicBugTrackingApi.Data
{
    interface IApplicationDBContext
    {
         DbSet<BugsModel> Bugs { get; set; }
         DbSet<UserModel> Users { get; set; }
         DbSet<AssignedStatus> AssignedStatus { get; set; } 
    }
}
