using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    //float rotationSpeed = 100.0f;

    Animator playerAnimator;

	// Use this for initialization
	void Start ()
    {
        playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdatePlayerMovement();
	}

    //static float old_horizontalInput = 0f;
    //static float old_verticalInput = 0f;

    /// <summary>
    /// 
    /// </summary>
    private void UpdatePlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //if ((old_horizontalInput != horizontalInput) || (old_verticalInput != verticalInput))
        //{
        //    Debug.Log(string.Format("horizontal input = {0} vertical input = {1}", horizontalInput, verticalInput));
        //}

        if (verticalInput >= 0.5)
            MoveUp(horizontalInput, verticalInput);
        else if (verticalInput <= -0.5)
            MoveDown(horizontalInput, verticalInput);
        else if (horizontalInput >= 0.5)
            MoveRight(horizontalInput, verticalInput);
        else if (horizontalInput <= -0.5)
            MoveLeft(horizontalInput, verticalInput);
        else
            Idle();
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveUp(float horizontalInput, float verticalInput)
    {
        playerAnimator.SetFloat("FaceX", horizontalInput);
        playerAnimator.SetFloat("FaceY", verticalInput);
        playerAnimator.Play("Move Up");
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveDown(float horizontalInput, float verticalInput)
    {
        playerAnimator.SetFloat("FaceX", horizontalInput);
        playerAnimator.SetFloat("FaceY", verticalInput);
        playerAnimator.Play("Move Down");
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveLeft(float horizontalInput, float verticalInput)
    {
        playerAnimator.SetFloat("FaceX", horizontalInput);
        playerAnimator.SetFloat("FaceY", verticalInput);
        playerAnimator.Play("Move Left");
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveRight(float horizontalInput, float verticalInput)
    {
        playerAnimator.SetFloat("FaceX", horizontalInput);
        playerAnimator.SetFloat("FaceY", verticalInput);
        playerAnimator.Play("Move Right");
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Idle()
    {
        playerAnimator.Play("Idle");
    }
}
