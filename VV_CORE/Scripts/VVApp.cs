// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

using System;

namespace VectorViral.Core
{
    [System.Serializable]
    public class VVApp
    {
        // VVPackage Fields
        public bool isAdsRemoved = false;
        public bool hasSubscription = false;
        public bool hasRated = false;
        public string playerName = "";
        public string countryCode = "";
        public float soundVolume = 1;
        public float musicVolume = 1;
        public bool isVibrationsEnabled = true;

        // App Specific Fields
        public int highScore, vinylAmount, vinylRushPowerUpAmount, carInsurancePowerupAmount, doubleScorePowerupAmount;

        // Daily Reward
        public int lastRewardClaimDay_S;
        public DateTime lastRewardClaimDateTime_S;
        public bool bool_RewardClaimed_S;

        public void Initialize()
        {
            // A new user, all default user things go here, e.g if in a new install, you want to start with some coins;
        }
    }

    // Backward-compatibility alias for existing code
    [System.Serializable]
    public class MRApp : VVApp { }
}
