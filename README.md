# unity-proximity-exploder
Proximity-based object exploder for Unity. Displaces the faces of an object to varying degrees, based on the distance between the object and the player.

### Requirements
* Fragmentum shader: https://www.assetstore.unity3d.com/en/#!/content/8264

### Set-up Instructions
* Download Fragmentum from the Unity Asset Store: https://www.assetstore.unity3d.com/en/#!/content/8264
* Save ExploderController.cs and ExploderParams.cs to your project’s scripts folder.
* Create an empty Game Controller object if you don’t already have one in your scene.
* Add ExploderController.cs to your controller object.
* In the Exploder Controller parameters:
  - Drag your player object to the ‘Player’ field.
  - Add values for Default Max Distance and Default Min Distance. These set range distances where the displacement changes.
  - Optional: Drag a canvas text object to the ‘Debuggin’ field. This will dump raw values.
* For every object you want to explode:
  - Set the object’s tag to ‘ExpObj’
  - Add Fragmentum Controller script
  - Create Fragmentum shader if necessary
  - In the parameters for the Fragmentum Controller script:
    - Check ‘Scalable Fragments’
    - Set Dynamic Rotation to “Around Parent Origin’

If you would like to set a different active distance range for an object, add the ExploderParams.cs script to it and set a new Min and Max in its parameters panel.