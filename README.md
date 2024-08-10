# Flappy Bird in Unity -SOLID Principles and Design Patterns Implementation


This project is a Unity-based implementation of a classic flappy bird-style game. The game is developed with a focus on **SOLID principles** and various **Game Design Patterns** to ensure clean, maintainable, and extensible code.

## Project Overview

The Flappy Game Project is designed to be a simple yet engaging game where the player controls a bird-like character, navigating through obstacles by tapping the screen to keep the bird flying. The main goal is to pass through as many obstacles as possible without hitting them, while achieving the highest score.

## Key Features

- **Responsive Controls**: The game supports both keyboard and touch inputs for wider accessibility.
- **Dynamic Obstacle Spawning**: Pipes are spawned dynamically at varying heights to create an unpredictable challenge.
- **Parallax Background**: A smooth, scrolling background provides depth and an enhanced visual experience.
- **High Score Tracking**: The game tracks and saves the highest score locally.

## Design Patterns Used

### 1. Singleton Pattern
   - **Class**: `GameManager`, `PipePool`
   - **Description**: The Singleton pattern ensures that only one instance of the `GameManager` and `PipePool` exists throughout the game, making it easy to manage global game states and object pooling.

### 2. Strategy Pattern
   - **Class**: `Parallax`, `HorizontalParallax`
   - **Description**: The Strategy pattern is used in the parallax system, allowing different parallax strategies (e.g., horizontal scrolling) to be swapped at runtime. This makes the background scrolling behavior more flexible.

### 3. Observer Pattern
   - **Class**: `HighScoreSaver`, `IHighScoreObserver`
   - **Description**: The Observer pattern is employed to notify when the high score changes. `HighScoreSaver` listens for changes and updates the saved high score accordingly.

### 4. Object Pooling Pattern
   - **Class**: `PipePool`
   - **Description**: The Object Pooling pattern is used for managing the pipe obstacles. Instead of creating and destroying pipes repeatedly, they are reused, improving performance.

## Project Structure

- **Scripts**:
  - **GameManager.cs**: Manages the overall game state, including start, pause, game over, and score tracking.
  - **Player.cs**: Handles player input, movement, and collision detection.
  - **Spawner.cs**: Controls the spawning of obstacles at set intervals.
  - **Pipes.cs**: Manages the behavior of the pipe obstacles, including movement and recycling.
  - **Parallax.cs & IParallaxStrategy.cs**: Implements the parallax effect using the Strategy pattern.
  - **SaveManager.cs & HighScoreData.cs**: Manages saving and loading of high scores.
  - **HighScoreSaver.cs**: Observes changes in high score and triggers saving.

- **Prefabs**:
  - **PipePrefab**: The prefab for the pipe obstacles, managed by the PipePool.


