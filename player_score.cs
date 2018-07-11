using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_score : MonoBehaviour {

    private GameObject[] pickups;

    private int pickupCount;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject YouWinPopUp;

    [SerializeField]
    private Text YouWinPopUpText;


    private void Start()
    {
        Time.timeScale=1;
        pickups = GameObject.FindGameObjectsWithTag("pickups");
        pickupCount = pickups.Length;
        scoreText.text = pickupCount.ToString() + "PICKUPS LEFT";
        YouWinPopUp.SetActive(false);
    }

    private void Update()
    {
        if (pickupCount==0)
        {
            if (YouWinPopUp.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                YouWinPopUp.SetActive(true);
                YouWinPopUpText.text = "You Win";
                Debug.Log("you win");

            }
           
        }

    }

    private void OnTriggerEnter(Collider collider)
    {if(collider.tag=="pickups")
        {
            pickupCount--;
            scoreText.text = pickupCount.ToString() + "PICKUPS LEFT";
            GameObject.Destroy(collider.gameObject);
            print("picked up");
        }
       
    }
}
