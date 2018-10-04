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
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
