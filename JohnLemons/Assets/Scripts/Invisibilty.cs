using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilty : MonoBehaviour
{
    public bool IsInvisible = false;
    bool IsCooldown = false;

    void Start()
    {
        
    }

    void FixedUpdate() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsInvisible && !IsCooldown)
        {
            StartCoroutine(Invis());
        }
    }

    IEnumerator Invis()
    {
        IsInvisible = true;
        Debug.Log("Invisibilty activated");
        yield return new WaitForSeconds(5);
        IsInvisible = false;
        IsCooldown = true;
        Debug.Log("Invisibilty deactivated");
        yield return new WaitForSeconds(10);
        IsCooldown = false;

        Debug.Log("Cooldown over");
    }
}

