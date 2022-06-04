using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameVersion : MonoBehaviour
{
    TextMeshProUGUI VersionTxt;
    private void Awake()
    {
        if (VersionTxt==null)
        {
            VersionTxt = gameObject.GetComponent<TextMeshProUGUI>();
        }
        VersionTxt.text = "V: " + Application.version;
    }
}
