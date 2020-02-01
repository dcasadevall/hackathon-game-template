using System;
using System.Collections.Generic;

namespace LogSystem {
    /// <summary>
    /// A class defining a feature to be logged with <see cref="ILogger"/>.
    /// </summary>
    [Serializable]
    public struct LoggedFeature {
        #region Registry
        public static LoggedFeature TODO => new LoggedFeature("TODO");
        public static LoggedFeature Editor => new LoggedFeature("Editor");
        public static LoggedFeature Input => new LoggedFeature("Input");
        public static LoggedFeature Pooling => new LoggedFeature("Pooling");
        public static LoggedFeature Assets => new LoggedFeature("Assets");
        public static LoggedFeature UI => new LoggedFeature("UI");
        public static LoggedFeature Audio => new LoggedFeature("Audio");
        public static LoggedFeature GameState => new LoggedFeature("GameState");
        
        private static readonly HashSet<LoggedFeature> _features = new HashSet<LoggedFeature>();
        public static IEnumerable<LoggedFeature> LoggedFeatures => _features;

        private static void Register(LoggedFeature feature) {
            _features.Add(feature);
        }
        #endregion
        
        public readonly string name;

        public LoggedFeature(string name) {
            this.name = name;
            
            Register(this);
        }
        
        #region Equality Methods
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            LoggedFeature other = (LoggedFeature)obj;
            return other.name.Equals(name);
        }

        public override int GetHashCode() {
            return name.GetHashCode();
        }
        #endregion

        #region string methods
        public override string ToString() {
            return name;
        }
        #endregion

        #region Operators
        // This allows casting to and from string
        public static implicit operator string(LoggedFeature loggedFeature) {
            return loggedFeature.name;
        }

        public static implicit operator LoggedFeature(string name) {
            return new LoggedFeature(name);
        }

        public static bool operator ==(LoggedFeature a, LoggedFeature b) {
            return a.name.Equals(b.name);
        }

        public static bool operator !=(LoggedFeature a, LoggedFeature b) {
            return !a.name.Equals(b.name);
        }
        #endregion
    }

}