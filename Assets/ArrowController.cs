using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class ArrowController : NPCBase
    {
        [SerializeField] float TimeToReachTarget;
        Vector3 StartPosition;
        [SerializeField] Transform Target;

        float t;
        public void SetArrow(PlayerBase playerBase, Transform _target, float _timeToReachTarget)
        {
            base.PlayerBase = playerBase;
            Target = _target;
            TimeToReachTarget = _timeToReachTarget;
        }

        private void Start()
        {
            StartPosition = transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move()
        {
            t += Time.deltaTime / TimeToReachTarget;
            transform.position = Vector3.Lerp(StartPosition, Target.position, t);
        }
    }
}
