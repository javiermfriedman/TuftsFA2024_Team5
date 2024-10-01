using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour{


    public GameObject artSharp;
    public GameObject artBlurry;

    public bool isFrontArt = true;

    // Start is called before the first frame update
    void Start()
    {
        if (isFrontArt)
        {
            artSharp.SetActive(true);
            artBlurry.SetActive(false);
        }
        else
        {
            artSharp.SetActive(false);
            artBlurry.SetActive(true);
        }
    }

    public void SwapSharpBlurry(bool isPlayerFront){
        if (((isPlayerFront)&&(isFrontArt)) || ((!isPlayerFront) && (!isFrontArt)))
        {
            artSharp.SetActive(true);
            artBlurry.SetActive(false);
        }
        else if(((isPlayerFront) && (!isFrontArt)) || ((!isPlayerFront) && (isFrontArt)))
        {
            artSharp.SetActive(false);
            artBlurry.SetActive(true);
        }
    }




}
