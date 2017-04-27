using UnityEngine;
using System.Collections;

namespace Invector.CharacterController
{
    public class vThirdPersonController : vThirdPersonAnimator
    {
        public AudioClip boink;
        public AudioClip activate;
        public AudioClip doing;
        public AudioClip rhino;
        public AudioClip suction;
        public AudioClip swirl;

        private AudioSource playerSource;

        public bool walkingPlay;

        protected virtual void Start()
        {
#if !UNITY_EDITOR
                Cursor.visible = false;
#endif
            playerSource = GetComponent<AudioSource>();
        }

        public virtual void Sprint(bool value)
        {                       
            if (isGrounded)
                isSprinting = value;            
        }

        public virtual void Strafe()
        {
            if (locomotionType == LocomotionType.OnlyFree) return;
            isStrafing = isStrafing;
        }

        public virtual void Jump()
        {
            if (animator.IsInTransition(0)) return;

            // conditions to do this action
            bool jumpConditions = isGrounded && !isJumping;
            // return if jumpCondigions is false
            if (!jumpConditions) return;
            // trigger jump behaviour
            jumpCounter = jumpTimer;
            isSprinting = false;
            isJumping = true;
            // trigger jump animations            
            if (_rigidbody.velocity.magnitude < 1)
                animator.CrossFadeInFixedTime("Jump", 0.1f);
            else
                animator.CrossFadeInFixedTime("JumpMove", 0.2f);
        }

        public virtual void RotateWithAnotherTransform(Transform referenceTransform)
        {
            var newRotation = new Vector3(transform.eulerAngles.x, referenceTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), strafeRotationSpeed * Time.fixedDeltaTime);
            targetRotation = transform.rotation;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
            {
                playerSource.clip = suction;
                playerSource.loop = true;

                if (!walkingPlay)
                {
                    playerSource.Play();
                    walkingPlay = true;
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerSource.pitch = 1.2f;
                }
                else
                {
                    playerSource.pitch = 1f;
                }
            }
            else
            {
                playerSource.Stop();
                walkingPlay = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerSource.clip = boink;
                playerSource.loop = false;
                playerSource.Play();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerSource.Pause();
                playerSource.Stop();
                if (Input.GetKey(KeyCode.W))
                {
                    playerSource.clip = suction;
                    playerSource.Play();
                }
                else
                {
                    playerSource.clip = suction;
                    playerSource.Pause();
                }
            }
        }
    }
}