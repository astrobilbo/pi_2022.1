using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project1.Dialogue;
public class Friend : MonoBehaviour
{
    [Range(0, 3)] public int level = 0;
    [SerializeField] Dialogue[] dialogos;
    bool level1Done, level2Done, level3Done, level4Done, level5Done;
    AIConversant aIConversant;
    CharacterAttack playerAttack;
    void Start()
    {
        aIConversant = GetComponent<AIConversant>();
        playerAttack = GetComponentInParent<CharacterAttack>();
    }
    public void level1()
    {
        if (level1Done) return;
        level++;
        aIConversant.dialogue = dialogos[0];
        aIConversant.ActiveConversation();
        level1Done = true;
    }
    public void level2()
    {
        if (level2Done) return;
        level++;

        level2Done = true;

    }
    public void level3()
    {
        if (level3Done) return;
        level++;
        playerAttack.attackEvolve += 12.5F;

        level3Done = true;

    }
    public void level4()
    {
        if (level4Done) return;
        level++;

print("AindaNaoDisponivel");

        level4Done = true;

    }
    public void level5()
    {
        if (level5Done) return;
        level++;
        playerAttack.attackEvolve += 12.5F;
        level5Done = true;
    }

}
