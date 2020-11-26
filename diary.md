## Developer Diary
<hr/>
### Road Spawning <br>
*Task*: Create the illusion of an endless road by continually spawning road objects. <br>
*Solution*: 
* Prefab road object with large spawn triggers at the end.
* Add all roads present on scene to List in `RoadSpawner.cs`
* When player enters spawn trigger - initiate `MoveRoad()` method which will:
  * Take road game object at the bottom of list (`roads[0]`)
  * Remove this object from list
  * Set it's z transform to that of the last/furthers road on the list (+ offset)
  * Add road to the end of the list. 

### Obstacle Spawning <br>
### Speed increase <br>