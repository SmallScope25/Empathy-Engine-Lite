// ================================================================================================
// AccessibilityInputHandler.cs - Complete Accessibility Input Handler
// Universal Framework Input System - Accessibility Integration Component
// Integrates with Empathy Engine AccessibilityGuidanceEngine and master_controller_system.cs
// ================================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

namespace UniversalFramework.Input
{
    /// <summary>
    /// Accessibility input handler implementing "Power-Ups, Not Accommodations" philosophy
    /// Integrates with your Empathy Engine AccessibilityGuidanceEngine
    /// Transforms accessibility needs into gameplay advantages for all players
    /// </summary>
    public class AccessibilityInputHandler : MonoBehaviour
    {
        [Header("♿ Accessibility Philosophy")]
        public AccessibilityMode currentMode = AccessibilityMode.None;
        public bool enablePowerUpMode = true;
        public bool enableUniversalBenefits = true;
        
        [Header("⏱️ Timing Assistance")]
        public float extendedTimingMultiplier = 2.0f;
        public float inputBufferTime = 0.3f;
        public float coyoteTime = 0.2f;
        public bool enableInputPrediction = true;
        
        [Header("🎮 Alternative Input Methods")]
        public bool enableHoldToTap = true;
        public float holdToTapDuration = 0.8f;
        public bool enableDwellClick = true;
        public float dwellClickDuration = 1.2f;
        
        [Header("🔊 Multi-Modal Feedback")]
        public bool enableAudioFeedback = true;
        public bool enableHapticFeedback = true;
        public bool enableVisualFeedback = true;
        public float feedbackIntensity = 0.7f;
        
        [Header("🧠 Cognitive Assistance")]
        public bool enableCognitiveSupport = true;
        public bool enableMemoryAssist = true;
        public bool enableNavigationHelp = true;
        public int maxSimultaneousInstructions = 3;
        
        [Header("👁️ Visual Assistance")]
        public bool enableVisualEnhancements = true;
        public float contrastBoost = 1.5f;
        public float textScaleMultiplier = 1.2f;
        public bool enableColorBlindSupport = true;
        
        [Header("🦻 Hearing Assistance")]
        public bool enableHearingSupport = true;
        public bool enableVisualAudioCues = true;
        public bool enableSubtitles = true;
        public float audioVisualizationIntensity = 1.0f;
        
        [Header("🔧 Debug Settings")]
        public bool enableDebugLogging = false;
        
        // References to other systems
        private MasterControllerSystem masterController;
        private AudioSource feedbackAudioSource;
        private IAccessibilityGuidanceEngine empathyEngineAccessibility;
        
        // Input timing assistance
        private Dictionary<string, float> inputTimers = new Dictionary<string, float>();
        private Dictionary<string, InputBuffer> inputBuffers = new Dictionary<string, InputBuffer>();
        private Dictionary<string, bool> dwellStates = new Dictionary<string, bool>();
        private Dictionary<string, float> holdTimers = new Dictionary<string, float>();
        
        // Power-up tracking
        private Dictionary<AccessibilityMode, List<string>> activePowerUps = new Dictionary<AccessibilityMode, List<string>>();
        
        // Input processing pipeline
        private InputProcessorPipeline processorPipeline = new InputProcessorPipeline();
        
        public void Initialize(MasterControllerSystem controller)
        {
            masterController = controller;
            
            // Setup audio feedback
            InitializeAudioFeedback();
            
            // Initialize Empathy Engine integration (stub for now)
            InitializeEmpathyEngineIntegration();
            
            // Setup input processors
            InitializeInputProcessors();
            
            // Initialize power-ups system
            InitializePowerUpsSystem();
            
            Debug.Log("♿ AccessibilityInputHandler: Initialized with universal enhancement support");
        }
        
