﻿using AgGrid.InfiniteRowModel.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using MongoFramework;

namespace AgGrid.InfiniteRowModel.Sample.Database
{
    public class AppDbContext(IMongoDbConnection connection) : MongoDbContext(connection)
    {
        public MongoDbSet<User> Users { get; set; }
    }
}
