using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] GameObject[] Itens;
    bool haveDrop = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CallDrop(Transform position)
    {
        if (haveDrop) return;
        print("Dropando item " + Itens[RandomItem()]);
        Instantiate(Itens[RandomItem()], position);
        haveDrop = true;
    }
    int RandomItem()
    {
        return Random.Range(0, Itens.Length);
    }
}
