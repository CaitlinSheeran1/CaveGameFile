using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
   
    public static KillCounter Instance;
    public int killCounter = 0;
    public TMP_Text killText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public void AddKill()
    {
        killCounter++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (killText != null)
        {
            killText.text = ""+ killCounter + "";
        }
    }

}
