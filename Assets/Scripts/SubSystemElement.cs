using System;
using System.Collections.Generic;

[Serializable]
public class SubSystemElement
{
    public string name;
    public string subsystemElementId;
    public List<Property5> properties;
    //public string __invalid_name__x-coordinate;
    //public string __invalid_name__y-coordinate;
    public List<SubSystemElement2> subSystemElements;
}