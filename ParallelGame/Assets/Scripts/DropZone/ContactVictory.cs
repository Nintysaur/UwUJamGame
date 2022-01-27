using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactVictory : MonoBehaviour, IDropAction
{
    private bool active = false;
    private bool contact = false;

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

        print(active);
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
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startActive)
        {
            active = true;
        }
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
}
