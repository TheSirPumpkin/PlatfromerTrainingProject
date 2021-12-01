using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MetamaskAccountTextSetter : MonoBehaviour
{
    private TMP_Text accountText;
    void Start()
    {
        accountText = GetComponent<TMP_Text>();
        accountText.text = PlayerPrefs.GetString("Account");
    }
}
