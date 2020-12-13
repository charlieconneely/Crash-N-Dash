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
  * Call `SpawnObstacles()` which will:<br/> - Spawn cars randomly at the position of one of these spawn point objects. <br/> - Spawn other objects randomly within the general confines of the road object. 


### Speed increase
***Task***: Ensure the player's speed increases gradually throughout gameplay <br>
***Solution***: 
* Use an if statement to determine if the current time in seconds is a factor of 10.
* If it is - increment the speed by `speedIncreaseRate` (0.5) multiplied by `Time.deltaTime` 
* `Time.deltaTime` is necessary to prevent the incrementation from occuring too many times in that one second period. 

### Item collision
***Task***: Handle events correctly on collision with particular game objects. <br>
***Solution***: 
* Inside `OnTriggerEnter` method inside `PlayerMovement.cs`:
  * Switch statement...
