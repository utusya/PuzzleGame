using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Swip : MonoBehaviour
{
  public Text Coin;

  public GameObject a1,a2,a3;
  public int hh;
  public string kk;
   
  public void Start()
  {
    Coin.text = PlayerPrefs.GetFloat("Coin").ToString();
  
    Rbg();
    Invoke(nameof(hhr), 0.05f);
  }

  // Оновлення тексту балансу
  public void Rbg()
  {
    float bf = ((int)(PlayerPrefs.GetFloat("Coin") * 10f)) / 10f;   // Заокрулення числа після коми
    Coin.text = bf.ToString();
  }

  // Провірка режиму складності гри
  public void hhr()
  {
    if(PlayerPrefs.GetInt("Mode") == 0)
    {
      a1.GetComponent<Toggle>().isOn = true;
      a2.GetComponent<Toggle>().isOn = false;
    } 
    else 
    {
      if(PlayerPrefs.GetInt("Mode") == 1)
      {
        a1.GetComponent<Toggle>().isOn = true;
        a2.GetComponent<Toggle>().isOn = false;
        a3.GetComponent<Toggle>().isOn = false;
      }
      if(PlayerPrefs.GetInt("Mode") == 2)
      {
        a1.GetComponent<Toggle>().isOn = false;
        a2.GetComponent<Toggle>().isOn = true;
        a3.GetComponent<Toggle>().isOn = false;
      }
      if(PlayerPrefs.GetInt("Mode") == 3)
      {
        a1.GetComponent<Toggle>().isOn = false;
        a2.GetComponent<Toggle>().isOn = false;
        a3.GetComponent<Toggle>().isOn = true;
      }
    }

    if(a1.GetComponent<Toggle>().isOn == true)
    {
      kk = a1.name;
      int.TryParse(kk, out hh);
      PlayerPrefs.SetInt("Mode", hh);
    }

    if(a2.GetComponent<Toggle>().isOn == true)
    {
      kk = a2.name;
      int.TryParse(kk, out hh);
      PlayerPrefs.SetInt("Mode", hh);
    }

    if(a3.GetComponent<Toggle>().isOn == true)
    {
      kk = a3.name;
      int.TryParse(kk, out hh);
      PlayerPrefs.SetInt("Mode", hh);
    }
  }


  // Вибір режиму складності гри
  public void Che(){
  
    if(a1.GetComponent<Toggle>().isOn == true)
    {
      kk = a1.name;
      int.TryParse(kk, out hh);
      PlayerPrefs.SetInt("Mode", hh);
    }

    if(a2.GetComponent<Toggle>().isOn == true)
    {
      kk = a2.name;
      int.TryParse(kk, out hh);
      PlayerPrefs.SetInt("Mode", hh);
    }

    if(a3.GetComponent<Toggle>().isOn == true)
    {
      kk = a3.name;
      int.TryParse(kk, out hh);
      PlayerPrefs.SetInt("Mode", hh);
    }
  }


  // Перехід на сцену
  public void dod(string scense)
  {
 	  SceneManager.LoadScene(scense);
  }
}
