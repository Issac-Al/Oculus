using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{
    private Animator playerAnim;
    private CharacterController userCharacter;
    public Vector3 userDirection;
    public float userSpeed;
    public Transform cameraTranform;
    // Start is called before the first frame update
    private void Start()
    {
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
    }

}
