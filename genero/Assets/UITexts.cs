using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITexts : MonoBehaviour
{
    public CharacterManager character;
    public void OnEndAnim()
    {
        character.Reset();
    }
}
