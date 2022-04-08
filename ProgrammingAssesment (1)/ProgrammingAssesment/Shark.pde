class Attacker
{
  //use of pvector
  //initialising
  PVector pos;
  PVector vel;
  PVector acc;
  final PImage shark = loadImage("shark.png");
  final PImage sharkFlip = loadImage("sharkFlip.png");
  final PImage sharkOpen = loadImage ("sharkOpen.png");
  final PImage sharkOpenflip = loadImage ("sharkOpenflip.png");
  int count;

  //Constructor
  Attacker ()
  {
    //declaring position, velocity and acceleration
    pos = new PVector((int)random(500, 950), (int)random(800));
    vel = new PVector (0, 0);
    acc = new PVector (0, 0);

    shark.resize(75, 75);
    sharkFlip.resize(75, 75);
    sharkOpen.resize(75, 75);
    sharkOpenflip.resize(75, 75);
  }

  void update()
  {    
    //use of pvectors to say in which direction the shark must attack, in this case shark follows whale
    PVector Player = new PVector(Whale.xLeft, Whale.yLeft);
    PVector dir = PVector.sub(Player, pos);
    //normalise vector
    dir .normalize();
    acc = dir;

    // makes the sharks move in direction of whale
    //moving at a constant speed and certain direction
    vel.add(acc);
    //limits speed of sharks
    Shark1.vel.limit(1.55);
    Shark.vel.limit(1.25);
    pos.add(vel);
  }


  //animate sharks if certain criteria are met
  void render()
  {
    if (Whale.xLeft <= pos.x)
      if (count<30)
      {
        image(shark, pos.x, pos.y);
      } else if (count <59)
      {
        image(sharkOpen, pos.x, pos.y);
      } else 
    {
      image(shark, pos.x, pos.y);
      count=0;
    } else if (Whale.xLeft >= pos.x)
      if (count<30)
      {
        image(sharkFlip, pos.x, pos.y);
      } else if (count <59)
      {
        image(sharkOpenflip, pos.x, pos.y);
      } else 
    {
      image(sharkFlip, pos.x, pos.y);
      count=0;
    }
    count++;
  }

  //collision code
  boolean crash(Player Whale) 
  {
    return abs(pos.x-Whale.xLeft) < 38 && abs(pos.y - Whale.yLeft) < 18;
  }
}
