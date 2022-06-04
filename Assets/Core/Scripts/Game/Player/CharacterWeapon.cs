using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    bool HaveAtacking;
    Collider target;
    [SerializeField] Character character;
    float damage;
    void Update()
    {
        Damage();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            target = other;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other = target)
        {
            target = null;
        }


    }
    void Damage()
    {
        if (!character.isAtacking && HaveAtacking)
        {
            HaveAtacking = false;
        }
        if (character.isAtacking && !HaveAtacking)
        {
            damage = character.AttackDamage;
        }
        if (character.isAtacking && HaveAtacking)
        {
            damage = 0;
        }
        if (character.isAtacking && target != null && !HaveAtacking)
        {
            print(damage);
            target.gameObject.GetComponentInParent<EnemyControll>().Damage(damage);
            HaveAtacking = true;
        }

    }

}
