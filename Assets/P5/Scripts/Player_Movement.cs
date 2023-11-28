using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    private Animator playerAnim;
    private CharacterController userCharacter;
    public Vector3 userDirection;
    public float userSpeed;
    public Transform cameraTranform;
    public int HP;
    private int currentHP;
    public float DmgTimer;
    private float DmgCD = 0;
    // Start is called before the first frame update
    private void Start()
    {
        currentHP = HP;
        playerAnim = GetComponent<Animator>();
        userCharacter = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 userControl = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cameraRotation = cameraTranform.eulerAngles.y;
        Vector3 camerarotation = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraTranform.forward;
        userDirection = (camerarotation * Input.GetAxis("Horizontal") + cameraTranform.forward * Input.GetAxis("Vertical")).normalized;
        //userDirection.y = 0f;
        userCharacter.Move(userDirection * Time.deltaTime * userSpeed);
        Debug.Log(Input.GetAxis("Horizontal"));
        if(currentHP <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void GetHurt()
    {
        if (DmgCD < Time.time)
        {
            DmgCD = Time.time + DmgTimer;
            currentHP--;
        }
    }    

    public int ReturnHP()
    {
        return currentHP;
    }

}
