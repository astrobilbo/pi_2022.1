using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Character character;
    public Slider barra_de_vida;
    public TextMeshProUGUI sucatasUi;
    void Update()
    {
        barra_de_vida.value = character.live;
        sucatasUi.text = character.sucatas.ToString();

    }
}
