using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniversalCharacterFramework
{
    public enum CulturalValidationStatus
    {
        Pending_Review,
        Community_Reviewed,
        Culturally_Authentic,
        Requires_Revision,
        Expert_Validated
    }
    
    // Cultural Artifacts Data Structures
    [Serializable]
    public class CulturalArtifacts
    {
        public string primaryCulture;
        public List<string> jewelry = new List<string>();
        public List<string> textiles = new List<string>();
        public List<string> colors = new List<string>();
        public List<string> symbolism = new List<string>();
        public List<string> performance = new List<string>();
        
        [Range(0f, 1f)]
        public float appropriationRisk = 0.5f;
        
        [Range(0f, 1f)]
        public float authenticityLevel = 0.7f;
        
        public bool communityConsultationRequired = false;
        public bool historicalAccuracy = false;
        public bool genreAppropriateness = false;
        public bool scientificAccuracy = false;
        public bool universalAppeal = false;
        
        public CulturalFusionData fusion;
    }
    
    [Serializable]
    public class CulturalFusionData
    {
        public List<string> fusedCultures = new List<string>();
        public string fusionApproach;
        public bool requiresMultipleCommunityValidation = false;
        public float fusionComplexity = 0.5f;
        public List<string> fusionElements = new List<string>();
    }
    
    // Fashion Profile Data Structures
    [Serializable]
    public class FashionProfile
    {
        public FashionBaseStyle baseStyle;
        public FashionAppropriateness appropriateness;
        
        [Range(0f, 1f)]
        public float appropriationPreventionScore = 0.7f;
        
        public List<string> clothingItems = new List<string>();
        public List<string> accessories = new List<string>();
        public List<string> colors = new List<string>();
        public List<string> patterns = new List<string>();
        public List<string> materials = new List<string>();
        public List<string> culturalSignificance = new List<string>();
    }
    
    [Serializable]
    public class FashionBaseStyle
    {
        public string era;
        public string region;
        public string socialClass;
        public string occasion;
        public string season;
        public string functionality;
    }
    
    [Serializable]
    public class FashionAppropriateness
    {
        public bool culturallyAppropriate = true;
        public bool contextuallyAppropriate = true;
        public bool accessibilityConsidered = true;
        public bool representationPositive = true;
        public List<string> inappropriateElements = new List<string>();
    }
    
    // Complete VisualMarkers class with all supporting structures
    [Serializable]
    public class VisualMarkers
    {
        [Header("Core Visual Properties")]
        public List<string> culturalClothing;
        public List<string> personalityColors;
        public string bodyLanguageStyle;
        public List<string> facialFeatures;
        public List<string> culturalTattoos;
        
        [Header("Cultural Visual Identity")]
        public CulturalArtifacts culturalArtifacts;
        public FashionProfile fashionProfile;
        public PostureSignature postureSignature;
        public ColorPalette personalColors;
        
        [Header("Performance Integration")]
        public float visualComplexityScore = 0.7f;
        public bool thermalOptimizationEnabled = true;
        public bool crossProjectCompatible = true;
        
        public VisualMarkers()
        {
            culturalArtifacts = new CulturalArtifacts();
            fashionProfile = new FashionProfile();
            postureSignature = new PostureSignature();
            personalColors = new ColorPalette();
        }
    }
    
    [Serializable]
    public class PostureSignature
    {
        public string bodyLanguage;
        public string gestureStyle;
        public string movement;
        public string spatialPresence;
    }
    
    [Serializable]
    public class ColorPalette
    {
        public string[] primaryColors;
        public string[] accentColors;
        public string[] culturalColors;
    }
}
