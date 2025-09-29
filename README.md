# Customizeable Jarvis (C# / Visual Studio 2008)

## Overview
This repository contains the source code of **Customizeable Jarvis**, a Windows Forms application originally developed with **Microsoft Visual Studio 2008**.  
It represents a snapshot of how desktop applications were built in the late 2000s — before AI assistants like ChatGPT and before modern package managers became standard.

Back then, most of the coding was done entirely by hand, user interfaces were designed with WinForms, and external libraries were often downloaded manually as `.dll` files.  
In this project, you will still see that spirit, although one dependency (`taglib`) later appears via **NuGet**.

## Project Structure
- `Form1.cs` – Main application window (WinForms).  
- `Program.cs` – Entry point of the application.  
- `Customize.cs`, `AlarmClock.cs`, `RSSReader.cs` – Core logic modules.  
- `.resx` files – Resource files for forms.  
- `.csproj` – Project configuration (originally targeting .NET Framework 4.0 Client Profile).  
- `packages.config` – Declares a dependency on `taglib` (added later).  

## Requirements
- **Visual Studio 2008** (original IDE).  
- .NET Framework 4.0 Client Profile.  

> ⚠️ Modern Visual Studio versions (2019/2022) can still open this project, but you may need to retarget the framework or restore dependencies.

## Dependencies
- **TagLib#** (`taglib` NuGet package, version 2.1.0.0).  
  If you open this project in a modern IDE, run:  
  ```bash
  nuget restore
  ```

In the original era of Visual Studio 2008, such dependencies would have been downloaded manually and added as `.dll` references.

## How to Build
1. Open `JarvisReiven.csproj` in Visual Studio.  
2. Restore the NuGet package (`taglib`) if using a modern environment.  
3. Build the solution (`Build → Build Solution`).  
4. Run the application (`F5`).  

## Historical Context
This project showcases software development in a **pre-AI era**, when:  
- Developers wrote everything by hand.  
- There was no ChatGPT or similar assistants.  
- Libraries were not pulled automatically from repositories — instead, developers searched online, downloaded `.dll` files, and added them manually.  

The presence of `packages.config` shows that at some later point the project was updated to use **NuGet**, but its **architecture and style remain rooted in 2008 practices**.

## Author and Credits

JOSEMAR PEDRO.
Compiled date   : Before January, 2017.
CREDITS: Modify and Adapt to portuguese version and function voice.


```

## License
Choose a license (e.g., MIT) before publishing to make the repository open source.

---
✨ This project is preserved for historical and educational purposes. It demonstrates how developers used to work before modern tooling automated much of the process.