        void InitializeAudioFeedback()
        {
            if (enableAudioFeedback)
            {
                feedbackAudioSource = GetComponent<AudioSource>();
                if (feedbackAudioSource == null)
                {
                    feedbackAudioSource = gameObject.AddComponent<AudioSource>();
                    feedbackAudioSource.volume = feedbackIntensity;
                    feedbackAudioSource.playOnAwake = false;
                }
            }
        }
        
        void InitializeEmpathyEngineIntegration()
        {
            // Look for Empathy Engine AccessibilityGuidanceEngine
            var empathyEngine = FindObjectOfType<MonoBehaviour>();
            if (empathyEngine != null)
            {
                // Try to get the accessibility guidance engine from Empathy Engine
                empathyEngineAccessibility = empathyEngine.GetComponent<IAccessibilityGuidanceEngine>();
            }
            
            // Use stub if Empathy Engine not available
            if (empathyEngineAccessibility == null)
            {
                empathyEngineAccessibility = new AccessibilityGuidanceEngineStub();
                if (enableDebugLogging)
                {
                    Debug.Log("♿ Using AccessibilityGuidanceEngine stub - Empathy Engine not found");
                }
            }
        }
        
        void InitializeInputProcessors()
        {
            // Add accessibility-specific input processors
            processorPipeline.processors.Add(new AccessibilityInputProcessor(currentMode));
            
            if (enableDebugLogging)
            {
                Debug.Log("♿ Input processors initialized");
            }
        }
        
        void InitializePowerUpsSystem()
        {
            // Initialize power-ups for each accessibility mode
            foreach (AccessibilityMode mode in Enum.GetValues(typeof(AccessibilityMode)))
            {
                if (mode != AccessibilityMode.None)
                {
                    activePowerUps[mode] = new List<string>();
                    
                    // Get available power-ups from Empathy Engine
                    var availablePowerUps = empathyEngineAccessibility.GetAvailablePowerUps(mode);
                    activePowerUps[mode].AddRange(availablePowerUps);
                }
            }
            
            if (enableDebugLogging)
            {
                Debug.Log($"♿ Power-ups system initialized for {activePowerUps.Count} accessibility modes");
            }
        }
        
        public UniversalInputEvent ProcessInput(UniversalInputEvent inputEvent)
        {
            if (currentMode == AccessibilityMode.None) return inputEvent;
            
            // Set accessibility context
            inputEvent.accessibilityMode = currentMode;
            
            // Process through accessibility pipeline
            inputEvent = processorPipeline.ProcessInput(inputEvent);
            
            // Apply mode-specific enhancements
            inputEvent = ApplyAccessibilityEnhancements(inputEvent);
            
            // Provide feedback
            ProvideFeedback(inputEvent);
            
            if (enableDebugLogging)
            {
                Debug.Log($"♿ Processed input for {currentMode}: {inputEvent.actionName}");
            }
            
            return inputEvent;
        }
        
        UniversalInputEvent ApplyAccessibilityEnhancements(UniversalInputEvent inputEvent)
        {
            switch (currentMode)
            {
                case AccessibilityMode.MotorAssist:
                    return ApplyMotorAssistance(inputEvent);
                case AccessibilityMode.CognitiveAssist:
                    return ApplyCognitiveAssistance(inputEvent);
                case AccessibilityMode.VisualAssist:
                    return ApplyVisualAssistance(inputEvent);
                case AccessibilityMode.HearingAssist:
                    return ApplyHearingAssistance(inputEvent);
                case AccessibilityMode.Universal:
                    return ApplyUniversalEnhancements(inputEvent);
                default:
                    return inputEvent;
            }
        }
        
