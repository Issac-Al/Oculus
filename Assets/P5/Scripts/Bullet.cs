using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Colision");
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("Spawn").GetComponent<EnemySpawner>().EnemiesRemove(other.gameObject);
            GameObject.FindGameObjectWithTag("GUI").GetComponent<GUI>().NewKill();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
