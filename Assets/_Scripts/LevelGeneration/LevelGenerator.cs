using FrogNinja.Enemies;
using FrogNinja.LevelGeneration.Configs;
using FrogNinja.Platforms;
using System.Collections.Generic;
using UnityEngine;

namespace FrogNinja.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        public static event System.Action<Vector3> LevelGenerated;

        [SerializeField] private List<PlatformConfiguration> platformConfigurations;
        [SerializeField] private List<BaseEnemy> enemies;
        [SerializeField] private Transform playerSpawnPosition;
        [SerializeField] Vector2 minMaxVariation = new Vector2(0f, 1f);
        [SerializeField] private float minDistanceToSpawnEnemy;
        [SerializeField] int maxCountOfTheSamePlatformInRow = 1;

        private List<BasePlatform> spawnedPlatforms = new List<BasePlatform>();

        private List<BaseEnemy> spawnedEnemies = new List<BaseEnemy>();

        private BasePlatform lastSpawnedPlatform;
        private int samePlatformInRow = 0;

        private float lastSpawnedY;
        private Camera mainCamera;
        private bool enableEnemySpawn;

        private void Awake()
        {
            mainCamera = Camera.main;

            EventManager.EnterGameplay += EventManager_EnterGameplay;
        }
        private void OnDestroy()
        {
            EventManager.EnterGameplay -= EventManager_EnterGameplay;
            EventManager.PlayerPositionUpdate -= EventManager_PlayerPositionUpdate;
            EventManager.PlayerDied -= EventManager_PlayerFallenOff;
        }

        private void EventManager_EnterGameplay()
        {
            enableEnemySpawn = false;
            CreateLevel();
            enableEnemySpawn = true;

            if (LevelGenerated != null)
            {
                LevelGenerated(playerSpawnPosition.position);
            }

            EventManager.PlayerPositionUpdate += EventManager_PlayerPositionUpdate;
            EventManager.PlayerDied += EventManager_PlayerFallenOff;
        }

        private void EventManager_PlayerFallenOff()
        {
            EventManager.PlayerPositionUpdate -= EventManager_PlayerPositionUpdate;
            EventManager.PlayerDied -= EventManager_PlayerFallenOff;
        }

        private void EventManager_PlayerPositionUpdate(Vector2 obj)
        {
            if (obj.y > lastSpawnedY / 2)
            {
                SpawnPlatform();
            }
        }

        private void CreateLevel()
        {
            DestroyPreviousLevel();

            lastSpawnedY = playerSpawnPosition.position.y;

            for (int i = 0; i < 20; i++)
            {
                SpawnPlatform();
            }
        }
        private void DestroyPreviousLevel()
        {
            if (spawnedPlatforms.Count > 0)
            {
                for (int i = 0; i < spawnedPlatforms.Count; i++)
                {
                    Destroy(spawnedPlatforms[i].gameObject);
                }

                spawnedPlatforms.Clear();
            }
            if (spawnedEnemies.Count > 0)
            {
                for (int i = 0; i < spawnedEnemies.Count; i++)
                {
                    Destroy(spawnedEnemies[i].gameObject);
                }

                spawnedEnemies.Clear();
            }
        }
        private void SpawnEnemyIfAvailable(float lastY, float currentY)
        {
            if (!enableEnemySpawn)
            {
                return;
            }
            float difference = currentY - lastY;

            if (difference > minDistanceToSpawnEnemy)
            {
                Vector2 spawnPosition = new Vector2(GetRandomXPosition(), lastY + (difference / 2));

                BaseEnemy enemyToSpawn = enemies[Random.Range(0, enemies.Count)];

                BaseEnemy spawnedEnemy = GameObject.Instantiate<BaseEnemy>(enemyToSpawn, spawnPosition, Quaternion.identity, transform);
            }
        }

        private void SpawnPlatform()
        {
            BasePlatform platformToSpawn = DifferentiatePlatforms(out PlatformConfiguration configToUse);
            Vector3 spawnPosition = new Vector3(GetRandomXPosition(), GetRandomYPosition(configToUse), 0);

            BasePlatform spawnedPlatform = GameObject.Instantiate<BasePlatform>(platformToSpawn, spawnPosition, Quaternion.identity, transform);

            spawnedPlatforms.Add(spawnedPlatform);

            SpawnEnemyIfAvailable(lastSpawnedY, spawnPosition.y);

            lastSpawnedY = spawnPosition.y;
        }

        private BasePlatform DifferentiatePlatforms(out PlatformConfiguration configToUse)
        {
            configToUse = platformConfigurations[Random.Range(0, platformConfigurations.Count)];

            BasePlatform platformToSpawn = configToUse.GetRandomPlatform();

            if (platformConfigurations.Count == 1)
            {
                if (platformConfigurations[0].Platforms.Count == 1)
                {
                    return platformToSpawn;
                }
            }

            if (platformToSpawn == lastSpawnedPlatform)
            {
                samePlatformInRow++;

                if (samePlatformInRow >= maxCountOfTheSamePlatformInRow)
                {
                    while (platformToSpawn == lastSpawnedPlatform)
                    {
                        configToUse = platformConfigurations[Random.Range(0, platformConfigurations.Count)];
                        platformToSpawn = configToUse.GetRandomPlatform();
                    }

                    samePlatformInRow = 0;
                }
            }
            else
            {
                samePlatformInRow = 0;
            }

            lastSpawnedPlatform = platformToSpawn;
            return platformToSpawn;
        }


        private float GetRandomXPosition()
        {
            float randomValue = Random.Range(0f, 1f);

            Vector3 resultPosition = mainCamera.ViewportToWorldPoint(new Vector3(randomValue, 0));

            return resultPosition.x;
        }
        private float GetRandomYPosition(PlatformConfiguration configToUse)
        {
            return lastSpawnedY + configToUse.DefaultYIncrease + Random.Range(minMaxVariation.x, minMaxVariation.y);
        }

    }
}
