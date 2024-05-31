using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RandomOne : MonoBehaviour
{

	public GameObject[] Cube;
	public int Col = 0;
	private int gg = 0;
	private int che = 0;
	private int ran; 
	public static int Win = 0;

	public GameObject Time;
	public GameObject anitime;
	public GameObject pasttime;
	public GameObject fald;
	public GameObject pal,pal1,pal2;
	public GameObject Rest;
	public GameObject Wini;
	public GameObject Next;
	public GameObject PodCH;


	public GameObject Bl1,Bl2;

	public Text Coin,Key,Blink,KeyTwo;

	public GameObject MoveHomef;
	public GameObject MoveStar;

	public GameObject Backg;

	

	private int scn = 0;

    void Start()
    {
    	Application.targetFrameRate = 60;

    	che = 30;
	        
        pal.SetActive(true);
        pal2.SetActive(true);

        ReMove();

        // Провірка чи є лампочка на балансі
        if(PlayerPrefs.GetInt("Blink") <= 0)
        {
        	Bl1.SetActive(false);
        	Bl2.SetActive(true);
        }

        
        // Провірка яка сцена активна 

        if(SceneManager.GetActiveScene().name == "Game1")
        {
         	scn = 1;
        }

        if(SceneManager.GetActiveScene().name == "Game2")
        {
         	scn = 2;
        }

        if(SceneManager.GetActiveScene().name == "Game3")
        {
         	scn = 3;
        }

        if(SceneManager.GetActiveScene().name == "Game4")
        {
         	scn = 4;
        }


     
    }


    // Оновлення тексту
    public void ReMove()
    {
    	Coin.text = PlayerPrefs.GetFloat("Coin").ToString();
    	Key.text = PlayerPrefs.GetInt("Keys").ToString();
    	Blink.text = PlayerPrefs.GetInt("Blink").ToString();
    	KeyTwo.text = PlayerPrefs.GetInt("Keys") + "/6".ToString();

    	if(PlayerPrefs.GetInt("Blink") > 0)
    	{
        	Bl1.SetActive(true);
        	Bl2.SetActive(false);
        }
    }

    public void ranf()
    {
    	if(scn == 1)
    	{
			ran  = UnityEngine.Random.Range(0,16);
		}
		if(scn == 2)
		{
			ran  = UnityEngine.Random.Range(0,18);
		}
		if(scn == 3)
		{
			ran  = UnityEngine.Random.Range(0,16);
		}
		if(scn == 4)
		{
			ran  = UnityEngine.Random.Range(0,19);
		}

		if(ran == che)
		{
 			ranf();
		} 
		else 
		{
			if(Cube[ran].gameObject.GetComponent<CheckS>().Ya == 1)
			{
				ranf();
			} 
			else 
			{
				i++;
				Cube[ran].gameObject.GetComponent<CheckS>().Go();
				che = ran;
				Ran();
			}
		}
    }



    // Присвоєння елеменетам значення Ya = 1
    int i = 0;
    public void Ran()
    {
		if(i < Col)
		{
			if(scn == 1)
			{
				ran  = UnityEngine.Random.Range(0,16);
			}
			if(scn == 2)
			{
				ran  = UnityEngine.Random.Range(0,18);
			}
			if(scn == 3)
			{
				ran  = UnityEngine.Random.Range(0,16);
			}
			if(scn == 4)
			{
				ran  = UnityEngine.Random.Range(0,19);
			}

			if(ran == che)
			{		
			 	ranf();		
			} 
			else 
			{			
				if(Cube[ran].gameObject.GetComponent<CheckS>().Ya == 1) // Провірка якщо елемент вже присвоєний
				{
					ranf();
				} 
				else
				{
					i++;
					Cube[ran].gameObject.GetComponent<CheckS>().Go(); // Виклик присвоєння
					che = ran;
					Ran();
				}
			}
		}
	}

	// Анімація появлення кнопки Старт
	public void stt()
	{
		MoveHomef.GetComponent<Animator>().SetTrigger("MovToHome");
	}


	// Клік Старт і рестарт
	public void stat()
	{
		Time.SetActive(true);
		pal1.SetActive(true);
		pal2.SetActive(true);
		
		MoveStar.GetComponent<Animator>().SetTrigger("MovToHomeg"); // Анімація скриття кнопки Старт

		// Провірка складності гри і присвоєння кількості елементів 
		if(PlayerPrefs.GetInt("Mode") == 1)
		{
    		Col = UnityEngine.Random.Range(2,6);
    	}
    	if(PlayerPrefs.GetInt("Mode") == 2)
    	{
    		Col = UnityEngine.Random.Range(6,10);
    	}
    	if(PlayerPrefs.GetInt("Mode") == 3)
    	{
    		Col = UnityEngine.Random.Range(7,13);
    	}
    	
    	Win = Col;

		StartCoroutine(statplay());		
	}

	// Корутина підготовки
	public IEnumerator statplay()
	{ 
		yield return new WaitForSeconds(2f); 
 		anitime.SetActive(true);
		yield return new WaitForSeconds(0.5f); 
		Ran();
		yield return new WaitForSeconds(0.5f); 
 		Time.SetActive(false);
 		yield return new WaitForSeconds(0.5f); 
 		pasttime.SetActive(true);
		yield return new WaitForSeconds(0.7f); 
		anitime.SetActive(false);		
		yield return new WaitForSeconds(2.5f);
		 pal.SetActive(false);
		 pal2.SetActive(false);
		yield return new WaitForSeconds(0.3f); 
		pasttime.SetActive(false);
	}

	// Програш
	public void Fail()
	{
		pal.SetActive(true);
		pal2.SetActive(true);
		pal1.SetActive(false);
		fald.SetActive(true);
		Rest.SetActive(true);
		
		MoveHomef.GetComponent<Animator>().SetTrigger("MoveToGo");		
	}

	

	public void Re()
	{
		stat();
		Rest.SetActive(false);
		fald.SetActive(false);
	}


	// Клік кнопки Рестарт
	public void Restar()
	{
		// Провірка кількості елементів на сцені і обнулення їх значення Ya = 0
		if(scn == 1)
		{
			for(int i = 0; i < 16; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}
	
		if(scn == 2)
		{
			for(int i = 0; i < 18; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}
	
		if(scn == 3)
		{
			for(int i = 0; i < 16; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}
	
		if(scn == 4)
		{
			for(int i = 0; i < 19; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}

		che = 20;
		i = 0;
		Win = Col;
		Invoke(nameof(Re), 0.6f);
		MoveHomef.GetComponent<Animator>().SetTrigger("MovToHome");
		fald.GetComponent<Animator>().SetTrigger("GoFal");
		Rest.GetComponent<Animator>().SetTrigger("GoHome");
		
	}

	// Провірка на наявність активних елементів.
	public void CheckWin()
	{
		if(Win <= 0)
		{
			Wini.SetActive(true);	
			pal.SetActive(true);
			Next.SetActive(true);
			MoveHomef.GetComponent<Animator>().SetTrigger("MoveToGo");
	
			Invoke(nameof(WInd), 0.5f);
		}	
	}

	// Ключ за пройдений лвл
	public void WInd()
	{
		pal2.SetActive(true);
		pal1.SetActive(false);		
		PlayerPrefs.SetInt("Keys", PlayerPrefs.GetInt("Keys") +1);
		ReMove();
	}


	public void Wnd()
	{
		stat();
		Wini.SetActive(false);
		Next.SetActive(false);
	}

	// Клік на кнопку Далі
	public void Nex()
	{
		// Провірка кількості елементів на сцені і обнулення їх значення Ya = 0
		if(scn == 1)
		{
			for(int i = 0; i < 16; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}
	
		if(scn == 2)
		{
			for(int i = 0; i < 18; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}
	
		if(scn == 3)
		{
			for(int i = 0; i < 16; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}
	
		if(scn == 4)
		{
			for(int i = 0; i < 19; i++)
			{
				Cube[i].gameObject.GetComponent<CheckS>().Res();
			}
		}

		MoveHomef.GetComponent<Animator>().SetTrigger("MovToHome");
		Wini.GetComponent<Animator>().SetTrigger("GoFal");
		Next.GetComponent<Animator>().SetTrigger("GoNex");
		Invoke(nameof(Wnd), 0.6f);
		che = 20;
		i = 0;
		Win = Col;
	}
           

	// Клік на лампочку
	public void Podskazka()
	{
		if(PlayerPrefs.GetInt("Blink") > 0)
		{
			if(scn == 1)
			{
				for(int i = 0; i < 16; i++)
				{
					Cube[i].gameObject.GetComponent<CheckS>().PodShow();
				}
			}

			if(scn == 2)
			{
				for(int i = 0; i < 18; i++)
				{
					Cube[i].gameObject.GetComponent<CheckS>().PodShow();
				}
			}		

			if(scn == 3)
			{
				for(int i = 0; i < 16; i++)
				{
					Cube[i].gameObject.GetComponent<CheckS>().PodShow();
				}
			}

			if(scn == 4)
			{
				for(int i = 0; i < 19; i++)
				{
					Cube[i].gameObject.GetComponent<CheckS>().PodShow();
				}
			}
			
			PlayerPrefs.SetInt("Blink", PlayerPrefs.GetInt("Blink") -1);
			ReMove();
			
			if(PlayerPrefs.GetInt("Blink") <= 0)
			{
        		Bl1.SetActive(false);
        		Bl2.SetActive(true);
        	}

		} 
		else 
		{
			PodCH.SetActive(true);
			pal.SetActive(true);
			Backg.SetActive(true);
		}
	}

	// Обмін валюти на лампочку
	public void Change()
	{
		if(PlayerPrefs.GetFloat("Coin") > 0)
		{
			PlayerPrefs.SetInt("Blink", PlayerPrefs.GetInt("Blink") +1);
			PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") -1);			
			ReMove();
		}
	}

	public void MoveHome()
	{
		SceneManager.LoadScene("Start");
	}


}
