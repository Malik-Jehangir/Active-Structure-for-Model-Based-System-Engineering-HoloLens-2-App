using System;
using System.Collections.Generic;

[Serializable]
public class SystemElement
{
    public string systemElementId;
    public string name;
    //public string __invalid_name__x-coordinate;
    //public string __invalid_name__y-coordinate;
    public List<Property> properties;
}
