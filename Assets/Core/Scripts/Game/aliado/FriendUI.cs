using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FriendUI : MonoBehaviour
{
    public Friend friend;
    public Slider barra_de_vida;


    void Start()
    {

    }

    void Update()
    {

        barra_de_vida.value = friend.level;
    }
}
