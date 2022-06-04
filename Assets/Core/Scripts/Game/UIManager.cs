using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] CanvasGroup options;
    bool before;
    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameManager.playing)
            { DesactiveOptions(); }
            else if (gameManager.playing)
            { ActiveOptions(); }
        }
    }

    void ActiveOptions()
    {
        before = gameManager.playing;
        gameManager.playing = false;
        options.alpha = 1;
        options.blocksRaycasts = true;
    }
    public void DesactiveOptions()
    {

        gameManager.playing = before;
        options.alpha = 0;
        options.blocksRaycasts = false;
    }

}
