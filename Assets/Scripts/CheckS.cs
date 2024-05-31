using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckS : MonoBehaviour
{
	public int Ya = 0;
    
    // Клік по об'єкту
    void OnMouseDown()
    {
    	if(Ya == 1)
        {
    		Ya = 0;
    		RandomOne.Win -=1;
    		gameObject.GetComponent<SpriteRenderer>().color = new Color32(85,85,85,255);
    		GameObject.Find("Main Camera").gameObject.GetComponent<RandomOne>().CheckWin();
    	} 
        else 
        {
    		gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,0,0,255);
    		GameObject.Find("Main Camera").gameObject.GetComponent<RandomOne>().Fail();
    		print("Fail");
    	}
    }

    public void Go()
    {
    	Ya = 1;
		gameObject.GetComponent<SpriteRenderer>().color = new Color32(85,85,85,255);
		Invoke(nameof(Color), 4f);
    }

    public void Color()
    {
    	gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }

    public void Res()
    {
    	Ya = 0;
    	gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }

    public void PodShow()
    {
    	if(Ya == 1)
        {
    	   gameObject.GetComponent<SpriteRenderer>().color = new Color32(124,255,255,255);
        }
	}
}
