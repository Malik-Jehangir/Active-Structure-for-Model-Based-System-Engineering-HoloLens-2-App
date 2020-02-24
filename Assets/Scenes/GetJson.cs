using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetJson : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, Action>();


   

    /*public GameObject txt;
    public GameObject majorMain;
    public GameObject prefabMain;
    public GameObject textPrefab;
    public GameObject LinePrefab;
    public GameObject LinePrefab2;*/
    //public GameObject ProgressB;

    private Vector3 mzpos0 = new Vector3(-5f, 2f, 7.04f);
    private Vector3 mzpos = new Vector3(-5f, 0.13f, 7.04f);
    private Vector3 mzpos2 = new Vector3(-5f, -1.83f, 7.04f);


    private RootObject myObject;
    int index = 0;
    int index2 = 0;
    int dec = 0;
    int dec2 = 0;
    int dec3 = 0;
    private float pos0 = -5;
    private float pos=-5;
    private float pos2 = -5f;
    List<string> targetList=new List<string>();
    List<string> sourceList = new List<string>();

    List<string> WDtargetList = new List<string>();
    List<string> WDsourceList = new List<string>();



    private Transform newParent;
    private Transform newParent1;
    private string tmpStr;

    private GameObject clone = null;
    private GameObject clone2 = null;
    private GameObject clone3 = null;
    private GameObject clone4 = null;
    private GameObject clone5 = null;
    private GameObject clone6 = null;

    List<GameObject> RootObjectsList = new List<GameObject>();
    List<GameObject> RootObjectsTextList = new List<GameObject>();

    List<GameObject> SubRootObjectsList = new List<GameObject>();
    List<GameObject> SubRootObjectsTextList = new List<GameObject>();

    List<GameObject> SubSubRootObjectsList = new List<GameObject>();
    List<GameObject> SubSubRootObjectsTextList = new List<GameObject>();

    List<Vector3> sourcePos=new List<Vector3>();
    List<Vector3> targetPos = new List<Vector3>();

    List<Vector3> SourcePosPC1 = new List<Vector3>();
    List<Vector3> targetPosPC1 = new List<Vector3>();
    List<Vector3> targetPosPC2 = new List<Vector3>();

    private Vector3 rootpos;

    private Vector3 childrootpos;

    [Serializable]
    public class SystemProperty
    {
        public string PropertyName;
    }

    [Serializable]
    public class SystemElement
    {
        public string systemElementId;
        public string name;
        //public string x-coordinate;
        //public string y-coordinate;
        public List<SystemProperty> systemProperties;
    }

    [Serializable]
    public class ElementProperty
    {
        public string PropertyName;
    }

    [Serializable]
    public class EnvironmentElement
    {
        public string name;
        public string environmentElementId;
        //public string x-coordinate;
        //public string y-coordinate;
        public List<ElementProperty> elementProperties;
    }

    [Serializable]
    public class FlowProperty
    {
        public string PropertyName;
    }

    [Serializable]
    public class Flow
    {
        public string flowID;
        public string flowType;
        public string flowName;
        public List<FlowProperty> flowProperties;
        public string source1;
        public string source2;
        public string target;
    }

    [Serializable]
    public class EnvironmentModel
    {
        public string lastModified;
        public SystemElement systemElement;
        public List<EnvironmentElement> environmentElements;
        public List<Flow> flow;

    }
    [Serializable]
    public class Requirement
    {
        public string requirementId;
        public string title;
        public string requirementType;
        public string description;
        public string demandOrWish;
        public string status;
        public string dateCreated;
        public string lastModified;
        public List<object> subRequirements;
    }

    [Serializable]
    public class FlowProperty2
    {
        public string PropertyName;
    }

    [Serializable]
    public class Flow2
    {
        public string flowID;
        public string flowType;
        public string flowName;
        public List<FlowProperty2> flowProperties;
        public string source;
        public string target;
    }

    [Serializable]
    public class RequirementModel
    {
        public string lastModified;
        public List<Requirement> requirements;
        public List<Flow2> flow;
    }

    [Serializable]
    public class FlowProperty3
    {
        public string PropertyName;
    }

    [Serializable]
    public class Flow3
    {
        public string flowId;
        public string flowProperty;
        public string flowType;
        public string flowName;
        public List<FlowProperty3> flowProperties;
        public string source;
        public string target;
    }

    [Serializable]
    public class SubSubSystemElement
    {
        public string name;
        public string subsystemElementId;
        //public string x-coordinate;
        //public string y-coordinate;
    }

    [Serializable]
    public class SubSystemElement
    {
        public string name;
        public string subsystemElementId;
        //public string x-coordinate;
        //public string y-coordinate;
        public List<SubSubSystemElement> subSubSystemElements;
    }

    [Serializable]
    public class SystemElements
    {
        public string name;
        public string subsystemElementId;
        //public string x-coordinate;
        //public string y-coordinate;
        public List<SubSystemElement> subSystemElements;
    }

    [Serializable]
    public class ActiveStructureModel
    {
        public string lastModified;
        public List<Flow3> flow;
        public List<SystemElements> SystemElements;
    }

    [Serializable]
    public class ApplicationScenario
    {
        public string applicationScenarioID;
        public string title;
        public string situationDescription;
        public string behaviouralDescription;
        public string reference;
        public string dateCreated;
        public string lastModified;
    }

    [Serializable]
    public class ApplicationScenarioModel
    {
        public string lastModified;
        public List<ApplicationScenario> applicationScenarios;
    }

    [Serializable]
    public class InterModelConnections
    {
        public string connectionID;
        public string type;
        public string source;
        public string target;
    }

    [Serializable]
    public class RootObject
    {
        public int projectId;
        public string projectName;
        public string projectDescription;
        public List<string> projectTags;
        public string timeCreated;
        public string lastModified;
        public EnvironmentModel environmentModel;
        public RequirementModel requirementModel;
        public ActiveStructureModel activeStructureModel;
        public ApplicationScenarioModel applicationScenarioModel;
        public InterModelConnections InterModelConnections;
    }


    
    void Start()
    {


        /*GoCalled();


        //ProgressB.SetActive(false);

        keywords.Add("level 1", () =>
        {
            LinePrefab.SetActive(false);
            LinePrefab2.SetActive(false);

            GameObject h, h1;

            float p1 = SubRootObjectsList.Count * 10;
            p1 *= -1f;

        
           

            for (int r = 0; r < RootObjectsList.Count; r++)
            {
                RootObjectsList[r].transform.localScale = new Vector3(1000f, 300f, 300f);

                h = RootObjectsList[r];

                h.transform.position += new Vector3(p1, 2f, 7.04f);

                RootObjectsTextList[r].GetComponent<UnityEngine.TextMesh>().fontSize = 600;

                h1 = RootObjectsTextList[r];

                h1.transform.position += new Vector3(p1, 2f, 7.04f);

                p1 += 10f;

            }
        
        });

        keywords.Add("level 2", () =>
        {
          

            GameObject h, h1;

            float p1 = SubRootObjectsList.Count * 10;
            p1 *= -1f;


            for (int rm = 0; rm < SubRootObjectsList.Count; rm++)
            {
                SubRootObjectsList[rm].transform.localScale = new Vector3(1000f, 300f, 300f);

                h = SubRootObjectsList[rm];

                h.transform.position += new Vector3(p1, 0f, 7.04f);


                SubRootObjectsTextList[rm].GetComponent<UnityEngine.TextMesh>().fontSize = 600;

                h1 = SubRootObjectsTextList[rm];

                h1.transform.position += new Vector3(p1, 0.13f, 7.04f);

                p1 += 10f;
            }

            majorMain.transform.localScale = new Vector3(16000f, 8000f, 2000f);
            majorMain.transform.position += new Vector3(-33.4f, -5.79f, 16f);
            txt.transform.position += new Vector3(-37.1f, 8.73f, 6.8f);
        });

        keywords.Add("level 3", () =>
        {
            
            GameObject h, h1;

            float p1 = SubSubRootObjectsList.Count * 10;
            p1 *= -1f;

         

            for (int rt = 0; rt < SubSubRootObjectsList.Count; rt++)
            {
                SubSubRootObjectsList[rt].transform.localScale = new Vector3(1000f, 300f, 300f);



                h = SubSubRootObjectsList[rt];

                h.transform.position += new Vector3(p1, -1.83f, 7.04f);


                SubSubRootObjectsTextList[rt].GetComponent<UnityEngine.TextMesh>().fontSize = 600;


                h1 = SubSubRootObjectsTextList[rt];

                h1.transform.position += new Vector3(p1, -1.83f, 7.04f);

                
                p1 += 10f;

            }

       

        });

        keywords.Add("back", () =>
        {

            LinePrefab.SetActive(true);
            LinePrefab2.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            
});

        //keywords.Add("refresh", () =>
        //{

        //    GoCalledProgress();
        //});



        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognized;
        keywordRecognizer.Start();*/

        //StartCoroutine(GetRequest("https://api.myjson.com/bins/j6fw2")); //online storage
    }


   
    /*void KeywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if(keywords.TryGetValue(args.text,out keywordAction))
        {
            keywordAction.Invoke();

        }
    }

   
    void GoCalled()
    {
        
        LinePrefab.SetActive(true);
        LinePrefab2.SetActive(true);

        StartCoroutine(GetRequest("http://localhost:3000/projects?projectId=1")); //local server (JSON server via Node.js)

          Debug.Log("Active structure without Flow lines loaded");
        
    }


   


    IEnumerator GetRequest(string uri)
    {
        WWW uwr = new WWW(uri);
        yield return uwr;

        if (uwr.error != null)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {

            tmpStr = uwr.text;
            getReady(tmpStr);
        }
           
    }*/

    /*void getReady(string tmpStr)
    {
        

        string newStr = tmpStr.Substring(1, tmpStr.Length - 2);


        myObject = JsonUtility.FromJson<RootObject>(newStr);
        Debug.Log("Received Project ID: " + myObject.projectId.ToString());
        Debug.Log("Received Project Name: " + myObject.projectName);
        Debug.Log("Active structure model last modified: " + myObject.activeStructureModel.lastModified.ToString());


        for (int x = 0; x < myObject.activeStructureModel.SystemElements.Count; x++)
        {
            index = myObject.activeStructureModel.SystemElements[x].subSystemElements.Count;

            int c = 0;
            int mx = 0;

            Debug.Log("Flow count: " + myObject.activeStructureModel.flow.Count.ToString());
            for (int mc = 0; mc < myObject.activeStructureModel.flow.Count; mc++)
            {
                mx += 1;
                Debug.Log("Flow member target " + mx.ToString() + ": " + myObject.activeStructureModel.flow[mc].target);
                Debug.Log("Flow member source " + mx.ToString() + ": " + myObject.activeStructureModel.flow[mc].source);

                WDsourceList.Add(myObject.activeStructureModel.flow[mc].source);
                targetList.Add(myObject.activeStructureModel.flow[mc].target);

            }

            //removing duplicates in source
            sourceList = WDsourceList.Distinct().ToList();

            for (int n = 0; n < sourceList.Count; n++)
            {
                Debug.Log("Clean source element(s): " + sourceList[n]);
            }




            //print the system elements root
            clone5 = Instantiate(prefabMain, new Vector3(pos0, 2f, 7.04f), Quaternion.identity) as GameObject;
            clone5.transform.localScale = new Vector3(500f, 150f, 150f);

          


            clone6 = Instantiate(textPrefab, mzpos0, Quaternion.identity) as GameObject;

            clone6.GetComponent<UnityEngine.TextMesh>().text = myObject.activeStructureModel.SystemElements[x].name + "\nID: " + myObject.activeStructureModel.SystemElements[x].subsystemElementId.ToString();
            clone6.transform.position = mzpos0;
            clone6.GetComponent<UnityEngine.TextMesh>().fontSize = 300;
            clone6.GetComponent<UnityEngine.TextMesh>().fontStyle = FontStyle.Bold;
            clone6.GetComponent<UnityEngine.TextMesh>().color = Color.black;


            RootObjectsList.Add(clone5);
            RootObjectsTextList.Add(clone6);

            //save position of root for parent child
            mzpos0.z = 7.26f;
            rootpos = mzpos0;


            
           






            //prints three subsystem elements
            for (int i = 0; i < myObject.activeStructureModel.SystemElements[x].subSystemElements.Count; i++)
            {



                SubSystemElement element = myObject.activeStructureModel.SystemElements[x].subSystemElements[i];

                clone = Instantiate(prefabMain, new Vector3(pos, 0f, 7.04f), Quaternion.identity) as GameObject;
                clone.transform.localScale = new Vector3(300f, 150f, 150f);

                c += 1;




                clone2 = Instantiate(textPrefab, mzpos, Quaternion.identity) as GameObject;
                clone2.GetComponent<UnityEngine.TextMesh>().text = myObject.activeStructureModel.SystemElements[x].subSystemElements[i].name + "\nSubsystem Element ID " + myObject.activeStructureModel.SystemElements[x].subSystemElements[i].subsystemElementId;
                clone2.transform.position = mzpos;
                clone2.GetComponent<UnityEngine.TextMesh>().fontSize = 200;
                clone2.GetComponent<UnityEngine.TextMesh>().fontStyle = FontStyle.Bold;
                clone2.GetComponent<UnityEngine.TextMesh>().color = Color.black;


                SubRootObjectsList.Add(clone);
                SubRootObjectsTextList.Add(clone2);






                //adding targets for root to subsystem elements
                mzpos.z = 7.26f;
                targetPosPC1.Add(mzpos);

                //connection between subsystem elements and subsubsystem elements SOURCE
                for (int p = 0; p < sourceList.Count; p++)
                {
                    if (myObject.activeStructureModel.SystemElements[x].subSystemElements[i].subsystemElementId == sourceList[p])
                    {
                        mzpos.z = 7.26f;

                        sourcePos.Add(mzpos);




                    }

                }


                pos += 2f;

                mzpos.x += 2f;
                mzpos.y = 0.13f;
                mzpos.z = 7.04f;



            }

            int counter = 0;




            //prints three Subsubsystem elements
            for (int j = 0; j < myObject.activeStructureModel.SystemElements[x].subSystemElements[index - 1].subSubSystemElements.Count; j++)
            {
                counter += 1;





                SubSubSystemElement element = myObject.activeStructureModel.SystemElements[x].subSystemElements[index - 1].subSubSystemElements[j];

                clone3 = Instantiate(prefabMain, new Vector3(pos2, -2f, 7.04f), Quaternion.identity) as GameObject;
                clone3.transform.localScale = new Vector3(300f, 150f, 150f);

                counter += 1;




                clone4 = Instantiate(textPrefab, mzpos2, Quaternion.identity) as GameObject;
                clone4.GetComponent<UnityEngine.TextMesh>().text = myObject.activeStructureModel.SystemElements[x].subSystemElements[index - 1].subSubSystemElements[j].name + "\nSubsystem Element ID " + myObject.activeStructureModel.SystemElements[x].subSystemElements[index - 1].subSubSystemElements[j].subsystemElementId;
                clone4.transform.position = mzpos2;
                clone4.GetComponent<UnityEngine.TextMesh>().fontSize = 200;
                clone4.GetComponent<UnityEngine.TextMesh>().fontStyle = FontStyle.Bold;
                clone4.GetComponent<UnityEngine.TextMesh>().color = Color.black;

                SubSubRootObjectsList.Add(clone3);
                SubSubRootObjectsTextList.Add(clone4);


                //child to subchild list
                mzpos2.z = 7.26f;
                targetPosPC2.Add(mzpos2);



                //connection between subsystem elements and subsubsystem elements TARGET

                for (int k = 0; k < targetList.Count; k++)
                {
                    if (myObject.activeStructureModel.SystemElements[x].subSystemElements[index - 1].subSubSystemElements[j].subsystemElementId == targetList[k])
                    {
                        mzpos2.z = 7.26f;


                        targetPos.Add(mzpos2);
                    }
                    else
                    {
                        //do nothing
                    }
                }

                pos2 += 2f;

                mzpos2.x += 2f;
                mzpos2.y = -1.83f;
                mzpos2.z = 7.04f;
            }

            //Draw lines for the system element in consideration (inloop)
            //Draw a line using a line renderer since now we have a source and a target

            DrawLines();
            DrawLinesParentChildfromRoot();
            DrawLinesParentChildfromChild();


            //clear the flows arrays for connection between the next system element
            sourcePos.Clear();
            targetPos.Clear();
            targetPosPC1.Clear();
            targetPosPC2.Clear();


            //change all positive values to negative and negative values to positive values cuz this will be used for x=0
            pos0 = 6f;
            pos = 2f;
            pos2= 2f;
            mzpos0 = new Vector3(6f, 2f, 7.04f);
            mzpos = new Vector3(2f, 0.13f, 7.04f);
            mzpos2 = new Vector3(2f, -1.83f, 7.04f);
            dec = 0;
            dec2 = 0;
            dec3 = 0;

            //now it goes for the second system element
         }



        GoCalledInfo();


    }






    void DrawLines()
    {
        GameObject newLineGen = Instantiate(LinePrefab);
        LineRenderer LRend = newLineGen.GetComponent<LineRenderer>();

        LRend.positionCount = targetPos.Count*2;
   
        for(int i = 0; i < targetPos.Count; i++)
        {
            LRend.SetPosition(dec, sourcePos[0]);
            dec += 1;
            LRend.SetPosition(dec, targetPos[i]);
            dec += 1;
        }
       
    }


   



    void DrawLinesParentChildfromRoot()
    {
        GameObject newLineGen2 = Instantiate(LinePrefab2);
        LineRenderer LRend2 = newLineGen2.GetComponent<LineRenderer>();

        LRend2.positionCount = targetPosPC1.Count*2;

        for (int i = 0; i < targetPosPC1.Count; i++)
        {
            LRend2.SetPosition(dec2, rootpos);
            dec2 += 1;
            LRend2.SetPosition(dec2, targetPosPC1[i]);
            dec2 += 1;
        }


    }


    void DrawLinesParentChildfromChild()
    {
        GameObject newLineGen3 = Instantiate(LinePrefab2);
        LineRenderer LRend3 = newLineGen3.GetComponent<LineRenderer>();

        LRend3.positionCount = targetPosPC2.Count * 2;
        index2=targetPosPC1.Count;
        for (int i = 0; i < targetPosPC2.Count; i++)
        {
            LRend3.SetPosition(dec3, targetPosPC1[index2 - 1]);//starts from the last child as per json
            dec3 += 1;
            LRend3.SetPosition(dec3, targetPosPC2[i]);
            dec3 += 1;
        }


    }


    

    void GoCalledInfo()
    {

        string newStr2 = "Recieved Project ID: " + myObject.projectId.ToString() + "\n" + "Received Project Name: " + myObject.projectName + "\n" + "Active structure model last modified: " + myObject.activeStructureModel.lastModified.ToString();

        txt.GetComponent<UnityEngine.TextMesh>().text = newStr2;


    }

    void GoCalledProgress()
    {
        //ProgressB.SetActive(true);
        StartCoroutine(ExecuteAfterTime(5));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        //ProgressB.SetActive(false);
        //reload the whole scene 
    }*/
	
	
	 public void PointerEnter(){
		Debug.Log("Hello I am touched");
	}
}
