using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            _playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            _playerAnimator.SetBool("IsWalking", false);
        }

        if(_playerMovement.IsPlayerOnGround())
        {
            _playerAnimator.SetBool("IsOnGround", true);
        }
        else
        {
            _playerAnimator.SetBool("IsOnGround", false);
        }
    }
}
