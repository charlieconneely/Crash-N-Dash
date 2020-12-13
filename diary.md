## Developer Diary 


### Road Spawning
***Task***: Create the illusion of an endless road by continually spawning road objects. <br>
***Solution***: 
* Prefab road object with large spawn triggers at the end.
* Add all roads present on scene to List in `RoadSpawner.cs`
* When player enters spawn trigger - initiate `MoveRoad()` method which will:
  * Take road game object at the bottom of list (`roads[0]`)
  * Remove this object from list
  * Set it's z transform to that of the last/furthers road on the list (+ offset)
  * Add road to the end of the list. 


### Obstacle Spawning
***Task***: Spawn obstacles (cars, cones etc.) randomly on a newly spawned road <br>
***Solution***:
* The road prefab contains empty game objects which act as spawn points.
* These spawn points are collected into a List in `ObstacleSpawner.cs`
* After a road has been moved to its new z position inside `RoadSpawner.cs`, the <br/> `ReceiveRoad()` method in `ObstacleSpawner.cs` is called.
* The `ReceiveRoad()` method will: 
  * Clear whatever is in the arrays at first.
  * Repopulate the spawn points array with the spawn point objects on the current road <br/> object passed in as a parameter.
  * Call `SpawnObstacles()` which will: 
    * Spawn cars randomly at the position of one of these spawn point objects. 
    * Spawn other objects randomly within the general confines of the road object. 


### Speed increase
***Task***: Ensure the player's speed increases gradually throughout gameplay <br>
***Solution***: 
* Use an if statement to determine if the current time in seconds is a factor of 10.
* If it is - increment the speed by `speedIncreaseRate` (0.5) multiplied by `Time.deltaTime` 
* `Time.deltaTime` is necessary to prevent the incrementation from occuring too many times in that one second period. 

### Item collision
***Task***: Handle events correctly on collision with particular game objects. <br>
***Solution***: 
* Assign tag to each game item (jerry can, traffic cone etc.)
* Define the events which occur for each object inside `GameController.cs`
  * e.g if hits petrol can - call `GainPoints` method, which adds to player score variable.
* Inside `OnTriggerEnter` method inside `PlayerMovement.cs`:
  * Determine the tag of the `Collider` object param.
  * For each item: 
    * Execute a particular method inside `GameController.cs` e.g. `case: "PetrolCan" { GameController.GainPoints(); }`
    * Play appropriate sound using the `Play()` method in `AudioManager.cs`
    * Destroy the item (if player hits a petrol can - it should disappear). 

### Sound Management
***Task***: Implement an organised system to manage game sounds <br>
***Solution***: 
* Create `Sound` class with attributes:
  * `string name`
  * `AudioClip clip`
  * `float volume`
  * `float pitch`
  * `bool loop` 
  * `AudioSource source` 
* Inside `AudioManager.cs`:
  * Call `DontDestroyOnLoad(gameObject)` so that this `AudioManager` will remain consistent across scenes. 
  * Create a serializable array of `Sound` objects.
  * Add source components to each `Sound` item on awake.
  * This allows me to easily add + configure sounds from the unity inspector.
  * The `Play(string name)` method will find the right sound item using the name param, and play the audio clip.
  * The play function in `AudioManager.cs` can be called from any class with the following statement:
    * `FindObjectOfType<AudioManager>().Play("SoundName");` <a></a>

***Task***: Control music + effects volume levels using canvas sliders<br>
***Solution***: 
* Create two sliders UI objects in the Settings canvas - one for effects, one for music.
* Add two Serializable UI.Slider variables to `SettingsMenu.cs`  
* The music slider will trigger `SetMusicVolume(float v)` in `SettingsMenu.cs`.
* `SetMusicVolume` will:
  * Call the `AdjustVolume(float v, string n)` method in `AudioManager.cs`, passing the (float) volume and (string) "Theme".
  * The `AdjustVolume` method will set the volume of the theme Sound object to the volume passed in **if** the string param == "Theme"
* The effects slider will trigger `SetEffectsVolume(float v)` in `SettingsMenu.cs`
* `SetEffectsVolume` will:
  * Call the `AdjustVolume(float v, string n)` method in `AudioManager.cs`, passing the (float) volume and an empty string ("").
  * The `AdjustVolume` method will set the volume of every Sound object that isn't named "Theme" to the volume passed in **if** the string param == ""
