using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Carsalesbyhoho.Models;

namespace Carsalesbyhoho.Data
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
    }
}
