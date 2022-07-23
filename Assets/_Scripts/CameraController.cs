using UnityEngine;

namespace FrogNinja.CameraControls
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] PlayerController playerCharacter;
        private Vector3 myPosition;

        private void Start()
        {
            myPosition = transform.position;
        }

        private void Update()
        {
            if (playerCharacter.transform.position.y > myPosition.y)
            {
                myPosition.y = playerCharacter.transform.position.y;
                transform.position = myPosition;
            }

        }
    }
}

