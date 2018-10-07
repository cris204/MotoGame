using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            return instance;
        }
    }


    [SerializeField]
    private float life;
    [SerializeField]
    private float gas;
    [SerializeField]
    private SpriteRenderer characterSprite;
    
    public CharacterScriptableObj character;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        characterSprite = GetComponent<SpriteRenderer>();
        life = character.life;
        characterSprite.sprite = character.artCharacter;
    }

    public void Damage(float damage)
    {
        Life-=damage;
    }

    #region GettersAndSetters

    public float Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }

    public float Gas
    {
        get
        {
            return gas;
        }

        set
        {
            gas = value;
        }
    }

    #endregion

}
