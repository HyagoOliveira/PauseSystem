# Pause System

* Pause System for Unity games.
* Unity minimum version: **2021.2**
* Current version: **1.0.0**
* License: **MIT**

## Summary

Easily subscribe classes to Pause/Resume events and execute code when they happen.

## How To Use

### Using Pause System Scriptable Object

Create a new Pause System asset by using the Create menu, **ActionCode > Pause Manager > Settings** or using the default one provided on the [Settings folder](/Settings).

You can reference the `PauseSystem` and subscribe your classes to the `OnPaused` and `OnResumed` events, just like the following:

```csharp
using UnityEngine;
using ActionCode.PauseSystem;

namespace YourNamespace
{
    public sealed class PauseExample : MonoBehaviour 
    {
	    [SerializeField] private PauseSettings settings;
	    
	    private void OnEnable ()
	    {
		    settings.OnPaused += HandlePaused;
		    settings.OnResumed += HandleResumed;
	    }
        
	    private void OnDisable ()
	    {
		    settings.OnPaused -= HandlePaused;
		    settings.OnResumed -= HandleResumed;
	    }
	    
	    private void HandlePaused () => print("The Game was Paused.");
	    
	    private void HandleResumed () => print("The Game was Resumed.");
    }
}
```

> **Attention**: do not forget to unsubscribe the events since it is not done automatically

After that, you just have to call the `Pause()` and `Resume()` functions, or the `Toggle()` for a Pause button behaviour.

### Pause/Resume AudioSource Components

Pause and resume AudioSource components is a very common feature. 
Thus, the [PauseAudioSource](/Runtime/Components/PauseAudioSource.cs) component was created to easily do that.

## Installation

### Using the Package Registry Server

Follow the instructions inside [here](https://cutt.ly/ukvj1c8) and the package **ActionCode-Pause System** 
will be available for you to install using the **Package Manager** windows.

### Using the Git URL

You will need a **Git client** installed on your computer with the Path variable already set. 

- Use the **Package Manager** "Add package from git URL..." feature and paste this URL: `https://github.com/HyagoOliveira/PauseSystem.git`

- You can also manually modify you `Packages/manifest.json` file and add this line inside `dependencies` attribute: 

```json
"com.actioncode.energy-system":"https://github.com/HyagoOliveira/PauseSystem.git"
```

---

**Hyago Oliveira**

[GitHub](https://github.com/HyagoOliveira) -
[BitBucket](https://bitbucket.org/HyagoGow/) -
[LinkedIn](https://www.linkedin.com/in/hyago-oliveira/) -
<hyagogow@gmail.com>