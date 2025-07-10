// ================================================================================================
// ThermalInputManager.cs - Complete Thermal-Aware Input Manager
// Integrates with BCT Thermal Module and Universal Framework Input System
// Prevents input lag during thermal throttling while preserving game responsiveness
// ================================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using UniversalFramework.ThermalManagement;

namespace UniversalFramework.Input
{
    /// <summary>
    /// Thermal-aware input manager that maintains responsiveness under thermal stress
    /// Integrates with your existing BCT Thermal Module and master_controller_system
    /// Prevents input lag during thermal throttling while preserving game responsiveness
    /// </summary>
    public class ThermalInputManager : MonoBehaviour
    {
        [Header("🔥 Thermal Integration")]
        public bool enableThermalInputReduction = true;
        public float thermalCheckInterval = 1.0f;
        public float thermalThrottleThreshold = 0.7f;
        
        [Header("📱 Mobile Optimization")]
        public bool enableMobileOptimization = true;
        public int baseMaxInputsPerFrame = 10;
        public int emergencyMaxInputsPerFrame = 3;
        
        [Header("🎮 Input Quality Scaling")]
        public float highQualityInputRate = 1.0f;
        public float mediumQualityInputRate = 0.75f;
        public float lowQualityInputRate = 0.5f;
        public float emergencyQualityInputRate = 0.25f;
        
        [Header("⚡ Performance Monitoring")]
        public bool enableFrameRateMonitoring = true;
        public float targetFrameRate = 60f;
        public float criticalFrameRate = 20f;
        
        [Header("🔧 Debug Settings")]
        public bool enableDebugLogging = false;
        
        // References to your existing systems
        private MasterControllerSystem masterController;
        private UniversalFramework.ThermalManagement.ThermalMonitor bctThermalMonitor;
        
        // State tracking
        private bool isThermalThrottling = false;
        private float lastThermalCheck = 0f;
        private float currentInputQualityMultiplier = 1.0f;
        private ThermalState currentThermalState = ThermalState.Optimal;
        private float currentFrameRate = 60f;
        private int currentMaxInputsPerFrame = 10;
        
        // Input throttling
        private Queue<UniversalInputEvent> inputQueue = new Queue<UniversalInputEvent>();
        private int inputsProcessedThisFrame = 0;
        
        public void Initialize(MasterControllerSystem controller)
        {
            masterController = controller;
            bctThermalMonitor = FindObjectOfType<UniversalFramework.ThermalManagement.ThermalMonitor>();
            
            if (bctThermalMonitor != null && enableDebugLogging)
            {
                Debug.Log("🔥 ThermalInputManager: Connected to BCT Thermal Monitor");
            }
            
            StartCoroutine(ThermalMonitoringLoop());
            Debug.Log("🔥 ThermalInputManager: Initialized");
        }
        
        void Update()
        {
            // Reset input counter each frame
            inputsProcessedThisFrame = 0;
            
            // Process queued inputs up to thermal limit
            ProcessQueuedInputs();
        }
        
        IEnumerator ThermalMonitoringLoop()
        {
            while (enabled)
            {
                CheckThermalState();
                UpdateInputQuality();
                yield return new WaitForSeconds(thermalCheckInterval);
            }
        }
        
        void CheckThermalState()
        {
            if (bctThermalMonitor != null)
            {
                try
                {
                    // Use bridge extension methods from InputSystemDependencyFixes.cs
                    currentThermalState = bctThermalMonitor.GetInputThermalState();
                    currentFrameRate = bctThermalMonitor.GetCurrentFPS();
                    isThermalThrottling = bctThermalMonitor.IsThrottling();
                }
                catch (Exception e)
                {
                    if (enableDebugLogging)
                        Debug.LogWarning($"🔥 Error reading BCT thermal data: {e.Message}");
                    
                    // Fallback to frame rate monitoring
                    EstimateThermalStateFromFrameRate();
                }
            }
            else
            {
                // Fallback thermal estimation
                EstimateThermalStateFromFrameRate();
            }
            
            if (enableDebugLogging)
            {
                Debug.Log($"🔥 Thermal State: {currentThermalState}, FPS: {currentFrameRate:F1}, Throttling: {isThermalThrottling}");
            }
        }
        
