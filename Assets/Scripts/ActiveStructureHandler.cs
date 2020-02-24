using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ActiveStructureHandler : MonoBehaviour
{


    public GameObject mygame;
	public RootObject mainObj = new RootObject();
    string tmp = "";
    float pos = -1.32f;

    void Start()
    {

 
    }
	
	public void PointerEnter(){
        StartCoroutine(GetText());
		}
	
   IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.myjson.com/bins/qn9jc");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            tmp = www.downloadHandler.text;
           GenerateActiveStructure(tmp);
        }
    }

	public void GenerateActiveStructure(string tmpStr){

        mainObj = JsonUtility.FromJson<RootObject>(tmpStr);
        
        mygame = GameObject.Find("system Element");
        mygame.transform.GetChild(1).gameObject.GetComponent<UnityEngine.TextMesh>().text = "Recieved Project ID: " + mainObj.projectId.ToString() + "\n" + "Received Project Name: " + mainObj.projectName + "\n" + "Active structure model last modified: " + mainObj.activeStructureModel.lastModified.ToString();



        int counter = 0;
        //creation of sub system elements
        for (int x = 0; x < mainObj.activeStructureModel.subSystemElements.Count; x++)
        {
            counter += 1;

            GameObject foo = GameObject.Instantiate((GameObject)Resources.Load("SubsystemElement"));
            foo.transform.position = new Vector3(pos, -0.01f, 5.26f);

            //set the name of the subsystem element
            foo.transform.GetChild(1).gameObject.GetComponent<UnityEngine.TextMesh>().text = mainObj.activeStructureModel.subSystemElements[x].name + "\nID: "+mainObj.activeStructureModel.subSystemElements[x].subsystemElementId.ToString();


            pos += 8f; //Each object with a distance of 10f between them towards the right
            if (x > 0) //widen the main game object in background by this new vector, if more than one element
            {
                mygame.transform.localScale += new Vector3(0.5f, 0.5f, 0f); 

            }

        }
        Debug.Log("There were " + counter.ToString() + " Sub system Element(s)");
    }
}
