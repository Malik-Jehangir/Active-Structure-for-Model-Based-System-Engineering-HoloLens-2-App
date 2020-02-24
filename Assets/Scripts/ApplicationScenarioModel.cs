using System;
using System.Collections.Generic;

[Serializable]
public class ApplicationScenarioModel
{
    public DateTime lastModified;
    public List<ApplicationScenario> applicationScenarios;
    public List<ApplicationScenarioModelTraceLink> applicationScenarioModelTraceLinks;
}