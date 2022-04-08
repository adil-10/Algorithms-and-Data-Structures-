class Coin
{
  int x;
  int y ;
  int counter = 0; // int default value is 0, float = 0.0, boolean = false

  final PImage coin1 = loadImage("coin1.png");
  final PImage coin2 = loadImage("coin2.png");
  final PImage coin2flip = loadImage("coin2flip.png");
  final PImage coin3 = loadImage("coin3.png");
  final PImage coin3flip = loadImage("coin3flip.png");
  final PImage coin4 = loadImage("coin4.png");

  //constructor
  Coin (int x, int y)
  {
    this.x = x;
    this.y = y;

    //resize coin
    coin1.resize(30, 30);
    coin2.resize(30, 30);
    coin2flip.resize(30, 30);
    coin3.resize(30, 30);
    coin3flip.resize(30, 30);
    coin4.resize(30, 30);
  }

  void render()
  {
    //draws image and makes it look animated
    if (counter < 10)  
      {image(coin1, x+10, y);} // 0 to 9 (10)
    else if (counter < 20) 
      {image(coin2, x+10, y);} // 10 to 19 ()10
    else if (counter < 30)
      {image(coin3, x+10, y);} //20 to 29(10)
    else if (counter < 40)
      {image(coin4, x+10, y);} // 30 to 38 (9)
    else if (counter <50)
      {image (coin3flip, x+10, y);}
    else if (counter <59)
      {image (coin2flip, x+10, y);}
    else 
      {image(coin1, x+10, y);
      counter=0;}
      //incriment counter
    counter++;
  }
}
