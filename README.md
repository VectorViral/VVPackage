# VVPackage — Core, GUI & Audio Architecture for Unity

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Unity: 2022.3 LTS](https://img.shields.io/badge/Unity-2022.3%20LTS-blue.svg)](https://unity.com/)
[![Target: Android 16 (API 36)](https://img.shields.io/badge/Target-Android%2016%20(API%2036)-green.svg)](https://developer.android.com/)

**VVPackage** is an open-source, modular game architecture framework engineered by **VECTOR VIRAL (SMC-PRIVATE) LIMITED** for Unity mobile titles. It provides high-performance state management, GUI transitions, audio pooling, and local data persistence optimized for low-end to high-end mobile devices.

---

## 📦 Modules Included

| Module | Namespace | Description |
| :--- | :--- | :--- |
| **`VV_CORE`** | `VectorViral.Core` | Persistent game lifecycle, high-speed PlayerPrefs data serialization (`VVAppDataManager`), preloader splash sequence, and editor helper utilities. |
| **`VV_GUI`** | `VectorViral.GUI` | Decoupled UI management (`VVGUIManager`), screen lifecycle stack (`MRScreen`), modal overlays, and DOTween-driven animated transitions. |
| **`VV_SOUND`** | `VectorViral.Sound` | Centralized audio channel management (`VVSoundManager`), SFX pooling, volume fading, and mute state persistence. |
| **`VV_MUSIC`** | `VectorViral.Sound` | Seamless background soundtrack playback, looping controllers, and scene transition audio mixers. |

---

## 🚀 Installation

### Via Unity Package Manager (Git URL)
In the Unity Editor:
1. Open **Window** > **Package Manager**.
2. Click the **`+`** icon in the top-left corner and select **Add package from git URL...**.
3. Enter:
   ```text
   https://github.com/vectorviral/VVPackage.git
   ```
4. Click **Add**.

### Manual Embedded Installation
Alternatively, copy the `VVPackage` folder directly into your project's `Assets/` directory.

---

## 🛠️ Key APIs

### Data & Persistence (`VVAppDataManager`)
```csharp
using VectorViral.Core;

// Access persisted player data
var appData = VVAppDataManager.Instance.GetAppInstance();
appData.soundVolume = 0.8f;

// Save modifications to local disk
VVAppDataManager.Instance.SaveAppData();
```

### Audio Controller (`VVSoundManager`)
```csharp
using VectorViral.Sound;

// Play registered one-shot sound effect
VVSoundManager.Instance.Play("ButtonClick");

// Toggle master sound
VVSoundManager.Instance.SetSoundEnabled(true);
```

### Screen & UI Management (`VVGUIManager`)
```csharp
using VectorViral.GUI;

// Show screen with animated transition
VVGUIManager.Instance.ShowScreen("MRScreen_GameOver");
```

---

## 📄 License & Commercial Distribution Grant

Distributed under the **MIT License**.

```text
Copyright (c) 2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED. All rights reserved.

Permission is hereby granted, free of charge, to any person or entity obtaining a copy
of this software and associated documentation files (the "VVPackage Framework"), to deal
in the Software without restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so.
```

Official Repository: [https://github.com/vectorviral/VVPackage](https://github.com/vectorviral/VVPackage)
Developed by **VECTOR VIRAL (SMC-PRIVATE) LIMITED**.
