using System;
using System.Collections.Generic;

[Serializable]
public class Requirement
{
    public string requirementId;
    public string title;
    public string requirementType;
    public string description;
    public string demandOrWish;
    public string status;
    public DateTime dateCreated;
    public DateTime lastModified;
    public List<object> subRequirements;
}