# Pause System

* Pause System for Unity games.
* Unity minimum version: **2021.2**
* Current version: **1.2.0**
* License: **MIT**
* Dependencies:
	- [com.actioncode.awaitable-coroutines](https://github.com/HyagoOliveira/AwaitableCoroutines/tree/1.0.0)

## Summary

Easily subscribe classes to Pause/Resume events and execute code when they happen.

## How To Use

### Using Pause Manager static class

You can reference the `PauseManager` and subscribe your classes to the `OnPaused` and `OnResumed` events, just like the following:

```csharp
using UnityEngine;
using ActionCode.PauseSystem;

namespace YourNamespace
{
    public sealed class PauseExample : MonoBehaviour 
    {
	    private void OnEnable ()
	    {
		    PauseManager.OnPaused += HandlePaused;
		    PauseManager.OnResumed += HandleResumed;
	    }
        
	    private void OnDisable ()
	    {
		    PauseManager.OnPaused -= HandlePaused;
		    PauseManager.OnResumed -= HandleResumed;
	    }
	    
	    private void HandlePaused () => print("The Game was Paused.");	    
	    private void HandleResumed () => print("The Game was Resumed.");
    }
}
```

> **Attention**: do not forget to unsubscribe the events since it is not done automatically

After that, you just have to call the `Pause()`, `Resume()` or `Toggle()` funcion from `PauseManager`.

### Pause/Resume AudioSource Components

Pause and resume AudioSource components is a very common feature. 
Thus, the [PauseAudioSources](/Runtime/Components/PauseAudioSources.cs) component was created to easily do that.

### Pause/Resume other Components

You can use [PauseBehaviours](/Runtime/Components/PauseBehaviours.cs) component to pause and resume other components serialized on the `behaviours` array.

## Installation

### Using the Package Registry Server

Follow the instructions inside [here](https://cutt.ly/ukvj1c8) and the package **ActionCode-Pause System** 
will be available for you to install using the **Package Manager** windows.

### Using the Git URL

You will need a **Git client** installed on your computer with the Path variable already set. 

- Use the **Package Manager** "Add package from git URL..." feature and paste this URL: `https://github.com/HyagoOliveira/PauseSystem.git`

- You can also manually modify you `Packages/manifest.json` file and add this line inside `dependencies` attribute: 

```json
"com.actioncode.pause-system":"https://github.com/HyagoOliveira/PauseSystem.git"
```

---

**Hyago Oliveira**

[GitHub](https://github.com/HyagoOliveira) -
[BitBucket](https://bitbucket.org/HyagoGow/) -
[LinkedIn](https://www.linkedin.com/in/hyago-oliveira/) -
<hyagogow@gmail.com>