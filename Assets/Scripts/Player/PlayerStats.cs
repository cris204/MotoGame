using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private static PlayerStats instance;
    public static PlayerStats Instance {
        get {
            return instance;
        }
    }

    [SerializeField] private float life;
    [SerializeField] private float gas;
    [SerializeField] private SpriteRenderer characterSprite;

    public CharacterScriptableObj character;
    PlayerController playerController;
    PlayerAnimationController playerAnimationController;

    private void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy (this.gameObject);
        }
        characterSprite = GetComponent<SpriteRenderer> ();
        playerController = GetComponent<PlayerController> ();
        playerAnimationController = GetComponent<PlayerAnimationController> ();
        playerController.enabled = true;
        life = character.life;
        characterSprite.sprite = character.artCharacter;
    }

    public void Damage (float damage) {
        Life -= damage;
        if (Life <= 0) {
            GameManager.Instance.GameOver ();
            playerAnimationController.Death ();
            playerController.enabled = false;
        } else
            playerAnimationController.Damage ();
    }

    #region GettersAndSetters

    public float Life {
        get {
            return life;
        }

        set {
            life = value;
        }
    }

    public float Gas {
        get {
            return gas;
        }

        set {
            gas = value;
        }
    }

    #endregion

}