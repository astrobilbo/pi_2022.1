using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControll : MonoBehaviour
{
    Drops drops => GetComponent<Drops>();
    [Range(0, 100)] public float live = 100;
    public GameObject[] internalParts;
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
      void Start()
    {navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void Damage(float damage)
    {
        print(damage);
        live -= damage;
        Alive();
    }
    void Alive()
    {
        if (live <= 0)
        {
            for (int i = 0; i < internalParts.Length; i++)
            {
                Destroy(internalParts[i]);
                
            }
            drops.CallDrop(this.transform);
            navMeshAgent.enabled=false;
        }
    }

    [ContextMenu("test")]
    void test()
    {
        Damage(50);
    }
}
