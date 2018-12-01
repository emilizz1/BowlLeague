using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
	void Awake ()
    {
        int gameInstances = FindObjectsOfType<Quit>().Length;
        if(gameInstances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
	}
	
	void Update ()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}
}
