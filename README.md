# Steel Plant Monitoring Dashboard

Industrial monitoring prototype developed in Unity and C# to simulate real-time visualization of operational data for steel plant systems.

## Overview

This project simulates an industrial digital twin/dashboard for monitoring machine status in a steel plant environment.

The application visualizes:
- Machine operational status
- Temperature monitoring
- Warning and offline alerts
- Real-time simulated updates
- Industrial dashboard metrics

## Features

- 3D visualization built with Unity
- Machine status color indicators:
  - Green = Running
  - Yellow = Warning
  - Red = Offline
- JSON-based machine data initialization
- Real-time internal simulation updates
- Dashboard displaying:
  - Available machines
  - Warning alerts
  - Offline machines
  - Plant efficiency
  - Production rate
  - Last update timestamp

## Architecture

```text
JSON Data Source
    ↓
C# Data Parser
    ↓
Machine Manager
    ↓
Load Data on each Machine
    ↓
Unity 3D Visualization + Dashboard UI
```

## Technologies Used

- Unity
- C#
- JSON
- TextMeshPro

## Machine Simulation Rules

### Blast Furnace
- Running: 1300°C – 1550°C
- Warning: >1600°C or <1200°C
- Offline: 0°C

### Conveyor
- Running: 40°C – 70°C
- Warning: 71°C – 90°C
- Offline: 0°C

### Cooling System
- Running: 10°C – 25°C
- Warning: >30°C
- Offline: 0°C

## Project Purpose

This prototype was built as a simulation of industrial system monitoring workflows involving concepts such as:

- SCADA visualization
- IoT operational data
- Real-time monitoring dashboards
- Industrial 3D interfaces

## Future Improvements

- API integration
- SQL database connectivity
- Historical machine logs
- Alert notification system
- Multi-platform deployment

## Demo
<img width="1119" height="602" alt="image" src="https://github.com/user-attachments/assets/d7ffce89-8dfe-4871-8ff6-2aca308157a2" />



https://github.com/user-attachments/assets/3b33875c-d5bb-4c07-ac2e-47a7354286ae



