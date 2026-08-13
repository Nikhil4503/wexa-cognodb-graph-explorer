using Microsoft.AspNetCore.Mvc;
using WexaGraph.Api.Services;
namespace WexaGraph.Api.Controllers;
[ApiController][Route("api/[controller]")]
public class GraphController:ControllerBase{
 private readonly GraphService _graph; public GraphController(GraphService graph)=>_graph=graph;
 [HttpGet("candidates/by-skill/{skill}")] public async Task<IActionResult> BySkill(string skill){try{return Ok(await _graph.BySkillAsync(skill));}catch(Exception ex){return StatusCode(503,new{message="Graph database unavailable.",detail=ex.Message});}}
 [HttpGet("traversal/{skill}")] public async Task<IActionResult> Traversal(string skill){try{return Ok(await _graph.MultiHopAsync(skill));}catch(Exception ex){return StatusCode(503,new{message="Graph database unavailable.",detail=ex.Message});}}
}