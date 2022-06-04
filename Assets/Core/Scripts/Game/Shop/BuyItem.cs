using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class BuyItem : MonoBehaviour
{
    [SerializeField] int price; //aqui defino o preço
    [SerializeField] UnityEvent compraActions = new UnityEvent(); //aqui chamo a açao no robo se tiver comprado
    [SerializeField] Character character;//aqui verifico se tenho o valor
    [SerializeField] TextMeshProUGUI sucataText;
    public void Compra()
    {
        if (character.sucatas < price)
        {
            Debug.Log("vai matar robos");
            return;
        }
        character.sucatas -= price;
        compraActions.Invoke();
        AtualizaSucatas();
    }
    public void AtualizaSucatas()
    {
        sucataText.text=character.sucatas+" sucatas no inventario.";
    }
}
