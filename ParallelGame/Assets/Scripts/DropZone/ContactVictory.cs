using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class ContactVictory : MonoBehaviour, IDropAction
{
    private bool active = false;
    private bool contact = false;

    private SpriteRenderer sr;
    [SerializeField] private Sprite Inactive;
    [SerializeField] private Sprite Active;

    [SerializeField] private bool startActive;
    [SerializeField] private string nextLevel;

    public void OnActionCompleted()
    {
        if (startActive)
        {
            active = false;
        }
        else
        {
            active = true;
        }

        SwitchSprite();
    }

    public void OnActionReversed()
    {
        if (startActive)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        SwitchSprite();
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        if (startActive)
        {
            active = true;            
        }

        SwitchSprite();
    }

    private void OnTriggerEnter(Collider other)
    {
        TwinCharacterController twin = other.GetComponent<TwinCharacterController>();
        if (twin != null)
        {
            print("contact");
            contact = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        TwinCharacterController twin = other.GetComponent<TwinCharacterController>();
        if (twin != null)
        {
            contact = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active && contact)
        {
            print("win");
            SceneManager.LoadScene(nextLevel);
        }
    }
    
    private void SwitchSprite()
    {
        //print("Switch");
        
        if (active)
        {
            sr.sprite = Active;
        }
        else
        {
            sr.sprite = Inactive;
        }
    }
}
