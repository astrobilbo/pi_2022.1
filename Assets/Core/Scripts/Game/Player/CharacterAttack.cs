using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    #region variaveis
    Character character;
    bool hited;
    float holdTime;
    public float attackEvolve=25;
    #endregion

    #region Metodos
  void Start()
    {
    character=GetComponent<Character>();
    }
    public void Attacks()
    {
        if (!hited && !character.isAtacking && Input.GetMouseButtonDown(0))
        {
            holdTime = Time.time;

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - holdTime < 1f)
            {
                character.isAtacking = true;
                character.AttackDamage=attackEvolve*1;
                character.anim.Play("Attack", 1);
                Invoke("FinishAttacks", 0.7f);
            }
            if (Time.time - holdTime >= 1f)
            {
                character.isAtacking = true;
                character.AttackDamage=attackEvolve*2;
                character.anim.Play("Attack1", 1);
                Invoke("FinishAttacks", 1.4f);
            }

        }

    }
    private void FinishAttacks()
    {

        character.isAtacking = false;

    }
    public IEnumerator Damage(float damage)
    {
        hited = true;
        //live -= damage;
        //anim.Play("Hit", 0x1);
        yield return new WaitForSeconds(0.9f);
        hited = false;
    }
    #endregion
}