        UniversalInputEvent ApplyMotorAssistance(UniversalInputEvent inputEvent)
        {
            // Hold-to-tap conversion
            if (enableHoldToTap && !string.IsNullOrEmpty(inputEvent.actionName))
            {
                if (inputEvent.isHeld && inputEvent.holdDuration >= holdToTapDuration)
                {
                    inputEvent.isPressed = true; // Convert hold to tap
                    
                    if (enableDebugLogging)
                    {
                        Debug.Log($"♿ Hold-to-tap triggered for {inputEvent.actionName}");
                    }
                }
            }
            
            // Extended timing windows
            if (inputEvent.isPressed)
            {
                var buffer = new InputBuffer(inputEvent, inputBufferTime);
                inputBuffers[inputEvent.actionName] = buffer;
            }
            
            // Dwell click support
            if (enableDwellClick)
            {
                inputEvent = ApplyDwellClick(inputEvent);
            }
            
            return inputEvent;
        }
        
        UniversalInputEvent ApplyCognitiveAssistance(UniversalInputEvent inputEvent)
        {
            // Input prediction
            if (enableInputPrediction)
            {
                inputEvent = PredictNextInput(inputEvent);
            }
            
            // Memory assistance - store recent inputs
            if (enableMemoryAssist)
            {
                StoreRecentInput(inputEvent);
            }
            
            // Reduce cognitive load by simplifying complex inputs
            if (inputEvent.value2D.magnitude > 0.8f)
            {
                inputEvent.value2D = inputEvent.value2D.normalized * 0.8f; // Simplify high-precision inputs
            }
            
            return inputEvent;
        }
        
        UniversalInputEvent ApplyVisualAssistance(UniversalInputEvent inputEvent)
        {
            // Enhanced visual feedback triggers
            if (inputEvent.isPressed || inputEvent.isReleased)
            {
                TriggerVisualFeedback(inputEvent);
            }
            
            // Adjust for visual impairments
            if (enableVisualEnhancements)
            {
                // Provide audio alternatives for visual cues
                ProvideFeedback(inputEvent);
            }
            
            return inputEvent;
        }
        
        UniversalInputEvent ApplyHearingAssistance(UniversalInputEvent inputEvent)
        {
            // Visual audio cues
            if (enableVisualAudioCues)
            {
                TriggerVisualAudioCue(inputEvent);
            }
            
            // Enhanced haptic feedback
            if (enableHapticFeedback)
            {
                TriggerHapticFeedback(inputEvent);
            }
            
            return inputEvent;
        }
        
        UniversalInputEvent ApplyUniversalEnhancements(UniversalInputEvent inputEvent)
        {
            // Apply benefits from all accessibility modes
            inputEvent = ApplyMotorAssistance(inputEvent);
            inputEvent = ApplyCognitiveAssistance(inputEvent);
            inputEvent = ApplyVisualAssistance(inputEvent);
            inputEvent = ApplyHearingAssistance(inputEvent);
            
            return inputEvent;
        }
        
        UniversalInputEvent ApplyDwellClick(UniversalInputEvent inputEvent)
        {
            if (!inputEvent.isPressed && !inputEvent.isHeld && !inputEvent.isReleased)
            {
                // Check for dwell (hovering over target)
                if (inputEvent.value2D.magnitude < 0.1f) // Minimal movement
                {
                    if (!dwellStates.ContainsKey(inputEvent.actionName))
                    {
                        dwellStates[inputEvent.actionName] = true;
                        inputTimers[inputEvent.actionName] = Time.time;
                    }
                    else if (Time.time - inputTimers[inputEvent.actionName] >= dwellClickDuration)
                    {
                        // Trigger dwell click
                        inputEvent.isPressed = true;
                        dwellStates.Remove(inputEvent.actionName);
                        inputTimers.Remove(inputEvent.actionName);
                        
                        if (enableDebugLogging)
                        {
                            Debug.Log($"♿ Dwell click triggered for {inputEvent.actionName}");
                        }
                    }
                }
                else
                {
                    // Movement detected, reset dwell state
                    dwellStates.Remove(inputEvent.actionName);
                    inputTimers.Remove(inputEvent.actionName);
                }
            }
            
            return inputEvent;
        }
        
