class fallingRock
{
  int x;
  int y ;
  final PImage img = loadImage("rock.png");

  //constructor --> responsible for building object of this class
  fallingRock(int x, int y) 
  {
    this.x = x;
    this.y = y;
    img.resize(25, 25);
  }

  void update()
  {
    move();
    render();
  }

  void move()
  {
    //allows rock to fall looks like its falling from sky
    if (y>= height-50)
    {
      y= height - 50 ;
    } else 
    y=y+4;
  }

  void render()
  {
    image(img, x, y);
  }

  //crash code 
  boolean crash(Player Whale) 
  {
    return abs(this.x-Whale.xLeft) < 38 && abs(this.y - Whale.yLeft) < 18;
  }
}
