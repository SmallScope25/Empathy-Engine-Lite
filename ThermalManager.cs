// ================================================================
// MODULE 01: THERMAL-AWARE PERFORMANCE MANAGEMENT
// Universal Game Development Framework
// ================================================================
// UNIVERSAL MODULE - Updates propagate across ALL projects
// NEVER modify game-specific content in Universal modules
// ================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

#if UNITY_ANDROID || UNITY_IOS
using UnityEngine.AdaptivePerformance;
#endif

namespace UniversalFramework.ThermalManagement
{
    // ================================================================
    // THERMAL STATE DEFINITIONS - ThermalState defined in ThermalManagement.cs
    // ================================================================
    
    // ThermalState enum defined in ThermalManagement.cs in this namespace
    // Available states: Cool, Normal, Warm, Hot, Critical

    public enum QualityTier
    {
        High,          // Full visual fidelity
        Medium,        // Balanced performance/quality
        Low,           // Performance prioritized
        Survival       // Minimal quality for stability
    }

    [Serializable]
    public class PerformanceMetrics
    {
        [Header("Thermal Data")]
        public float temperature = 45f;
        public ThermalState thermalState = ThermalState.Optimal;
        
        [Header("Performance Data")]
        public float fps = 60f;
        public float frameTimeMs = 16.67f;
        public float cpuUsage = 50f;
        public float gpuUsage = 50f;
        public float memoryUsageMB = 512f;
        
        [Header("Unity Adaptive Performance")]
        public bool adaptivePerformanceActive = false;
        public float thermalTrend = 0f; // -1 cooling, 0 stable, +1 heating
    }

    [Serializable]
    public class QualitySettings
    {
        [Header("Visual Quality")]
        [Range(0f, 1f)] public float textureQuality = 1f;
        [Range(0f, 1f)] public float shadowQuality = 1f;
        [Range(0f, 1f)] public float lodBias = 1f;
        [Range(0f, 1f)] public float particleDensity = 1f;
        
        [Header("Rendering")]
        public int shadowCascades = 4;
        public float shadowDistance = 100f;
        public bool postProcessing = true;
        public bool realTimeReflections = true;
        
        [Header("Platform Specific")]
        public int targetFrameRate = 60;
        public bool vSyncEnabled = true;
        
        [Header("Game-Specific Hooks")]
        public Dictionary<string, float> customSettings = new Dictionary<string, float>();
    }

    // ================================================================
    // CORE THERMAL MONITOR COMPONENT
    // ================================================================
    
    /// <summary>
    /// Universal thermal monitoring system
    /// Automatically adjusts game quality based on device thermal state
    /// Works across mobile AR, console, and PC platforms
    /// </summary>
    public class ThermalMonitor : MonoBehaviour
    {
        [Header("Thermal Configuration")]
        public float checkInterval = 2f;
        public bool enableThermalManagement = true;
        public bool enableDebugLogging = false;
        
        [Header("Performance Thresholds")]
        public float criticalTempThreshold = 85f;
        public float hotTempThreshold = 75f;
        public float warmTempThreshold = 65f;
        public float targetFrameRate = 60f;
        
        [Header("Quality Presets")]
        public QualitySettings highQuality = new QualitySettings();
        public QualitySettings mediumQuality = new QualitySettings();
        public QualitySettings lowQuality = new QualitySettings();
        public QualitySettings survivalQuality = new QualitySettings();
        
        // Events for game-specific systems to subscribe to
        public static event Action<ThermalState> OnThermalStateChanged;
        public static event Action<QualityTier> OnQualityTierChanged;
        public static event Action<PerformanceMetrics> OnPerformanceUpdate;
        
        // Internal state
        private PerformanceMetrics currentMetrics = new PerformanceMetrics();
        private ThermalState previousState = ThermalState.Optimal;
        private QualityTier currentTier = QualityTier.High;
        private float frameTimeAccumulator = 0f;
        private int frameCount = 0;
        
        #if UNITY_ANDROID || UNITY_IOS
        private IAdaptivePerformance adaptivePerformance;
        #endif

        // ================================================================
        // INITIALIZATION
        // ================================================================
        
        void Start()
        {
            InitializeDefaults();
            InitializeAdaptivePerformance();
            
            if (enableThermalManagement)
            {
                StartCoroutine(ThermalMonitoringLoop());
                if (enableDebugLogging) Debug.Log("🌡️ ThermalMonitor: System initialized");
            }
        }
        
