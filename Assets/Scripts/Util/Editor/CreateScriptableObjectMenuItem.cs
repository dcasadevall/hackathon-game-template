using UnityEditor;
using UnityEngine;

namespace Util.Editor {
    /// <summary>
    /// Utility editor class that allows one to create any kind of scriptable object by right clicking on the
    /// assets window.
    /// </summary>
    public static class CreateScriptableObjectMenuItem {
        [MenuItem("Assets/Create/Scriptable Object")]
        public static void CreateAsset() {
            ScriptableObjectUtil.CreateAsset<ScriptableObject>();
        }
    }
}
