Designing a small mini project (Right now just a concept. Susceptible to change)

Goal: A 2D-Platformer (not confirmed yet) where you will control a little robot (customizable initial color) which will roam around the planet to collect different types of blueprints for suits to build and defend against the oncoming attackers.

Map Editor
  A simple standard editor to design a world and implement a test state
  Create static levels to get this engine working before implementing dynamic level generation
  Main goal to dynamically build levels for playability. 


LunarIllusions
  Play as a mini robot (a small square robot with an eye) who can:
      Build different bigger robots and sync up with them
      Built from different blueprints
      Vector based blueprints to allow armor swapping
      Coordinate attacking to allow easibility of weapon customization
  Configuration files for 
      Vector based animation/battling...etc
      Default Stats
      (If leveling up) % chance of leveling up a state aka HP, DEF...etc
  Level Design
      Dynamically generate a map/random world (Keep Completely random if possible NO SEEDS)
  
Internal Development
  Selected tile to grab the current level of data from the sprite sheet
  Expand the Tile.cs class for storing the source rectangle inside of the sprite sheet (x,y) coordinates might be fine for now
  Dynamically generate buttons for UI layout. 
  Develop methods to call from dynamically generated buttons. 

Research
  See if we can allow compile code for the user to develop button functionality. 
  For example add a copy function, paste, cut, move, ...etc