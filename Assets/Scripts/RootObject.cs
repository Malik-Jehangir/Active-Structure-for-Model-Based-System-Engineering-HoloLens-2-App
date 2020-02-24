using System;
using System.Collections.Generic;

[Serializable]
public class RootObject
{
    public int projectId;
    public string projectName;
    public string projectDescription;
    public List<string> projectTags;
    public string version;
    public DateTime timeCreated;
    public DateTime lastModified;
    public EnvironmentModel environmentModel;
    public RequirementModel requirementModel;
    public ActiveStructureModel activeStructureModel;
    public ApplicationScenarioModel applicationScenarioModel;
    public List<InterModelConnection> interModelConnections;
}