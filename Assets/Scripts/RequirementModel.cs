using System;
using System.Collections.Generic;

[Serializable]
public class RequirementModel
{
    public DateTime lastModified;
    public List<Requirement> requirements;
    public List<RequirementModelTraceLink> requirementModelTraceLinks;
}
