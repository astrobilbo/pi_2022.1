using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region variaveis
    public GameManager gameManager;
    [HideInInspector]public Animator anim;
    [HideInInspector]public CharacterController player;
    [HideInInspector]public CharacterMove playerMove;
    [HideInInspector]public CharacterAttack playerAttack;
    public LayerMask groundMask;
    [HideInInspector,Range(0, 100)] public float live = 100;
    [HideInInspector] public int sucatas = 0;
    bool alive=true;
    public bool isAtacking;
    public float AttackDamage;
    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        playerMove = GetComponent<CharacterMove>();
        playerAttack = GetComponent<CharacterAttack>();
    }
    private void Update()
    {
        if (gameManager.playing && alive)
            Alive();
    }

    private void Alive()
    {
        if (live <= 0)
        {
            anim.Play("Dead", 0);
            alive = false;
            return;
        }
        playerMove.Move();
        playerAttack.Attacks();
    }

}