        void InitializeDefaults()
        {
            // High Quality (Thermal State: Optimal)
            highQuality.textureQuality = 1f;
            highQuality.shadowQuality = 1f;
            highQuality.lodBias = 1f;
            highQuality.particleDensity = 1f;
            highQuality.shadowCascades = 4;
            highQuality.shadowDistance = 100f;
            highQuality.postProcessing = true;
            highQuality.realTimeReflections = true;
            highQuality.targetFrameRate = 60;
            
            // Medium Quality (Thermal State: Warm)
            mediumQuality.textureQuality = 0.75f;
            mediumQuality.shadowQuality = 0.75f;
            mediumQuality.lodBias = 0.8f;
            mediumQuality.particleDensity = 0.8f;
            mediumQuality.shadowCascades = 2;
            mediumQuality.shadowDistance = 75f;
            mediumQuality.postProcessing = true;
            mediumQuality.realTimeReflections = false;
            mediumQuality.targetFrameRate = 60;
            
            // Low Quality (Thermal State: Hot)
            lowQuality.textureQuality = 0.5f;
            lowQuality.shadowQuality = 0.5f;
            lowQuality.lodBias = 0.6f;
            lowQuality.particleDensity = 0.6f;
            lowQuality.shadowCascades = 1;
            lowQuality.shadowDistance = 50f;
            lowQuality.postProcessing = false;
            lowQuality.realTimeReflections = false;
            lowQuality.targetFrameRate = 30;
            
            // Survival Quality (Thermal State: Critical)
            survivalQuality.textureQuality = 0.25f;
            survivalQuality.shadowQuality = 0.25f;
            survivalQuality.lodBias = 0.4f;
            survivalQuality.particleDensity = 0.3f;
            survivalQuality.shadowCascades = 0;
            survivalQuality.shadowDistance = 20f;
            survivalQuality.postProcessing = false;
            survivalQuality.realTimeReflections = false;
            survivalQuality.targetFrameRate = 30;
        }
        
        void InitializeAdaptivePerformance()
        {
            #if UNITY_ANDROID || UNITY_IOS
            try
            {
                adaptivePerformance = Holder.Instance;
                if (adaptivePerformance != null && adaptivePerformance.Active)
                {
                    currentMetrics.adaptivePerformanceActive = true;
                    adaptivePerformance.ThermalStatus.ThermalEvent += OnAdaptivePerformanceThermalEvent;
                    if (enableDebugLogging) Debug.Log("🌡️ Unity Adaptive Performance: Active");
                }
            }
            catch (Exception e)
            {
                if (enableDebugLogging) Debug.LogWarning($"🌡️ Adaptive Performance unavailable: {e.Message}");
            }
            #endif
        }

        // ================================================================
        // THERMAL MONITORING LOOP
        // ================================================================
        
        IEnumerator ThermalMonitoringLoop()
        {
            while (enableThermalManagement)
            {
                UpdatePerformanceMetrics();
                AnalyzeThermalState();
                ApplyQualityAdjustments();
                BroadcastMetrics();
                
                yield return new WaitForSeconds(checkInterval);
            }
        }
        
        void Update()
        {
            // Accumulate frame time data for average calculation
            frameTimeAccumulator += Time.deltaTime;
            frameCount++;
        }
        
        void UpdatePerformanceMetrics()
        {
            // Calculate average frame time and FPS
            if (frameCount > 0)
            {
                currentMetrics.frameTimeMs = (frameTimeAccumulator / frameCount) * 1000f;
                currentMetrics.fps = 1f / (frameTimeAccumulator / frameCount);
                
                // Reset accumulators
                frameTimeAccumulator = 0f;
                frameCount = 0;
            }
            
            // Update system metrics
            currentMetrics.memoryUsageMB = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemory() / (1024f * 1024f);
            
            // Get thermal data from Unity Adaptive Performance if available
            #if UNITY_ANDROID || UNITY_IOS
            if (currentMetrics.adaptivePerformanceActive && adaptivePerformance != null)
            {
                var thermalMetrics = adaptivePerformance.ThermalStatus;
                currentMetrics.temperature = thermalMetrics.TemperatureLevel;
                currentMetrics.thermalTrend = thermalMetrics.TemperatureTrend;
            }
            else
            #endif
            {
                // Estimate thermal state from performance data
                EstimateThermalFromPerformance();
            }
        }
        
