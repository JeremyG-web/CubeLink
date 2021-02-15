using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndZone : MonoBehaviour
{
    private bool player_1 = false;
    private bool player_2 = false;

    public GameObject panel;
    public int nbFinish;
    public Text finishText;
    public GameManager gameManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player_1")
        {
           
            player_1 = true;
            nbFinish+=1;
            AudioManager.audioInstance.finishSrc.PlayOneShot(AudioManager.audioInstance.finishClp);

        }
        else if (other.gameObject.tag == "Player_2")
        {
            player_2 = true;
            nbFinish+=1;
            AudioManager.audioInstance.finishSrc.PlayOneShot(AudioManager.audioInstance.finishClp);


        }

        if ( player_1 == true && player_2 == true )
        {
            gameManager.ShowPanel(panel);
            
        }
        

    }
    void Update()
    {
        finishText.text = " Finish : " + nbFinish.ToString() + "/2";
    }
}
