using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    Character character;
    Collider sucata;
    [SerializeField] GameObject Dica;
    void Start()
    {
        character = GetComponent<Character>();
        }
    void Update()
    {
        Colect();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            sucata=other;
            Dica.SetActive(true);

        }


    }
     void OnTriggerExit(Collider other)
    {
        if (other=sucata)
        {
            sucata=null;
            Dica.SetActive(false);
        }


    }
    void Colect()
    {
        if ( sucata!=null && Input.GetKeyUp(KeyCode.F))
        {
            character.sucatas++;
            Destroy(sucata.gameObject);
            sucata=null;
            Dica.SetActive(false);
        }
    }

}
