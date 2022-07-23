using UnityEngine;
using FrogNinja.LevelGeneration;
using System.Collections;
using System.Collections.Generic;


namespace FrogNinja.CameraControls
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] PlayerController playerCharacter;
        private Vector3 myPosition;

        private void Awake()
        {
            LevelGenerator.LevelGenerated += LevelGenerator_LevelGenerated;
        }

        private void OnDestroy()
        {
            LevelGenerator.LevelGenerated -= LevelGenerator_LevelGenerated;
        }

        private void LevelGenerator_LevelGenerated(Vector3 obj)
        {
            myPosition.y = obj.y + 2.67f;
            transform.position = myPosition;
        }

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

