Unity Bitwise Operations

There are five attributes that player can have:  
  - Charisma
  - Fly
  - Intelligence
  - Invisible
  - Magic  
      
For each attribute, there is one door and respective key to open it. Only way to pass through the door is collect its key.  
All doors and keys tagged for collision detection.  
Main camera has `CameraFollower` script for following player as it moves or rotates.  
Attributes stored as enums.
Attributes that player has are shown with UI Text.

Player has two animations, `idle` and `running`. Simple animator added that makes transitions between animations with parameter `isRunning`.  
Player has `PlayerController` script for moving or rotating it.  
Player has Capsule collider on it.  
Player has `AttributeManager` script for handling collisions and triggers with doors and keys.  
- With `OnCollisionEnter` function:  
    - if player collides with key then add that attribute the player via bitwise operations and then remove the key from scene.
    - if player collides with door then if player has the attribute for passing through the door, make the door box collider's `isTrigger` true and then in `OnTriggerExit` which means player passed the door, make door's `isTrigger` false again so that player can't pass the door again and remove its attribute via bitwise operations.



