# 2–3 minute submission recording

## 0:00–0:20 — Introduction
“Hi, this is my Wexa AI Graph Explorer assignment. I built it using ASP.NET Core Web API, Angular and CognoDB. The use case is a talent network where candidates are connected to skills, companies and projects.”

## 0:20–0:50 — Architecture
Show the repository and explain:
- Angular is the UI.
- ASP.NET Core exposes graph APIs.
- CognoDB stores nodes and relationships.
- The application uses the official Neo4j .NET driver.
- Credentials are environment variables and are not committed.

## 0:50–1:30 — Demo: skill lookup
Open the hosted application. Search for `.NET` and click **Find candidates**. Explain that the query traverses Candidate -> HAS_SKILL -> Skill and also returns related companies.

## 1:30–2:10 — Demo: multi-hop traversal
Click **Explore 2-hop connections**. Explain the query: Candidate -> WORKED_ON -> Project -> USES_SKILL -> Skill. This demonstrates a relationship traversal that is natural in a graph model.

## 2:10–2:40 — Database and code
Briefly show `database/seed.cypher`, `GraphService.cs`, and the Dockerfile. Point out the parameterized `$skill` query parameter and the environment variables.

## 2:40–3:00 — Close
“Thanks. The source code is available in the GitHub repository and the deployed application is available at the hosted demo URL.”

## Recording checklist
- Keep browser zoom around 100%.
- Do not show passwords, tokens or private credentials.
- Show the hosted URL in the browser.
- Show one successful `.NET` search and one multi-hop result.
- Keep the video under 3 minutes.
