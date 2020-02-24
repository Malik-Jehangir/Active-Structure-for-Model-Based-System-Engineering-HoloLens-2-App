using System;
using System.Collections.Generic;

[Serializable]
public class EnvironmentModelFlow
{
    public string flowId;
    public string flowType;
    public string flowName;
    public List<Property3> properties;
    public string bidirectional;
    public string source;
    public string target;
    public string flowID;
}