        void EstimateThermalFromPerformance()
        {
            // Estimate thermal state based on performance degradation
            float performanceRatio = currentMetrics.fps / targetFrameRate;
            
            if (performanceRatio < 0.4f) // Less than 40% of target FPS
                currentMetrics.temperature = 85f; // Critical
            else if (performanceRatio < 0.6f) // Less than 60% of target FPS
                currentMetrics.temperature = 75f; // Hot
            else if (performanceRatio < 0.8f) // Less than 80% of target FPS
                currentMetrics.temperature = 65f; // Warm
            else
                currentMetrics.temperature = 45f; // Optimal
        }

        // ================================================================
        // THERMAL STATE ANALYSIS
        // ================================================================
        
        void AnalyzeThermalState()
        {
            ThermalState newState = DetermineThermalState();
            
            if (newState != previousState)
            {
                previousState = currentMetrics.thermalState;
                currentMetrics.thermalState = newState;
                
                OnThermalStateChanged?.Invoke(newState);
                
                if (enableDebugLogging)
                {
                    Debug.Log($"🌡️ Thermal State Changed: {previousState} → {newState} " +
                             $"(Temp: {currentMetrics.temperature:F1}°C, FPS: {currentMetrics.fps:F1})");
                }
            }
        }
        
        ThermalState DetermineThermalState()
        {
            if (currentMetrics.temperature >= criticalTempThreshold || currentMetrics.fps < targetFrameRate * 0.4f)
                return ThermalState.Critical;
            else if (currentMetrics.temperature >= hotTempThreshold || currentMetrics.fps < targetFrameRate * 0.6f)
                return ThermalState.Hot;
            else if (currentMetrics.temperature >= warmTempThreshold || currentMetrics.fps < targetFrameRate * 0.8f)
                return ThermalState.Warm;
            else
                return ThermalState.Optimal;
        }

        // ================================================================
        // QUALITY ADJUSTMENT SYSTEM
        // ================================================================
        
        void ApplyQualityAdjustments()
        {
            QualityTier newTier = GetQualityTierForThermalState(currentMetrics.thermalState);
            
            if (newTier != currentTier)
            {
                currentTier = newTier;
                ApplyQualityTier(newTier);
                OnQualityTierChanged?.Invoke(newTier);
                
                if (enableDebugLogging)
                {
                    Debug.Log($"🎮 Quality Tier Changed: {currentTier}");
                }
            }
        }
        
        QualityTier GetQualityTierForThermalState(ThermalState state)
        {
            switch (state)
            {
                case ThermalState.Optimal: return QualityTier.High;
                case ThermalState.Warm: return QualityTier.Medium;
                case ThermalState.Hot: return QualityTier.Low;
                case ThermalState.Critical: return QualityTier.Survival;
                default: return QualityTier.High;
            }
        }
        
        void ApplyQualityTier(QualityTier tier)
        {
            QualitySettings settings = GetQualitySettings(tier);
            
            // Apply Unity quality settings
            UnityEngine.QualitySettings.globalTextureMipmapLimit = Mathf.RoundToInt((1f - settings.textureQuality) * 3f);
            UnityEngine.QualitySettings.shadowDistance = settings.shadowDistance;
            UnityEngine.QualitySettings.shadowCascades = settings.shadowCascades;
            UnityEngine.QualitySettings.lodBias = settings.lodBias;
            UnityEngine.QualitySettings.vSyncCount = settings.vSyncEnabled ? 1 : 0;
            
            // Set target frame rate
            Application.targetFrameRate = settings.targetFrameRate;
            
            // Store custom settings for game-specific systems
            settings.customSettings["textureQuality"] = settings.textureQuality;
            settings.customSettings["shadowQuality"] = settings.shadowQuality;
            settings.customSettings["particleDensity"] = settings.particleDensity;
            settings.customSettings["postProcessing"] = settings.postProcessing ? 1f : 0f;
            settings.customSettings["realTimeReflections"] = settings.realTimeReflections ? 1f : 0f;
        }
        
        QualitySettings GetQualitySettings(QualityTier tier)
        {
            switch (tier)
            {
                case QualityTier.High: return highQuality;
                case QualityTier.Medium: return mediumQuality;
                case QualityTier.Low: return lowQuality;
                case QualityTier.Survival: return survivalQuality;
                default: return highQuality;
            }
        }

        // ================================================================
        // EVENT BROADCASTING
        // ================================================================
        
        void BroadcastMetrics()
        {
            OnPerformanceUpdate?.Invoke(currentMetrics);
        }
        
