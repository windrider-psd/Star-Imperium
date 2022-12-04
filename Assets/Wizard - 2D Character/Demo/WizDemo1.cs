using UnityEngine;

namespace ClearSky
{
    public class WizDemo1 : MonoBehaviour
    {
        private Animator anim;

        public void Attack()
        {
            ResetAnimation();
            anim.SetTrigger("attack");
        }

        public void Die()
        {
            ResetAnimation();
            anim.SetTrigger("die");
        }

        public void Hurt()
        {
            ResetAnimation();
            anim.SetTrigger("hurt");
        }

        public void Idle()
        {
            ResetAnimation();
            anim.SetTrigger("idle");
        }

        public void Jump()
        {
            ResetAnimation();
            anim.SetBool("isJump", true);
        }

        public void LookUp()
        {
            ResetAnimation();
            anim.SetBool("isLookUp", true);
        }

        public void Run()
        {
            ResetAnimation();
            anim.SetBool("isRun", true);
        }

        public void TripOver()
        {
            ResetAnimation();
            anim.SetTrigger("tripOver");
        }

        // Start is called before the first frame update
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void ResetAnimation()
        {
            anim.SetBool("isLookUp", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
        }
    }
}