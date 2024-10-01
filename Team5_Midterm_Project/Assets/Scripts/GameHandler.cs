using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public bool isFront = true;
    public GameObject[] foregroundColliders;
    public GameObject[] backgroundColliders;
    //public List<GameObject> foregroundColliders = new List<GameObject>();
    //public List<GameObject> backgroundColliders = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        foregroundColliders = GameObject.FindGameObjectsWithTag("frontColliders");
        backgroundColliders = GameObject.FindGameObjectsWithTag("backColliders");

        UpdateWorldColliders();
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetButtonDown("SwitchLayer"))
        //if ((Input.GetKeyDown("s")) || (Input.GetKeyDown("down")))
        {
            SwapFrontBack();
        }
        
    }

    public void SwapFrontBack(){
        Debug.Log("Trying to Swap Front / Back from front is " + isFront);
        isFront = !isFront;
        UpdateWorldColliders();
    }

    public void UpdateWorldColliders() {
        if (isFront) {
            for (int i = 0; i < foregroundColliders.Length; i++){
                foregroundColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                foregroundColliders[i].GetComponent<PlatformObject>().SwapSharpBlurry(isFront);
            }
            for (int n = 0; n < backgroundColliders.Length; n++){
                backgroundColliders[n].GetComponent<BoxCollider2D>().enabled = false;
                backgroundColliders[n].GetComponent<PlatformObject>().SwapSharpBlurry(isFront);
            }
        }
        else
        {
            for (int i = 0; i < foregroundColliders.Length; i++)
            {
                foregroundColliders[i].GetComponent<BoxCollider2D>().enabled = false;
                foregroundColliders[i].GetComponent<PlatformObject>().SwapSharpBlurry(isFront);
            }
            for (int n = 0; n < backgroundColliders.Length; n++)
            {
                backgroundColliders[n].GetComponent<BoxCollider2D>().enabled = true;
                backgroundColliders[n].GetComponent<PlatformObject>().SwapSharpBlurry(isFront);
            }
        }
    }

}
