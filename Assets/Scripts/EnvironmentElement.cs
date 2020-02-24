using System;
using System.Collections.Generic;

[Serializable]
public class EnvironmentElement
{
    public string name;
    public string environmentElementId;
    //public string __invalid_name__x-coordinate;
    //public string __invalid_name__y-coordinate;
    public List<Property2> properties;
}