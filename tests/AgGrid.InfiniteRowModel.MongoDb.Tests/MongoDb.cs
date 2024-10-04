using System;
using AgGrid.InfiniteRowModel.Sample.Database;
using MongoDB.Driver;
using MongoFramework;
using Xunit.Abstractions;

namespace AgGrid.InfiniteRowModel.Tests;

public class MongoDb
{
    public static AppDbContext GetDbContext()
    {
        var connection = MongoDbConnection.FromUrl(new MongoUrl($"mongodb://localhost:27017/{Guid.NewGuid().ToString()}")); 
        return new AppDbContext(connection);
    }
    
    public static AppDbContext GetDbContext(ITestOutputHelper output)
    {
        var connection = MongoDbConnection.FromUrl(new MongoUrl($"mongodb://localhost:27017/{Guid.NewGuid().ToString()}"));
        return new AppDbContext(connection);
    }
    public static void Cleanup(AppDbContext dbContext)
    {
        dbContext.Connection.Client.DropDatabase(dbContext.Connection.GetDatabase().DatabaseNamespace.DatabaseName);
    }

    public class MongoDbFiltering : Filtering
    {
        public MongoDbFiltering(ITestOutputHelper output) : base(MongoDb.GetDbContext(output)) { }

        public override void Dispose()
        {
            MongoDb.Cleanup(_dbContext);
            base.Dispose();
        }
    }
    
    public class MongoDbOrdering : Ordering
    {
        public MongoDbOrdering(ITestOutputHelper output) : base(MongoDb.GetDbContext(output)) { }

        public override void Dispose()
        {
            MongoDb.Cleanup(_dbContext);
            base.Dispose();
        }
    }

    public class MongoDbPaging : Paging
    {
        public MongoDbPaging(ITestOutputHelper output) : base(MongoDb.GetDbContext(output)) { }

        public override void Dispose()
        {
            MongoDb.Cleanup(_dbContext);
            base.Dispose();
        }
    }


}