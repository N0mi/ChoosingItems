using System.Collections.Generic;
using UnityEngine;

namespace AmayaSoft.TestTask.Data
{
    [CreateAssetMenu(fileName = "new BundlesKit", menuName = "Bundles Kit", order = 0)]
    public class BundlesKit : ScriptableObject
    {
        [SerializeField] private CardBundleData[] _bundles;
        
        public IReadOnlyList<CardBundleData> Bundles => _bundles;
    }
}