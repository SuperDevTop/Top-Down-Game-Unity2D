using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject inventoryObject;    
    public GameObject hpObject;
    public GameObject particleObject;
    public GameObject invButtonObject;
    public GameObject statusButtonObject;
    public GameObject settingButtonObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAfterClick()
    {
        inventoryObject.SetActive(false);
        inventoryObject.SetActive(true);              
        invButtonObject.SetActive(false);
        invButtonObject.SetActive(true);
        statusButtonObject.SetActive(false);
        statusButtonObject.SetActive(true);
        settingButtonObject.SetActive(false);
        settingButtonObject.SetActive(true);               
        StartCoroutine(DelayWhileAnimation());
    }   

    IEnumerator DelayWhileAnimation()
    {
        yield return new WaitForSeconds(1.21f);

        //inventoryObject.GetComponent<Animator>().enabled = false;
        //inventoryColseObject.SetActive(false);
        //hpObject.GetComponent<Animator>().enabled = false;
        //invButtonObject.GetComponent<Animator>().enabled = false;
        //statusButtonObject.GetComponent<Animator>().enabled = false;
        //settingButtonObject.GetComponent<Animator>().enabled = false;
        hpObject.SetActive(false);
        particleObject.SetActive(false);
    }
}
