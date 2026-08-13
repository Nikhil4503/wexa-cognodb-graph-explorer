using Neo4j.Driver;
namespace WexaGraph.Api.Services;
public sealed class GraphService {
 private readonly IDriver _driver; public GraphService(IDriver driver)=>_driver=driver;
 public async Task<IReadOnlyList<object>> BySkillAsync(string skill){
  const string q="MATCH (c:Candidate)-[:HAS_SKILL]->(s:Skill) WHERE toLower(s.name)=toLower($skill) OPTIONAL MATCH (c)-[:WORKED_AT]->(co:Company) RETURN c.name AS candidate,c.location AS location,collect(DISTINCT co.name) AS companies ORDER BY candidate";
  await using var session=_driver.AsyncSession(); var result=await session.RunAsync(q,new{skill}); var rows=await result.ToListAsync();
  return rows.Select(r=>(object)new{candidate=r["candidate"].As<string>(),location=r["location"].As<string>(),companies=r["companies"].As<List<string>>() }).ToList();
 }
 public async Task<IReadOnlyList<object>> MultiHopAsync(string skill){
  const string q="MATCH (c:Candidate)-[:WORKED_ON]->(p:Project)-[:USES_SKILL]->(s:Skill) WHERE toLower(s.name)=toLower($skill) RETURN DISTINCT c.name AS candidate,p.name AS project,s.name AS skill ORDER BY candidate,project";
  await using var session=_driver.AsyncSession(); var result=await session.RunAsync(q,new{skill}); var rows=await result.ToListAsync();
  return rows.Select(r=>(object)new{candidate=r["candidate"].As<string>(),project=r["project"].As<string>(),skill=r["skill"].As<string>()}).ToList();
 }
}