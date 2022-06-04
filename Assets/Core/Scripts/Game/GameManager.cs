using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playing=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(playing)
        Cursor.lockState = CursorLockMode.Locked;
        else
         Cursor.lockState = CursorLockMode.Confined;
    }
    public void ChangePlay(bool playingChange){playing=playingChange;}
}
