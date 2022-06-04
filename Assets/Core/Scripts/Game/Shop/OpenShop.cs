using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenShop : MonoBehaviour
{

    public GameManager gameManager;
    Collider player;
    [SerializeField] GameObject Dica;
    [SerializeField]CanvasGroup Shop;
    
    void Update()
    {
        PlayerInRange();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player=other;
            Dica.SetActive(true);
        }


    }
     void OnTriggerExit(Collider other)
    {
        if (other=player)
        {
            player=null;
            Dica.SetActive(false);
        }


    }
    void PlayerInRange()
    {
        if ( player!=null && Input.GetKeyUp(KeyCode.F))
        {
            Shop.alpha=1;
            Shop.blocksRaycasts=true;
            gameManager.playing=false;
            Shop.GetComponentInChildren<BuyItem>().AtualizaSucatas();
        }
    }
}
