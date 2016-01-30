using UnityEngine;
using System.Collections;

public class WordInteraction : InteractionBase
{

    public string word;
    private string spelling;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            spelling += Input.inputString;

            if (spelling.Contains(word))
            {
                spelling = "";
                base.OnInteractionSuccess();
            }
        }
    }
}