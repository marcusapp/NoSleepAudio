# NoSleepAudio

**NoSleepAudio** is a background audio player program designed to keep continuous audio output, preventing Bluetooth devices like headset from disconnecting due to inactivity. Built with **C#** and **.NET Framework 4.0**, this lightweight application ensures a seamless listening experience by continuously playing audio files. 

![Image](https://github.com/user-attachments/assets/a43a2b84-49dd-4c24-9421-0b7e9f2d844b)

_Keep your audio devices alive!_

----------

## 📋 System Requirements

-   **Operating System**: Windows XP or later (compatible with .NET Framework 4.0).
-   **Storage**: At least 10 MB of free space (excluding audio files).
-   **Audio Files**: Supports `.mid`, `.midi`, `.mp3`, `.wma`, and `.wav` formats.

----------

## 🚀 Installation Guide

### Step 1: Download NoSleepAudio

1.  Download the latest `NoSleepAudio.exe` executable from [GitHub Releases](https://github.com/marcusapp/NoSleepAudio/releases).
2.  Just place it on anywhere you like as a portable exe.

### Step 2: Prepare Audio Files

1.  Create a folder named `NoSleepAudioMusic` in the same directory or program will auto create it if not exists.
2.  Place your audio files (`.mid`, `.midi`, `.mp3`, `.wma`, `.wav`) into the `NoSleepAudioMusic` folder.
    -   You can add your favourite audio files, and the program will automatically play them all.
    -   Or just using slient audio [blank-audio](https://github.com/anars/blank-audio) in background.

### Step 3: Run the Program

1.  Double-click `NoSleepAudio.exe` to launch the application.
2.  The program will automatically scan the `NoSleepAudioMusic` folder and begin continuous playback.

----------

## 🎵 Usage Instructions

1.  **Launch the Program**:
    
    -   Run `NoSleepAudio.exe`, and the program will automatically load audio files from the `NoSleepAudioMusic` folder.
2.  **Playback Management**:
    -   The program defaults to looping all supported audio files.
    -   Supported formats include `.mid`, `.midi`, `.mp3`, `.wma`, and `.wav`.
3.  **Exit the Program**:
    -   Right click the tray icon then choose [Exit] on the tray menu.

----------

## 📂 Folder Structure

Below is an example of the standard folder structure for NoSleepAudio:

```
NoSleepAudio/
├── NoSleepAudio.exe
├── NoSleepAudioMusic/
   ├── music1.mp3
   ├── music2.wav
   ├── music3.mid
   └── music4.wma

```

-   **NoSleepAudio.exe**: The main executable file.
-   **NoSleepAudioMusic/**: The folder for storing audio files, supporting multiple files.

----------

## 🛠️ Developer Information

NoSleepAudio is developed using **C#** and **.NET Framework 4.0**, leveraging Windows' native audio playback capabilities for high performance and stability. Key technical details include:

-   **Programming Language**: C#
-   **Framework**: .NET Framework 4.0
-   **Audio Playback**: Utilizes Windows Media Player COM component (for `.mp3`, `.wma`, etc.).
-   **File System**: Dynamically scans the `NoSleepAudioMusic` folder, supporting multiple audio formats.

----------

## 📜 License

NoSleepAudio is released under the [MIT License]. You are free to use, modify, and distribute this software, provided the original copyright notice is retained.
