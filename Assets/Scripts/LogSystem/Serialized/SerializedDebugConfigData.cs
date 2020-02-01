using UnityEngine;

namespace LogSystem.Serialized {
    public class SerializedDebugConfigData : ScriptableObject {
        /// <summary>
        /// These features will be logged by the current <see cref="ILogger"/>
        /// </summarySerializedDebugConfigData>
        public string[] logFeatures;
    }
}