        void EstimateThermalStateFromFrameRate()
        {
            currentFrameRate = 1.0f / Time.deltaTime;
            
            // Estimate thermal state based on frame rate performance
            if (currentFrameRate >= targetFrameRate * 0.9f)
                currentThermalState = InputThermalState.Cool;
            else if (currentFrameRate >= targetFrameRate * 0.7f)
                currentThermalState = InputThermalState.Warm;
            else if (currentFrameRate >= targetFrameRate * 0.4f)
                currentThermalState = InputThermalState.Hot;
            else if (currentFrameRate >= criticalFrameRate)
                currentThermalState = InputThermalState.Critical;
            else
                currentThermalState = InputThermalState.Emergency;
            
            isThermalThrottling = currentThermalState >= InputThermalState.Hot;
        }
        
        void UpdateInputQuality()
        {
            if (!enableThermalInputReduction) return;
            
            currentInputQualityMultiplier = currentThermalState switch
            {
                InputThermalState.Cool => highQualityInputRate,
                InputThermalState.Warm => mediumQualityInputRate,
                InputThermalState.Hot => lowQualityInputRate,
                InputThermalState.Critical => emergencyQualityInputRate,
                InputThermalState.Emergency => emergencyQualityInputRate * 0.5f,
                _ => highQualityInputRate
            };
            
            currentMaxInputsPerFrame = GetMaxInputsForThermalState();
            
            if (enableDebugLogging)
            {
                Debug.Log($"🔥 Input Quality: {currentInputQualityMultiplier:F2}, Max Inputs/Frame: {currentMaxInputsPerFrame}");
            }
        }
        
        int GetMaxInputsForThermalState()
        {
            return currentThermalState switch
            {
                InputThermalState.Cool => baseMaxInputsPerFrame,
                InputThermalState.Warm => Mathf.RoundToInt(baseMaxInputsPerFrame * 0.8f),
                InputThermalState.Hot => Mathf.RoundToInt(baseMaxInputsPerFrame * 0.6f),
                InputThermalState.Critical => Mathf.RoundToInt(baseMaxInputsPerFrame * 0.4f),
                InputThermalState.Emergency => emergencyMaxInputsPerFrame,
                _ => baseMaxInputsPerFrame
            };
        }
        
        void ProcessQueuedInputs()
        {
            while (inputQueue.Count > 0 && inputsProcessedThisFrame < currentMaxInputsPerFrame)
            {
                var inputEvent = inputQueue.Dequeue();
                ProcessInputEvent(inputEvent);
                inputsProcessedThisFrame++;
            }
        }
        
        void ProcessInputEvent(UniversalInputEvent inputEvent)
        {
            // Apply thermal quality scaling to input event
            inputEvent.inputQuality = InputSystemUtilitiesExtensions.GetInputQualityForInputThermalState(currentThermalState);
            
            // Scale input values based on thermal state
            float thermalMultiplier = InputSystemUtilitiesExtensions.GetInputQualityMultiplier(inputEvent.inputQuality);
            inputEvent.value1D *= thermalMultiplier;
            inputEvent.value2D *= thermalMultiplier;
            
            // Send processed input to master controller
            if (masterController != null)
            {
                masterController.ProcessThermalAdjustedInput(inputEvent);
            }
        }
        
        // Public API for master controller system
        public bool CanProcessInput()
        {
            return inputsProcessedThisFrame < currentMaxInputsPerFrame;
        }
        
        public void QueueInput(UniversalInputEvent inputEvent)
        {
            if (CanProcessInput())
            {
                ProcessInputEvent(inputEvent);
                inputsProcessedThisFrame++;
            }
            else
            {
                // Queue for next frame
                inputQueue.Enqueue(inputEvent);
            }
        }
        
        public bool IsThermalThrottling() => isThermalThrottling;
        public float GetCurrentInputQuality() => currentInputQualityMultiplier;
        public InputThermalState GetThermalState() => currentThermalState;
        public void SetThermalReduction(bool enabled) => enableThermalInputReduction = enabled;
        public int GetQueuedInputCount() => inputQueue.Count;
        public float GetCurrentFPS() => currentFrameRate;
        
        // Event for other systems to subscribe to thermal changes
        public System.Action<InputThermalState> OnThermalStateChanged;
        
        private InputThermalState previousThermalState = InputThermalState.Cool;
        
        void LateUpdate()
        {
            // Check for thermal state changes and broadcast events
            if (currentThermalState != previousThermalState)
            {
                OnThermalStateChanged?.Invoke(currentThermalState);
                previousThermalState = currentThermalState;
                
                if (enableDebugLogging)
                {
                    Debug.Log($"🔥 Thermal State Changed: {previousThermalState} → {currentThermalState}");
                }
            }
        }
    }
}