        UniversalInputEvent PredictNextInput(UniversalInputEvent inputEvent)
        {
            // Simple input prediction based on patterns
            // This is a placeholder for more sophisticated ML-based prediction
            
            if (inputEvent.value2D.magnitude > 0.5f)
            {
                // Predict continuation of movement
                inputEvent.value2D *= 1.1f; // Slight boost to predicted movement
            }
            
            return inputEvent;
        }
        
        void StoreRecentInput(UniversalInputEvent inputEvent)
        {
            // Store recent inputs for memory assistance
            // This could be expanded to provide hints or repeat last actions
        }
        
        void ProvideFeedback(UniversalInputEvent inputEvent)
        {
            if (enableAudioFeedback && feedbackAudioSource != null)
            {
                // Simple audio feedback for important actions
                if (inputEvent.isPressed)
                {
                    feedbackAudioSource.pitch = 1.0f + (inputEvent.value1D * 0.5f);
                    feedbackAudioSource.Play();
                }
            }
        }
        
        void TriggerVisualFeedback(UniversalInputEvent inputEvent)
        {
            // Trigger enhanced visual feedback
            // This would integrate with your UI system to provide visual cues
            if (enableDebugLogging)
            {
                Debug.Log($"♿ Visual feedback triggered for {inputEvent.actionName}");
            }
        }
        
        void TriggerVisualAudioCue(UniversalInputEvent inputEvent)
        {
            // Provide visual representation of audio cues
            if (enableDebugLogging)
            {
                Debug.Log($"♿ Visual audio cue triggered for {inputEvent.actionName}");
            }
        }
        
        void TriggerHapticFeedback(UniversalInputEvent inputEvent)
        {
            // Trigger haptic feedback for supported devices
            #if UNITY_ANDROID || UNITY_IOS
            if (enableHapticFeedback)
            {
                Handheld.Vibrate();
            }
            #endif
        }
        
        // Public API methods
        public void SetAccessibilityMode(AccessibilityMode mode)
        {
            AccessibilityMode previousMode = currentMode;
            currentMode = mode;
            
            // Update Empathy Engine
            if (empathyEngineAccessibility != null)
            {
                empathyEngineAccessibility.DisableAccessibilityMode(previousMode);
                empathyEngineAccessibility.EnableAccessibilityMode(mode);
            }
            
            // Update input processors
            processorPipeline.processors.Clear();
            processorPipeline.processors.Add(new AccessibilityInputProcessor(mode));
            
            if (enableDebugLogging)
            {
                Debug.Log($"♿ Accessibility mode changed: {previousMode} → {mode}");
            }
        }
        
        public string[] GetActivePowerUps()
        {
            if (activePowerUps.ContainsKey(currentMode))
            {
                return activePowerUps[currentMode].ToArray();
            }
            return new string[0];
        }
        
        public void EnablePowerUp(string powerUpName)
        {
            if (activePowerUps.ContainsKey(currentMode) && !activePowerUps[currentMode].Contains(powerUpName))
            {
                activePowerUps[currentMode].Add(powerUpName);
                
                if (enableDebugLogging)
                {
                    Debug.Log($"♿ Power-up enabled: {powerUpName} for {currentMode}");
                }
            }
        }
        
        public void DisablePowerUp(string powerUpName)
        {
            if (activePowerUps.ContainsKey(currentMode))
            {
                activePowerUps[currentMode].Remove(powerUpName);
                
                if (enableDebugLogging)
                {
                    Debug.Log($"♿ Power-up disabled: {powerUpName} for {currentMode}");
                }
            }
        }
        
        public bool IsAccessibilityModeActive(AccessibilityMode mode)
        {
            return currentMode == mode || currentMode == AccessibilityMode.Universal;
        }
        
        public AccessibilityMode GetCurrentMode()
        {
            return currentMode;
        }
    }
}