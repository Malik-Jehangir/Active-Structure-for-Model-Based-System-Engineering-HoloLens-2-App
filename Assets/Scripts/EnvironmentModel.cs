using System;
using System.Collections.Generic;

[Serializable]
public class EnvironmentModel
{
    public DateTime lastModified;
    public SystemElement systemElement;
    public List<EnvironmentElement> environmentElements;
    public List<EnvironmentModelFlow> environmentModelFlow;
}