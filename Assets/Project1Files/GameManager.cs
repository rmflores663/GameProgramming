using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    Player p1 = new Player();
    string a = "As you awaken from your campsite you feel cold. You remember you have a fire to the north.";
    bool display1, display2, display3, display4, display5 = false;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello World");
        //Feature Point, UI Text
        GameObject localReference = GameObject.Find("Story");
        localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Feature Point, UI Buttons
    public void buttonClicked(int val)
    {
        //depending on button pressed, move the player accordingly
        switch (val)
        {
            case 1:
                p1.moveUp();
                break;
            case 2:
                p1.moveDown();
                break;
            case 3:
                p1.moveLeft();
                break;
            case 4:
                p1.moveRight();
                break;
        }
        p1.getLocation();
        if (!p1.getIfWarm() && !display1)
        {
            GameObject localReference = GameObject.Find("Story");
            a = "The dying fire warms you if at least a little bit. The cold is quickly replaced with hunger. You remember you left your fishing rod back where you came from.";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
            display1 = true;
        }else 
        if (p1.getHasRod() && !display2)
        {
            GameObject localReference = GameObject.Find("Story");
            a = "As you look around, you find your fishing rod right next to where you woke up. Its a bit damaged but you think you could get a singe use out of it. You remember hearing a pond west of the fire";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
            display2 = true;
        }else
        if(p1.getHasRod() && p1.getIfAtFire() && !display3)
        {
            GameObject localReference = GameObject.Find("Story");
            a = "Looking back at where the fire was, all you see is ash. The fire has gone fully out. Your hearing hasn't failed you yet, the pond is directly west from the fire";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
            display3 = true;
        }else
        if (p1.getHasFish() && !display4)
        {
            GameObject localReference = GameObject.Find("Story");
            a = "Reaching the pond, you cast your fishing rod into the pond. After 15 minutes, you catch a sizable fish. You should head back to the Fire";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
            display4 = true;
        }else
        if (p1.getHasRod() && p1.getIfAtFire() && display3 && !display5)
        {
            GameObject localReference = GameObject.Find("Story");
            a = "The fire is still out. You should leave before the fish gets bad. You remember the exit was North then east from your fire.";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
            display3 = true;
        }else
        if (p1.getIsAtCar())
        {
            GameObject localReference = GameObject.Find("Story");
            a = "After a long day in the woods, you drive back home to cook the fresh fish.";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
        }else
        if (p1.getIsNearDog())
        {
            GameObject localReference = GameObject.Find("Story");
            a = "You can hear a dog nearby, you dont want it to take your fish.";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
        }
        else
        if (p1.getLostFish())
        {
            GameObject localReference = GameObject.Find("Story");
            a = "You have lost your fish";
            localReference.GetComponent<TextMeshProUGUI>().text = a.ToString();
        }
    }


    //Player Class
    public class Player
    {
        //player locations vector
        private Vector2 position = new Vector2(0, -8);
        private Vector2 prevposition = new Vector2(0, -8);

        //player collectables
        private bool isCold, hasRod, hasfish, backAtFire, isAtCarLoc, isNearDanger, lostFish;

        private int[][] roomDimentions = new int[9][];
        private int[][] roomLocaions = new int[9][];


        //player initializer
        public Player()
        {
            isCold = true;
            hasRod = false;
            hasfish = false;
            backAtFire = false;
            isAtCarLoc = false;
            isNearDanger = false;
            lostFish = false;

            //Feature point pt1 Initializing a list of arrays
            roomDimentions[0] = new int[] { 5, 5 };
            roomDimentions[1] = new int[] { 3, 5 };
            roomDimentions[2] = new int[] { 7, 5 };
            roomDimentions[3] = new int[] { 5, 3 };
            roomDimentions[4] = new int[] { 5, 5 };
            roomDimentions[5] = new int[] { 3, 8 };
            roomDimentions[6] = new int[] { 7, 5 };
            roomDimentions[7] = new int[] { 7, 3 };
            roomDimentions[8] = new int[] { 7, 5 };

            roomLocaions[0] = new int[] { -2, -10 };
            roomLocaions[1] = new int[] { -1, -6 };
            roomLocaions[2] = new int[] { -3, -2 };
            roomLocaions[3] = new int[] { -7, -1 };
            roomLocaions[4] = new int[] { -11, -2 };
            roomLocaions[5] = new int[] { -1, 2 };
            roomLocaions[6] = new int[] { -3, 6 };
            roomLocaions[7] = new int[] { 2, 7 };
            roomLocaions[8] = new int[] { 6, 6 };
        }

        //move functions:
        public void moveUp()
        {
            prevposition = position;
            position.y += 1;
            checkIfInRange(position);
            collectFire();
            collectfish();
            collectRod();
            isNearDog(position);
            isAtDog(position);
        }
        public void moveDown()
        {
            prevposition = position;
            position.y -= 1;
            checkIfInRange(position);
            collectFire();
            collectfish();
            collectRod();
            isNearDog(position);
            isAtDog(position);
        }
        public void moveLeft()
        {
            prevposition = position;
            position.x -= 1;
            checkIfInRange(position);
            collectFire();
            collectfish();
            collectRod();
            isNearDog(position);
            isAtDog(position);
        }
        public void moveRight()
        {
            prevposition = position;
            position.x += 1;
            checkIfInRange(position);
            collectFire();
            collectfish();
            collectRod();
            isAtCar();
            isNearDog(position);
            isAtDog(position);
        }

        //check if player is on fire location
        private void collectFire()
        {
            if(position == new Vector2(0, 0))
            {
                isCold = false;
                print("is warm");
            }
            if(position == new Vector2(0, 0) && !isCold)
            {
                backAtFire = true;
            }
            else
            {
                backAtFire = false;
            }
        }
        //return bool
        public bool getIfWarm()
        {
            return isCold;
        }
        public bool getIfAtFire()
        {
            return backAtFire;
        }

        //check if player is on rod location
        private void collectRod()
        {
            if (position == new Vector2(0, -9) && !isCold)
            {
                hasRod = true;
                print("has Rod");
            }
        }
        //return bool
        public bool getHasRod()
        {
            return hasRod;
        }

        //check if player is on fish location
        private void collectfish()
        {
            if (position == new Vector2(-10, 0))
            {
                hasfish = true;
            }
        }
        //return bool
        public bool getHasFish()
        {
            return hasfish;
        }

        //check if player has returned to car
        private void isAtCar()
        {
            if(position.x > 11)
            {
                isAtCarLoc = true;
            }
        }
        public bool getIsAtCar()
        {
            return isAtCarLoc;
        }



        public void getLocation()
        {
            print(position);
        }

        private void checkIfInRange(Vector2 p1Pos)
        {
            int counter = 0;


            //Feature point pt2 Using a list of arrays to check if in Boundrys
            //itterate thorugh all boundrys
            for (int i = 0; i < roomLocaions.Length; i+= 1)
            {
                //check if player x is within range of any boundrys
                if(p1Pos.x > roomLocaions[i][0] && p1Pos.x < roomLocaions[i][0] + roomDimentions[i][0])
                {
                    //check if player y is witin range of any boundrys
                    if(p1Pos.y > roomLocaions[i][1] && p1Pos.y < roomLocaions[i][1] + roomDimentions[i][1])
                    {
                        counter += 1;
                    }
                }
            }
            
            //check if counter was added to
            if(counter < 1)
            {
                //AudioSource bump = GameObject.Find("Bump").GetComponent<AudioSource>();
                //bump.play();
                //Atempted to create Audio to play when player is out of bounds
                position = prevposition;
            }
        }


        private void isNearDog(Vector2 loc)
        {
            Vector2 dog = new Vector2(-2, 10);
            float tempDist = Vector2.Distance(loc, dog);
            if(tempDist < 2)
            {
                isNearDanger = true;
            }
            else
            {
                isNearDanger = false;
            }
        }
        private void isAtDog(Vector2 loc)
        {
            Vector2 dog = new Vector2(-2, 10);
            if (dog == loc)
            {
                lostFish = true;
            }
        }

        public bool getLostFish()
        {
            return lostFish;
        }

        public bool getIsNearDog()
        {
            return isNearDanger;
        }

    }
}
