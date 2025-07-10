// ================================================================
// SharedDataStructures.cs - Universal Framework Shared Types
// Central location for data structures used across multiple modules
// ================================================================

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universal.Shared
{
    // ================================================================
    // CULTURAL VALIDATION SHARED STRUCTURES
    // ================================================================
    
    [Serializable]
    public class CulturalValidationResult
    {
        public bool success;
        public string errorMessage;
        public float authenticityScore;
        public List<string> concerns = new List<string>();
        public bool requiresCommunityReview;
        public Dictionary<string, object> validationData = new Dictionary<string, object>();
    }
    
    public enum CulturalValidationStrictness
    {
        Lenient,
        Standard,
        Strict,
        CommunityRequired
    }
    
    // ================================================================
    // THERMAL PROCESSING SHARED STRUCTURES
    // ================================================================
    
    public enum ThermalProcessingMode
    {
        Adaptive,
        Conservative,
        Performance,
        BatteryOptimized
    }
    
    // ================================================================
    // ACCESSIBILITY SHARED STRUCTURES
    // ================================================================
    
    public enum AccessibilityApproach2025
    {
        PowerUpInnovation,
        UniversalDesign,
        CommunityPartnered,
        InclusionFirst
    }
    
    // ================================================================
    // EMPATHY ENGINE SHARED STRUCTURES
    // ================================================================
    
    [Serializable]
    public class EmotionalAccessibilitySynergy
    {
        public float emotionalResonance;
        public float accessibilityScore;
        public bool enhancesAccessibility;
        public List<string> accessibilityFeatures = new List<string>();
    }
    
    [Serializable]
    public class EmotionalNarrativeSynergy
    {
        public float emotionalDepth;
        public float narrativeCoherence;
        public bool enhancesNarrative;
        public List<string> narrativeElements = new List<string>();
    }
    
    [Serializable]
    public class CommunityWisdomDatabase
    {
        public bool isInitialized;
        public int entryCount;
        public DateTime lastUpdate;
        public Dictionary<string, object> wisdomEntries = new Dictionary<string, object>();
    }
    
    [Serializable]
    public class CommunityPartnershipNetwork
    {
        public bool isActive;
        public int partnerCount;
        public List<string> activePartners = new List<string>();
        public Dictionary<string, float> partnershipStrength = new Dictionary<string, float>();
    }
    
    [Serializable]
    public class RevenueSharingFramework
    {
        public bool isEnabled;
        public float defaultSharePercentage;
        public Dictionary<string, float> partnerShares = new Dictionary<string, float>();
        public float totalDistributed;
    }
    
    [Serializable]
    public class PerformanceProfile
    {
        public string profileName;
        public float thermalEfficiency;
        public float qualityLevel;
        public float batteryImpact;
        public Dictionary<string, float> settings = new Dictionary<string, float>();
    }
    
    // ================================================================
    // FRAMEWORK INTEGRATION STRUCTURES
    // ================================================================
    
    [Serializable]
    public class Range
    {
        public float min;
        public float max;
        
        public Range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
        
        public bool Overlaps(Range other)
        {
            return min <= other.max && max >= other.min;
        }
        
        public bool Contains(float value)
        {
            return value >= min && value <= max;
        }
    }
}