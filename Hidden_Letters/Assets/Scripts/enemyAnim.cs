using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class enemyAnim : MonoBehaviour
    {
        [SerializeField] enemyController enemyController;
        Animator _anim;
        string _moveX = "moveX";
        string _moveY = "moveY";
        // Start is called before the first frame update
        void Start()
        {
            _anim = GetComponent<Animator>();
        }
        private void OnEnable() {
            enemyController.Action += Anim;
        }
        private void OnDisable() {
             enemyController.Action -= Anim;
        }
        // Update is called once per frame
       void Anim(float x, float y)
       {
           _anim.SetFloat(_moveX, x);
           _anim.SetFloat(_moveY, y);
       }
    }
}
