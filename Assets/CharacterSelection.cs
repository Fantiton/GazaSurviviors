using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public void SelectIsrael()
    {
        GameManager.Instance.StartGame(Side.Israel);
        Debug.Log("Izrael");
    }

    public void SelectPalestine()
    {
        Debug.Log("Palestyna");
        GameManager.Instance.StartGame(Side.Palestine);
    }
}
