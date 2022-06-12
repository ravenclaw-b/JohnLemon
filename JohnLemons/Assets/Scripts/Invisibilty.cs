using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Invisibilty : MonoBehaviour
{
    public bool IsInvisible = false;
    bool IsCooldown = false;
    public GameObject textObject;

    [SerializeField] GameObject bar;

    [SerializeField] Material Glass;
    [SerializeField] Color colorInvis;
    [SerializeField] Color colorVis;

    [SerializeField] Color red;
    [SerializeField] Color green; 
    

    void Start()
    {
        Glass.SetColor("_Color", colorVis);
        Glass.SetFloat("_Mode", 0f);

        bar.GetComponent<Image>().color = Color.green;
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

        Glass.SetColor("_Color", colorInvis);
        Glass.SetFloat("_Mode", 3f);

        for (float i = 5f; i >= 1f; i -= 0.1f) 
        {   
            textObject.GetComponent<Text>().text = ("Inivisible for: " + Mathf.Round(i) + " seconds");
            yield return new WaitForSeconds(0.1f);

            bar.GetComponent<RectTransform>().sizeDelta -= new Vector2 (4.9f, 0);
        }

        IsInvisible = false;
        IsCooldown = true;

        Glass.SetColor("_Color", colorVis);
    Glass.SetFloat("_Mode", 0f);

        Debug.Log("Invisibilty deactivated");

        bar.GetComponent<RectTransform>().sizeDelta = new Vector2 (198, 6);
        bar.GetComponent<Image>().color = Color.red;

        for (float i = 10f; i >= 1; i -= 0.1f) 
        {  
            textObject.GetComponent<Text>().text = ("Cooldown: " + Mathf.Round(i) + " seconds");
            yield return new WaitForSeconds(0.1f);

            bar.GetComponent<RectTransform>().sizeDelta -= new Vector2 (2.2f, 0);
        }

        IsCooldown = false;
        bar.GetComponent<RectTransform>().sizeDelta = new Vector2 (198, 6);
        bar.GetComponent<Image>().color = Color.green;
        
        textObject.GetComponent<Text>().text = ("Invisibilty Available");
        Debug.Log("Cooldown over");
    }
}

