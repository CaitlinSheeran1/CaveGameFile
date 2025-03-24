using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    void Start()
    {
        Animator animator;
        int isWalkingHash;
        int isRunningHash;

        void Start()
        {
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isRunningHash = Animator.StringToHash("isRunning");
        }

        void Update()
        {
            bool isWalking = animator.GetBool(isWalkingHash);
            bool isRunning = animator.GetBool(isRunningHash);

            bool forwardPressed = Input.GetKey("w");
            bool runPressed = Input.GetKey("left shift");

            if (forwardPressed && !isWalking)
            {
                animator.SetBool(isWalkingHash, true);
            }
            else if (!forwardPressed && isWalking)
            {
                animator.SetBool(isWalkingHash, false);
            }

            if (forwardPressed && runPressed && !isRunning)
            {
                animator.SetBool(isRunningHash, true);
            }
            else if (!(forwardPressed && runPressed) && isRunning)
            {
                animator.SetBool(isRunningHash, false);
            }
        }
    }
    }
