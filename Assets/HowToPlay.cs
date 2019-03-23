using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject howToPlayText;
    [SerializeField] GameObject gameName;

    void Start()
    {
        howToPlayText.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        howToPlayText.SetActive(true);
        gameName.SetActive(false);
    }
}
