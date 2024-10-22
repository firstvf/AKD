using UnityEngine;

namespace Assets.Project.Scripts
{
    public class Item : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }  

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}