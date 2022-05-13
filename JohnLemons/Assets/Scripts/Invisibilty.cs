using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Invisibilty : MonoBehaviour
{
    public bool IsInvisible = false;
    bool IsCooldown = false;
    public GameObject textObject; 

    void Start()
    {
        Material glass = Resources.Load("Glass", typeof(Material)) as Material;
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

        for (int i = 5; i >= 1; i--) 
        {   
            textObject.GetComponent<Text>().text = ("Inivisible for: " + i.ToString() + " seconds");
            yield return new WaitForSeconds(1);
        }

        IsInvisible = false;
        IsCooldown = true;
        Debug.Log("Invisibilty deactivated");

        for (int i = 10; i >= 1; i--) 
        {   
            textObject.GetComponent<Text>().text = ("Cooldown: " + i.ToString() + " seconds");
            yield return new WaitForSeconds(1);
        }
        IsCooldown = false;
        
        textObject.GetComponent<Text>().text = ("Invisibilty Available");
        Debug.Log("Cooldown over");
    }
}

