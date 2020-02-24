using System;
using System.Collections.Generic;

[Serializable]
public class ActiveStructureModelFlow
{
    public string flowId;
    public List<Property4> properties;
    public string flowType;
    public string source;
    public string target;
}