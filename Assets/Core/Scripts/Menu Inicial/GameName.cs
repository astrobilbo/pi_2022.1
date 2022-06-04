using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameName : MonoBehaviour
{
    TextMeshProUGUI gameName;
    void Awake()
    {
        gameName = gameObject.GetComponentInParent < TextMeshProUGUI > ();
        gameName.text = Application.productName;
    }

}
