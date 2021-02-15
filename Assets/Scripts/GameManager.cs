using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    public GameObject otherObject;
    public GameObject otherObject_2;

    public GameObject[] blueZones ;
    public GameObject[] redZones ;
    public GameObject Camera;
    
    public Material[] color;

    public List<GameObject> Level = new List<GameObject>();
    public int currentLevel = 1;
    private bool player2 = false;
    public void ShowPanel(GameObject Panel)
    {
        Panel.SetActive(true);
    }
    public void HidePanel(GameObject Panel)
    {
        Panel.SetActive(false);
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        otherObject_2.GetComponent<Movement>().enabled = false;
        otherObject.GetComponent<Movement>().enabled = true;

    }
    //Set le Trigger des Zones en fonction du player
    void SetTriggerZone(GameObject[] zones, bool triggerValue)
    {
        if(zones != null )
        {
            foreach(GameObject g in zones)
            {
                g.GetComponent<Collider>().isTrigger = triggerValue; 

            }
        }
    }


    public void ChangeColor()
    {
        Debug.Log("ChangeColor");
        foreach(GameObject g in blueZones)
        {
            if(g.gameObject.tag=="BlueZone")
            {
                Debug.Log("Change");
                g.gameObject.tag = "RedZone";
                g.gameObject.GetComponent<Renderer>().sharedMaterial = color[1];
                SetTriggerZone(redZones,true);
                SetTriggerZone(blueZones,false);
            }
            else
            {
                g.gameObject.tag = "BlueZone";
                g.gameObject.GetComponent<Renderer>().sharedMaterial = color[0];
                SetTriggerZone(redZones,false);
                SetTriggerZone(blueZones,true);

            }
        }

        foreach(GameObject g in redZones)
        {
            if(g.gameObject.tag == "RedZone")
            {
                g.gameObject.tag = "BlueZone";
                g.gameObject.GetComponent<Renderer>().sharedMaterial = color[0];
                SetTriggerZone(redZones,false);
                SetTriggerZone(blueZones,true);
                
            }
            else
            {
                g.gameObject.tag = "RedZone";
                g.gameObject.GetComponent<Renderer>().sharedMaterial = color[1];
                SetTriggerZone(redZones,true);
                SetTriggerZone(blueZones,false);

            }
        }


    }
    
    void CheckZone()
    {
        if (player2 == true)
        {
            SetTriggerZone(redZones,true);
            SetTriggerZone(blueZones,false);
            Camera.GetComponent<PlayerFollow>().PlayerTransform = otherObject_2.transform;
            otherObject_2.GetComponent<Movement>().enabled = true;
            otherObject.GetComponent<Movement>().enabled = false;
        }
        else if (player2 == false)
        {
            SetTriggerZone(blueZones,true);
            SetTriggerZone(redZones,false);
            Camera.GetComponent<PlayerFollow>().PlayerTransform = otherObject.transform;
            otherObject.GetComponent<Movement>().enabled = true;
            otherObject_2.GetComponent<Movement>().enabled = false;

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        blueZones = GameObject.FindGameObjectsWithTag("BlueZone");
        redZones = GameObject.FindGameObjectsWithTag("RedZone");
    
        CheckZone();

        if (Input.GetButtonDown("Fire1"))
        {
            AudioManager.audioInstance.switchSrc.PlayOneShot(AudioManager.audioInstance.switchClp);

            if (player2 == true)
            {
                
                player2 = false;
            }
            else if (player2 == false)
            {
        
                player2 = true;
            }

            

        }

    

    }
    

}
