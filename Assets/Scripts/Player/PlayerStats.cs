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
    public string idRef;

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

    public void Damage(string id, float damage)
    {
        if (idRef == id)
        {
            Life -= damage;
            PlayerStats.Instance.idRef = "";
            Debug.Log(Life);
        }
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
