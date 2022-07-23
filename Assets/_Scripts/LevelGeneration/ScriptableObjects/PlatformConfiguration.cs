using FrogNinja.Platforms;
using System.Collections.Generic;
using UnityEngine;

namespace FrogNinja.LevelGeneration.Configs
{
    [CreateAssetMenu(fileName = "PlatformConfig", menuName = "Platforms/PlatformConfig", order = 0)]
    public class PlatformConfiguration : ScriptableObject
    {
        public List<BasePlatform> Platforms;
        public float DefaultYIncrease = 1;

        private void OnValidate()
        {
            if (DefaultYIncrease < 0)
            {
                DefaultYIncrease = 1;
            }
        }

        public BasePlatform GetRandomPlatform()
        {
            return Platforms[Random.Range(0, Platforms.Count)];
        }
    }
}
