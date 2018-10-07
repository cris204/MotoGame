using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterScriptableObj : ScriptableObject
{
    public string characterName;
    public Sprite artCharacter;
    public float life;
}
