using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    public TMP_Text contador_kills, contador_tiempo, playerHP;
    private int kills = 0, HP;

    private void Start()
    {
        HP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().ReturnHP();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        HP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().ReturnHP();
        playerHP.text = "HP: " + HP.ToString();
        contador_tiempo.text = "Time using app: " + Mathf.Round(Time.time).ToString();
        contador_kills.text = "Kills: " + kills.ToString();
    }

    public void NewKill()
    {
        kills++;
    }
}
