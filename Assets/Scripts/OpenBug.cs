using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenBug : MonoBehaviour
{

	public GameObject Obj1,Obj2,ObjGlav;
	public Text col;
	float Monyb;
    public Text Ke;

    float MinMon;
    float Mon;
    float Mony;
    int CCh;
    int CC;

    void Start()
    {
       // PlayerPrefs.SetInt("Keys", 20);
    }

    



    // Провірка чи достатньо ключів щоб відкрити кейс
    public void ChOp()
    {
     	if(PlayerPrefs.GetInt("Keys") >= 6)
        {
     		Rengen();
            PlayerPrefs.SetInt("Keys", PlayerPrefs.GetInt("Keys") - 6);
            GameObject.Find("Main Camera").gameObject.GetComponent<RandomOne>().ReMove();
     	} 
        else StartCoroutine(va());
     }


    // Графічно показує що ключів не достатньо
    public IEnumerator va()
    { 
        Ke.GetComponent<Text>().color = new Color32(255,0,0,255);
        yield return new WaitForSeconds(1f); 
        Ke.GetComponent<Text>().color = new Color32(60,60,60,255);
    }


    // Почерговий вибір винагороди (або лампочка або валюта)
    public void  Rengen()
    { 
        CCh = 2;
        CC++;

        if(CC == CCh)
        {
            openCoi();
            CC = 0;
        } 
        else 
        {
            openPod();
        }
    }


    // Відриття меню отримання підказки
    public void openPod()
    {
        ObjGlav.SetActive(false);
        Obj1.SetActive(true);
	}


    // Відриття меню отримання валюти
    public void openCoi()
    {
		Obj2.SetActive(true);   
        ObjGlav.SetActive(false);

        Mony = 0;
        Mony = PlayerPrefs.GetFloat("Coin");
   
        CCh = 1;
        MinMon = 1f;
        Mon = 10f;

        float ran = UnityEngine.Random.Range(MinMon,Mon); 
	    Monyb = ((int)(ran * 10f)) / 10f;

	    col.text = Monyb.ToString();
    }


    // Отримання підказки
	public void TakePod()
    {
        PlayerPrefs.SetInt("Sunk1", PlayerPrefs.GetInt("Sunk1") +1);
		PlayerPrefs.SetInt("Blink", PlayerPrefs.GetInt("Blink") +1);
		GameObject.Find("Main Camera").gameObject.GetComponent<RandomOne>().ReMove();
	}


    // Отримання Валюти
	public void TakeCoi()
    {
        ObjGlav.SetActive(true);
        PlayerPrefs.SetInt("Sundi",PlayerPrefs.GetInt("Sundi") + 1);
		PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") + Monyb);
		GameObject.Find("Main Camera").gameObject.GetComponent<RandomOne>().ReMove();
	}
}
