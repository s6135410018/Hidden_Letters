using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class playerAnim : MonoBehaviour
    {
        Animator _anim;
        string _velX = "Velocity.x";
        string _velZ = "Velocity.z";
        string _walk = "Walk";
        [SerializeField] playerController1 playerController1;
        void Start()
        {
            _anim = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            playerController1.Action_walk += walkAnim;
            playerController1.Action_vel += Vel;

        }
        private void OnDisable()
        {
            playerController1.Action_walk -= walkAnim;
            playerController1.Action_vel -= Vel;

        }

        // Update is called once per frame
        void walkAnim(bool TorF)
        {
            _anim.SetBool(_walk, TorF);

        }
        void Vel(float x, float y)
        {
            _anim.SetFloat(_velX, x);
            _anim.SetFloat(_velZ, y);

        }
       
    }
}
