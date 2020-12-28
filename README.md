# Pause System

* Pause System for Unity games.
* Unity minimum version: **2018.3**
* Current version: **0.1.0**
* License: **MIT**

## Summary

[...]

## How To Use

### Using [...]

## Installation

### Using the Package Registry Server

Open the **manifest.json** file inside your Unity project's **Packages** folder and add this code-block before `dependencies` attribute:

```json
"scopedRegistries": [ 
	{ 
		"name": "Action Code", 
		"url": "http://34.83.179.179:4873/", 
		"scopes": [ "com.actioncode" ] 
	} 
],
```

The package **ActionCode-Pause System** will be available for you to install using the **Package Manager** windows.

### Using the Git URL

You will need a **Git client** installed on your computer with the Path variable already set. 

Use the **Package Manager** "Add package from git URL..." feature or add manually this line inside `dependencies` attribute: 

```json
"com.actioncode.pause-system":"https://bitbucket.org/nostgameteam/pause-system.git"
```

---

**Hyago Oliveira**

[BitBucket](https://bitbucket.org/HyagoGow/) -
[Unity Connect](https://connect.unity.com/u/hyago-oliveira) -
<hyagogow@gmail.com>