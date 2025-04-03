# VR Workout Game 🎾💪

An action-packed virtual reality fitness experience that combines gaming with a full-body workout. Hit flaming tennis balls with dual rackets to improve reflexes, coordination, and burn calories while having fun!

## Overview

VR Workout Game challenges players to hit as many flying objects as possible using hand-tracked controllers. With real-time performance tracking and haptic feedback, this game creates an immersive fitness experience that keeps players coming back for more.

## 🎮 Features

- **Dual-Wielding Gameplay**: Hold a virtual racket in each hand to hit incoming objects
- **Real-time Performance Tracking**: View your success rate, hits per hand, and overall score
- **Personal Best System**: Compare your current performance against your previous records
- **Haptic Feedback**: Feel vibrations when successfully hitting objects for enhanced immersion
- **Dynamic Object Generation**: Experience randomized object trajectories for varied gameplay
- **Progressive Difficulty**: The game adapts to challenge players of all skill levels

## 📋 Technical Implementation

### Scene Structure
- **Intro Scene**: Displays welcome message and personal best scores
- **Loading Scene**: Manages asynchronous loading between game sections
- **Main Game Scene**: Where the primary gameplay occurs
- **Endgame Scene**: Shows final performance metrics and options to continue

### Key Scripts

#### IntroScript
- Displays personalized welcome and best score information
- Handles scene transitions based on controller input
- Includes developer tools for testing and score management

#### LoadingScript
- Manages asynchronous scene loading for smooth transitions
- Prevents gameplay freezes during scene changes

#### CatchMeScript
- Detects collisions between player hands and flying objects
- Triggers haptic feedback on successful hits
- Updates score counters and success percentage in real-time

#### WallScript
- Manages object collisions with boundary walls
- Tracks total shots fired and triggers game end when limit is reached
- Handles score comparison and updates personal bests

#### AppManagerScript
- Dynamically spawns flying objects at random intervals and positions
- Applies physics forces for realistic object movement
- Controls game progression and difficulty

#### EndgameScript
- Displays final performance metrics (hit percentage, best score, hand scores)
- Manages PlayerPrefs data for persistent score tracking
- Provides options to restart or return to intro screen

## 🔧 Technologies Used

- **Unity3D**: Primary game engine and development environment
- **C#**: Core programming language for all game scripts
- **OVR Input**: For VR controller input handling 
- **Physics System**: For realistic object movement and collisions
- **SceneManagement**: For seamless transitions between game sections
- **PlayerPrefs**: For persistent data storage between game sessions
- **TextMeshPro**: For high-quality text rendering of game information

## 🎯 Development Focus

- **Performance Optimization**: Ensuring smooth gameplay in VR
- **Input Responsiveness**: Minimizing latency for accurate hit detection
- **User Experience**: Creating intuitive interactions that feel natural
- **Fitness Engagement**: Designing gameplay that encourages physical movement
- **Score Progression**: Motivating players to improve with each session

## 🚀 Future Enhancements

- Customizable difficulty settings
- Additional object types with unique behaviors
- Multiplayer mode for competitive workouts
- Detailed fitness tracking and calorie counter
- Custom environments and visual themes

---

## Getting Started

### Prerequisites
- VR headset with motion controllers (Oculus/Meta Quest recommended)
- Unity 2021.3 or newer (if modifying source code)

### Installation
1. Clone this repository
2. Open the project in Unity
3. Build and deploy to your VR device

### Controls
- **Trigger Buttons**: Start game / Select options
- **Hand Movement**: Control rackets to hit objects
- **X + A Buttons**: Developer reset (clears best score)

---

## Credits
Developed by Shannon Escoriaza
