using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoGame : MonoBehaviour
{

    void Start()
    {
        Invoke(nameof(Kf), 1.3f);
    }

    public void Kf()
    {
        SceneManager.LoadScene("Start");
    }
}
