using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        private void LateUpdate()
        {
            transform.position = new Vector3(target.position.x, target.position.y + 25, target.position.z);
        }
    }
}