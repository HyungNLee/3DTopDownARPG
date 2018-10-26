# Unity - 3D Action RPG

#### By Ryan Lee

### Implemented 
* Player movement. Added 'player' script which inherits from 'character' script.
  * Used .Normalize on Vector3 direction to make diagonal move distance the same as horizontal and vertical.
  * Added dashing functionality with the hotkey 'Space'.
  * Added Turning() in 'player' so the player will always face where the mouse is.
* Added enum states to character script.
* Added right-click and 'Q' spell cast functions.

#### Work in Progress Features
* Master spell link to house all spells instead of hard coding them into the player script.

###### Notes
* [SerializeField] -> above a variable allows the variable to be private but still show up in the Unity editor.
* Update functions from parent scripts are able to be overrwritten and then called in the child script to allow ordering of functions. 
  * For example, the Move() from parent 'character' script needs the direction variable value from GetInput() from child 'player' script.
* Use 'protected' access level for variables to allow the variable to be private but also be accessed by children scripts.
