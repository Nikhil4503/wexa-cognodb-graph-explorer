using Neo4j.Driver;
using WexaGraph.Api.Services;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDriver>(_=>{
 var uri=Environment.GetEnvironmentVariable("COGNODB_URI")??throw new InvalidOperationException("COGNODB_URI is not configured.");
 var user=Environment.GetEnvironmentVariable("COGNODB_USERNAME")??"cognodb";
 var password=Environment.GetEnvironmentVariable("COGNODB_PASSWORD")??throw new InvalidOperationException("COGNODB_PASSWORD is not configured.");
 return GraphDatabase.Driver(uri,AuthTokens.Basic(user,password));
});
builder.Services.AddScoped<GraphService>();
builder.Services.AddCors(o=>o.AddDefaultPolicy(p=>p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var app=builder.Build(); app.UseCors(); app.UseSwagger(); app.UseSwaggerUI(); app.MapControllers(); app.Run();