        #if UNITY_ANDROID || UNITY_IOS
        void OnAdaptivePerformanceThermalEvent(ThermalMetrics thermalMetrics)
        {
            // Unity Adaptive Performance callback
            currentMetrics.temperature = thermalMetrics.TemperatureLevel;
            currentMetrics.thermalTrend = thermalMetrics.TemperatureTrend;
            
            if (enableDebugLogging)
            {
                Debug.Log($"🌡️ Adaptive Performance Update: Temp={thermalMetrics.TemperatureLevel:F1}, " +
                         $"Trend={thermalMetrics.TemperatureTrend:F2}");
            }
        }
        #endif

        // ================================================================
        // PUBLIC API FOR GAME-SPECIFIC SYSTEMS
        // ================================================================
        
        /// <summary>
        /// Get current thermal state
        /// </summary>
        public ThermalState GetThermalState() => currentMetrics.thermalState;
        
        /// <summary>
        /// Get current quality tier
        /// </summary>
        public QualityTier GetQualityTier() => currentTier;
        
        /// <summary>
        /// Get current performance metrics
        /// </summary>
        public PerformanceMetrics GetMetrics() => currentMetrics;
        
        /// <summary>
        /// Force a specific quality tier (for testing or manual override)
        /// </summary>
        public void ForceQualityTier(QualityTier tier)
        {
            currentTier = tier;
            ApplyQualityTier(tier);
            OnQualityTierChanged?.Invoke(tier);
            
            if (enableDebugLogging)
            {
                Debug.Log($"🎮 Quality Tier Forced: {tier}");
            }
        }
        
        /// <summary>
        /// Get a custom setting value for game-specific systems
        /// </summary>
        public float GetCustomSetting(string key, float defaultValue = 0f)
        {
            var settings = GetQualitySettings(currentTier);
            return settings.customSettings.ContainsKey(key) ? settings.customSettings[key] : defaultValue;
        }
        
        /// <summary>
        /// Check if a feature should be enabled based on current quality tier
        /// </summary>
        public bool IsFeatureEnabled(string featureName)
        {
            return GetCustomSetting(featureName, 0f) > 0.5f;
        }
        
        void OnDestroy()
        {
            #if UNITY_ANDROID || UNITY_IOS
            if (adaptivePerformance != null)
            {
                try
                {
                    adaptivePerformance.ThermalStatus.ThermalEvent -= OnAdaptivePerformanceThermalEvent;
                }
                catch (Exception e)
                {
                    if (enableDebugLogging) Debug.LogWarning($"🌡️ Error unsubscribing from thermal events: {e.Message}");
                }
            }
            #endif
        }
    }

    // ================================================================
    // GAME-SPECIFIC INTEGRATION HELPERS
    // ================================================================
    
    /// <summary>
    /// Helper component for game-specific systems to react to thermal changes
    /// Subscribe to thermal events and implement game-specific adjustments
    /// </summary>
    public abstract class ThermalAwareComponent : MonoBehaviour
    {
        [Header("Thermal Awareness")]
        public bool reactToThermalChanges = true;
        public bool debugThermalReactions = false;
        
        protected ThermalMonitor thermalMonitor;
        
        void Start()
        {
            thermalMonitor = FindObjectOfType<ThermalMonitor>();
            
            if (reactToThermalChanges)
            {
                ThermalMonitor.OnThermalStateChanged += OnThermalStateChanged;
                ThermalMonitor.OnQualityTierChanged += OnQualityTierChanged;
                
                if (debugThermalReactions)
                {
                    Debug.Log($"🔥 {gameObject.name}: Subscribed to thermal events");
                }
            }
            
            OnThermalAwareStart();
        }
        
        void OnDestroy()
        {
            if (reactToThermalChanges)
            {
                ThermalMonitor.OnThermalStateChanged -= OnThermalStateChanged;
                ThermalMonitor.OnQualityTierChanged -= OnQualityTierChanged;
            }
        }
        
        // Override these in game-specific components
        protected virtual void OnThermalAwareStart() { }
        protected virtual void OnThermalStateChanged(ThermalState newState) { }
        protected virtual void OnQualityTierChanged(QualityTier newTier) { }
        
        // Helper methods for game-specific components
        protected bool ShouldReduceQuality() => thermalMonitor != null && thermalMonitor.GetQualityTier() <= QualityTier.Low;
        protected bool IsInSurvivalMode() => thermalMonitor != null && thermalMonitor.GetQualityTier() == QualityTier.Survival;
        protected float GetQualityMultiplier() => thermalMonitor != null ? thermalMonitor.GetCustomSetting("textureQuality", 1f) : 1f;
    }
}