class Player //<>//
{
  boolean whaleRight = true; 

  //class members
  //whale left
  int xLeft, yLeft;
  ArrayList <PImage>imagesWhaleleft;
  int imageCountleft = 0;

  //class members
  //whale right
  int xRight, yRight;
  ArrayList <PImage>imagesWhaleright;
  int imageCountright = 0;

  //constructor
  Player (int xLeft, int yLeft, int xRight, int yRight)
  {
    PImage imgLeft;
    PImage imgRight;
    this.xLeft = xLeft;
    this.yLeft = yLeft;
    this.xRight = xRight;
    this.yRight = yRight;

    //loading left whale
    //allows images to be loaded and set to correct size
    imagesWhaleleft = new ArrayList <PImage>();
    for (int count = 1; count<=4; count=count+1)
    {
      imgLeft = (loadImage("whale" + count+ ".png"));
      imgLeft.resize(50, 50);
      imagesWhaleleft.add(imgLeft);
    }

    //loading right whale  
    //allows images to be loaded and set to correct size
    imagesWhaleright = new ArrayList <PImage>();
    for (int countRight = 1; countRight<=4; countRight=countRight+1)
    {
      imgRight = (loadImage("whale" + countRight+ "Flip.png"));
      imgRight.resize(50, 50);
      imagesWhaleright.add(imgRight);
    }
  }        

  void render()
  {  
    //if true then draw image of whale facing in left direction
    if (this.whaleRight == false)
    {       
      int imageNumber = imageCountleft/10; //gets position of the image
      //gets image and animates the image, looks like whale is swimming
      PImage currentImage = imagesWhaleleft.get( imageNumber);
      imageCountleft++;
      if (imageCountleft==40)
      {
        imageCountleft=0;
      }
      // renders current image based on which needs to be loaded 
      image(currentImage, this.xLeft, this.yLeft);
    } 
    //same as previous but this is for whale facing in right direction
    else if (this.whaleRight == true)
    {     
      int imageNumberright = imageCountright/10; //gets position of the image
      //gets image and animates the image, looks like whale is swimming
      PImage currentImageright = imagesWhaleright.get( imageNumberright); 
      imageCountright++;
      if (imageCountright==40)
      {
        imageCountright=0;
      }
      image(currentImageright, this.xRight, this.yRight);
    }
  }

  //returns true when whale and fish are close to eachother
  boolean crash(Coin coin) 
  {
    return abs(this.xLeft-coin.x) < 38 && abs(this.yLeft - coin.y) < 38;
  }
}
