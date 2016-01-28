using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EasyMemo.Repositories;

namespace EasyMemo.Services
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DatabaseInitializeStrategy());
            new EasyMemoContext().Database.Initialize(true);
        }
    }
}