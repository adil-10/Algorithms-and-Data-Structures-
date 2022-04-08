//Game Assignment
Player Whale; 
Attacker Shark, Shark1;
timer startTimer, startTimer1;
final int gamePlaying = 0; // Playing state
final int gameFinished = 1; // finished state
int gameMode = gamePlaying; 
int spawnTimer = 0;
int SCORE = 0;
PImage startScreen;
PImage backGround;
int backGroundx = 0;
ArrayList<Coin> coinList = new ArrayList();
ArrayList <fallingRock> rockList = new ArrayList();

void setup()
{
  size (1000, 900);
  startScreen = loadImage("water.jpg");
  startScreen.resize(width, height);  
  backGround = loadImage("underWater.jpg");
  backGround.resize(width, height);  
  startTimer1 = new timer(15); 
  startTimer = new timer(75); //call CountDown constructor – 60 secs    
  Whale = new Player(10, 500, 10, 500);
  Shark = new Attacker ();
  Shark1 = new Attacker();

  //loops 10 times image will be between declared x and y co-ordinats
  //used for displaying 0 coins at the start of program
  for (int i = 0; i<15; i ++) {
    coinList.add(new Coin((int) random (100, 950), (int)random(800)));
  }
}

void draw()
{
  //condition to check if the timer is greater than 0, then loads a start screen
  if (startTimer1.durationSeconds-millis()/1000 > 0)
  {
    image(startScreen, 0, 0);
    textSize(30);
    fill(205, 252, 90);
    text("Time untill game starts: "+startTimer1.getRemainingTime(), width/2, height/2); //shpws time till game starts
    text("Welcome to Shark Attack", 40, 60);
    textSize(15);
    text("You have got 60 seconds to collect the coins, do not get caught by the sharks, you will lose\n do not get hit by the rocks as you will lose points", 40, 100);
    text("To pause the game you may press the 'space' key and to continue playing press the 'a' key", 40, 175);
    text("Credits to: \n rock: https://tyrnannoght.alleycat.be \n splashscreen wallpaper: wallpapertag - https://wallpapertag.com/under-water-background \n game moving background: dreamstime - https://www.dreamstime.com/illustration/underwater-game-background.html \n shark: pintrest - https://www.pinterest.es/pin/306878162086471952/ \n whale: open game art - Mepavi @ You're Perfect Studio", 40, 225);
    //when timer reaches 0 loads game
  } else
  {
    background(0);
    fill(0);
    //used when coins and rocks must re-spawn
    if (gameMode==gamePlaying)
    {
      spawnTimer++;//adds 1 to spawn timer
      if (spawnTimer % 180 == 0) //mod function, approx ever 3 seconds adds new image into array
      {
        //loads rock in random x position but above the screen
        rockList.add(new fallingRock((int)random(950), -5));
      }
      if (spawnTimer % 240 == 0) //mod function, approx ever 4 seconds adds new image into array
      {
        //loads coin in random location.
        coinList.add(new Coin((int) random (950), (int)random(800)));
      }

      drawBG();
      Shark.render();
      Shark.update();
      Shark1.render();
      Shark1.update();
      Whale.render();
      score();

      text("Current Timer: "+startTimer.getRemainingTime(), 20, 20); //display seconds remaining on top left

      //display coin on screen, array constantly grown larger or smaller
      for (int i = 0; i< coinList.size(); i++)
      {
        //puts out 1st item then 2nd item etc etc from array
        Coin currentCoin = coinList.get (i);
        currentCoin.render();

        //if crash code occurs and is true then removes a fish from the screen 
        if (Whale.crash(currentCoin))
        {
          coinList.remove(currentCoin);
          //add 1 to score each time collision occures
          SCORE++;
        }
      }

      //used to display rock and upate method for moving, array continiously growns and shrinks.   
      for (int i=0; i< rockList.size(); i++)
      {
        fallingRock currentRock = rockList.get(i);
        currentRock.update();

        //crash code
        if (currentRock.crash(Whale))
        {
          //removes rock from array
          rockList.remove(currentRock);
          //removes point if collision occurs
          SCORE--;
        }
      }

      //if collision with shark occurs display game over
      if (Shark.crash(Whale))
        endScreen();
      if (Shark1.crash(Whale))
        endScreen();
    }
    //if timer reaches 0 display game over
    if (startTimer.durationSeconds-millis()/1000 == 0)
    {
      endScreen();
    }
  }
}

//allows the background to move
void drawBG()
{
  image(backGround, backGroundx, 0); //draw background twice 
  image(backGround, backGroundx+backGround.width, 0);
  backGroundx -=1; //move background 1 pixels to left
  if (backGroundx == -backGround.width) 
    backGroundx=0; //wrap background
}

void keyPressed() 
{
  //allows the whale to move in all directions, limits whale to be on screen
  if (key == CODED)
  {
    if (keyCode == LEFT && Whale.xLeft > 0)
    {
      Whale.whaleRight = false;
      Whale.xLeft -= 5;
      Whale.xRight-= 5;
    } else if (keyCode == RIGHT && Whale.xRight < width-50)
    {
      Whale.whaleRight = true;
      Whale.xRight += 5;
      Whale.xLeft+= 5;
    } else if (keyCode == UP && Whale.yLeft > 0)
    {
      Whale.yLeft -= 5;  
      Whale.yRight -= 5;
    } else if (keyCode == DOWN && Whale.yLeft < height-100)
    {
      Whale.yLeft += 5;
      Whale.yRight += 5;
    }
  }

  //pause and play game
  if (key == ' ')
    gameMode = gameFinished;
  if (key == 'a')
    gameMode = gamePlaying;
}

//score system
void score()
{
  text("Current score is: "+ SCORE, 20, 40);
}

//end screen
void endScreen()
{
  background(0);
  fill(255);
  textSize(15);
  text("GAME OVER, Your current score is : "+ SCORE, width/2, height/2);
  //stops code completly
  noLoop();
}
