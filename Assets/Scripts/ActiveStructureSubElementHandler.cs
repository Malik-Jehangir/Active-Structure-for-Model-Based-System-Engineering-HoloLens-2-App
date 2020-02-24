using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ActiveStructureSubElementHandler : MonoBehaviour
{


    float pos = -4.7f;
    public GameObject mygame2;
    public RootObject mainObj = new RootObject();
    string tmp = "";

    void Start()
    {


    }

    public void PointerEnter()
    {
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

    public void GenerateActiveStructure(string tmpStr)
    {
        

        mainObj = JsonUtility.FromJson<RootObject>(tmpStr);
        int index = mainObj.activeStructureModel.subSystemElements.Count - 1;
        for (int y = 0; y < mainObj.activeStructureModel.subSystemElements.Count; y++)
        {

            //Generate a big system element
            GameObject foo2 = GameObject.Instantiate((GameObject)Resources.Load("SubsystemMainElement"));
            foo2.transform.position = new Vector3(1.2866f, -1.37f, -2.14f);
            //set the name of the subsystem element
            foo2.transform.GetChild(1).gameObject.GetComponent<UnityEngine.TextMesh>().text = mainObj.activeStructureModel.subSystemElements[y].name;

            for (int xy = 0; xy < mainObj.activeStructureModel.subSystemElements[y].subSystemElements.Count; xy++)
            {
                //Generate a big system element


                GameObject foo = GameObject.Instantiate((GameObject)Resources.Load("SubsystemElement"));
                foo.transform.position = new Vector3(pos, 0.06f, -3.9f);

                //set the name of the subsystem element
                foo.transform.GetChild(1).gameObject.GetComponent<UnityEngine.TextMesh>().text = mainObj.activeStructureModel.subSystemElements[y].subSystemElements[xy].name + "\nID: " + mainObj.activeStructureModel.subSystemElements[y].subSystemElements[xy].subsystemElementId.ToString();


                pos += 8f; //Each object with a distance of 10f between them towards the right
                if (xy > 0) //widen the main game object in background by this new vector, if more than one element
                {
                    foo2.transform.localScale += new Vector3(0.5f, 0.5f, 0f);

                }
            }
        }
    }
}
