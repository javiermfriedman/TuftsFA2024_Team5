using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameObject theGameHandler;
    

    public bool isFront = true;
    public GameObject[] foregroundColliders;
    public GameObject[] backgroundColliders;
    
    public GameObject player;
    //public List<GameObject> foregroundColliders = new List<GameObject>();
    //public List<GameObject> backgroundColliders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //populte both arrays of environment objects
        foregroundColliders = GameObject.FindGameObjectsWithTag("frontColliders");
        backgroundColliders = GameObject.FindGameObjectsWithTag("backColliders");
        
        player = GameObject.FindWithTag("Player");

        UpdateWorldColliders();
    }

    void Awake(){
        if(theGameHandler != null && theGameHandler != this) {
            Destroy(this.gameObject);
        }
        else {
            theGameHandler = this.gameObject;
        }

        DontDestroyOnLoad(theGameHandler);
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetButtonDown("SwitchLayer"))
        //if ((Input.GetKeyDown("s")) || (Input.GetKeyDown("down")))
        {
            SwapFrontBack();
        }
        
        // if (player.transform.position[1] < -7)
        //     gameOver();
    }

    public void SwapFrontBack(){
        //Debug.Log("Trying to Swap Front / Back from front is " + isFront);
        isFront = !isFront;
        player.GetComponent<PlayerOrder>().swapOrder();
        UpdateWorldColliders();
    }

    public void UpdateWorldColliders() {
        //when player is in front:
        if (isFront) {
            //go through foregound collidable objects and set them to collide and be sharp
            for (int i = 0; i < foregroundColliders.Length; i++){
                foregroundColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                foregroundColliders[i].GetComponent<PlatformObject>().SwapSharpBlurry(isFront);
            }
            //go through background collidble objects nd set them to not collide and be blurry
            for (int n = 0; n < backgroundColliders.Length; n++){
                backgroundColliders[n].GetComponent<BoxCollider2D>().enabled = false;
                backgroundColliders[n].GetComponent<PlatformObject>().SwapSharpBlurry(isFront);
            }
        }
        //when player is in back:
        else
        {
            //go through FG collidable objects and set them not colliders and blurry
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

    public void gameOver() {
        Debug.Log("GAME OVER!!");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
