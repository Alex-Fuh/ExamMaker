var builder = DistributedApplication.CreateBuilder(args);



var db = builder.AddPostgres("db-container")
    .WithDataVolume()
    .AddDatabase("api-db");
builder.AddProject<Projects.ExamMaker>("api")
    .WithReference(db)
    .WaitForStart(db);


builder.Build().Run();