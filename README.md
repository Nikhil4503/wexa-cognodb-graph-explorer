# Wexa Graph Explorer

.NET 8 Web API + Angular application for the Wexa AI CognoDB assignment.

Use case: Talent Network Explorer — explore relationships between candidates, skills, companies and projects.

Why graph database? Multi-hop questions such as Candidate -> Project -> Skill are naturally represented as graph traversals.

Graph:
- (Candidate)-[:HAS_SKILL]->(Skill)
- (Candidate)-[:WORKED_AT]->(Company)
- (Candidate)-[:WORKED_ON]->(Project)
- (Project)-[:USES_SKILL]->(Skill)

## Setup
1. Create a CognoDB instance.
2. Set `COGNODB_URI`, `COGNODB_USERNAME` and `COGNODB_PASSWORD`.
3. Run `database/seed.cypher`.
4. API: `cd backend/WexaGraph.Api && dotnet restore && dotnet run`
5. Angular: `cd frontend && npm install && npm start`

The API uses the official Neo4j .NET driver and parameterized Cypher. Never commit credentials.
