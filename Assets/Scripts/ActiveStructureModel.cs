using System;
using System.Collections.Generic;

[Serializable]
public class ActiveStructureModel
{
    public DateTime lastModified;
    public List<ActiveStructureModelFlow> activeStructureModelFlows;
    public List<SubSystemElement> subSystemElements;
}
