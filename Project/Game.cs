using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TheCenter.Project
{
    public class Game : IGame
    {


        public Room CurrentRoom { get; set; }

        public Player CurrentPlayer { get; set; }

        public void Setup()
        {


            //Public CurrentRoom;
            //build rooms
            Room EntranceTunnel = new Room("EntranceTunnel", "The door behind you slams shut as you hear the tumblers lock securely.\r\nYou don’t recall what just happened aside from bright lights and a \r\nloud humming in your ears.\r\n\r\nMatter of fact, you can’t even remember what you’re doing here.\r\n\r\nYou sense greater humidity in the air. You’re in a long hallway.\r\nThe hallway extends (N)orth for nearly 100’.\r\nYou see a heavy door at the end of the hallway.\r\n\r\nThere is nothing else of interest here.", false, new Item("", ""), false);

            Room AirlockTreatment = new Room("AirlockTreatment Room", "You enter this small room through a heavy door that looks to be built \r\nto maintain an air-tight seal. On the north side of the room is \r\nanother similar door. There are benches along the walls here. \r\n\r\nThere are small canvas bags on the wall near you that appear to be \r\ncarrying individual (mask)s of some sort. The door automatically closes \r\nbehind you and locks as before. A painful reminder of being trapped \r\nfills your mind. \r\n\r\nAn alarm pierces the veil of silence and spins you around as a \r\nflashing red light pierces your mind with painful intent. \r\n\r\nYou hear over the noise a countdown sequence. . .  \r\n60 seconds   59    58     57", true, new Item("mask", "mask description here"), true);

            Room FacilitiesRoom = new Room("Facilities Room", "You enter through the last airlock. The heavy door again shuts and locks \r\nbehind you with an evil intent. \r\n\r\nYou’re in a very large room. \r\n\r\nImagine a huge room with lockers and individual showers available. \r\nMust be some sort of changing room after the flea fog you just went \r\nthrough. . . or whatever it was. Fumigation? But against what? \r\n\r\nYou notice jumpsuits of different colors hanging in various racks with \r\ngeneric ID badges of some sort on them. Each one has a TLD. . . \r\n\r\nA Thermoluminescent Dosimeter. Great. Radiation monitoring . . . but what is the source of radiation though? And what do the colors mean? \r\n\r\nYou see (bluejumpsuit)s, (blackjumpsuit)s, (redjumpsuit)s and army (greenjumpsuit)s. \r\nThere are also two sets of (whitejumpsuit)s, each have a white (wristband) \r\npinned to them in addition to the TLD and ID. \r\n\r\nYou see a hallway to the (N)orth.", false, new Item("", ""), false);

            Room CentralRoom = new Room("Central Room", "You enter what appears to be the world’s largest living room. \r\nLots of seating. \r\n\r\nPeople dressed in various jumpsuits are seated leisurely all around \r\nyou in couches, individual seats, chairs and small booths that \r\nappear to be setup for mini-conferencing. These booths have a type of \r\n shade or partition that can be used to obscure the meeting. Not bad. \r\n\r\nAs you take a moment to observe your surroundings you notice activity \r\nin a booth. One of the two people draw the shade and you see a shift \r\nin the lighting in that (booth). Odd. \r\n\r\nYou pay no attention per se until not a minute later you see the shade \r\nin that very booth being retracted automatically, only to reveal . . .  \r\n\r\nan empty booth! \r\n\r\nA quick mental check - YEP! there were people in that booth just a few \r\nmoments ago until . . .\r\n\r\nthey drew the partition down! \r\n\r\nOK. Officially weird. \r\n\r\nAs you take a seat, you watch those booths and sure enough, people that \r\ngo into the booths and draw the partition down disappear. \r\n\r\nYou also notice people do not use the booths otherwise. \r\n\r\nYou notice where you're sitting has a (flashlight) and a (laptop) on the \r\nother seat opposite you. \r\n\r\nYou see a hallway to the (E)ast and of course the door you originally \r\ncame through from the (S)outh.", true, new Item("", ""), false);

            Room MedLabDoor = new Room("Central Room East Hallway", "You are at a frosted glass door, facing (E)ast, with the words “MedLab” \r\nin black etched into the glass. The door is locked but there is no \r\ndoorknob or keyhole. \r\n\r\nYou notice a very small pad on the wall on the side where you would \r\nexpect a doorknob.  Just then, a sliding wall extends behind you, \r\nblocking your ability to go back! \r\n\r\nYou're Trapped!\r\n", true, new Item("wristband", "wristband description here"), true);  //or continue (E)ast into the MedLab  //You can go back (W)est to the Central Room 

            Room MedLab = new Room("MedLab", "You enter a well lit room obviously meant for medical needs. \r\nThere are cabinets and drawers, display cases and exam areas \r\nfor up to 4 patients. \r\n\r\nOne cabinet is marked with “Defibrillator” and you see other \r\npieces of equipment such as blood pressure bands, oxygen \r\nsystems with masks, (steth)oscopes, (clip)boards, resuscitation \r\nbag and mask, a small autoclave, a computer on a desk \r\nwith typical desk items around including an odd looking small \r\nplastic (card) next to the computer, a small water system \r\nwith small drink cups, refrigerator for medical use and the \r\nobligatory (glov)es, tongue (dep)ressors, sharps container etc. \r\n\r\nThere are no other exits other than the one you walked through \r\nfrom the (W)est.", false, new Item("", ""), false);

            AirlockTreatment.Items.Add(new Item("mask", "\r\nYou grab the closest canvas bag and pull the mask out…It’s a \r\ngas mask!!! You don the mask quickly, checking for a tight \r\nfit as you pull the straps to snug it up. The canisters are \r\nthankfully already in place and new . . . 15, 14, 13 the \r\ncountdown completes as you finish all of your checks. You \r\nthink . . . I hope these are the right filters just as you \r\nhear gas venting into the chamber. A cloud forms all around \r\nyou…but you’re breathing is fine albeit a bit labored from \r\nthe excitement. \r\n\r\nThe alarm ceases. Finally. \r\n\r\nThe gas has stopped and you hear another countdown start \r\nas the room seems to start clearing! 60 seconds. 59, 58 . . . \r\nA minute later the room is cleared. A voice gives you some \r\ninstructions to remove the mask and place it into the metal \r\nchute you see next to the north door. \r\n\r\nYou follow the instructions and head for the (N)orth door."));

            FacilitiesRoom.Items.Add(new Item("blackjumpsuit", "black jumpsuits description stuff"));
            FacilitiesRoom.Items.Add(new Item("whitejumpsuit", "white jumpsuits description stuff"));
            FacilitiesRoom.Items.Add(new Item("greenjumpsuit", "green jumpsuits description stuff"));
            FacilitiesRoom.Items.Add(new Item("bluejumpsuit", "blue jumpsuits description stuff"));
            FacilitiesRoom.Items.Add(new Item("redjumpsuit", "red jumpsuits description stuff"));

            FacilitiesRoom.Items.Add(new Item("mtools", "Maintenance Tools description stuff"));
            FacilitiesRoom.Items.Add(new Item("ttools", "Tech Tools description stuff"));
            FacilitiesRoom.Items.Add(new Item("wristband", "wristband description stuff"));

            CentralRoom.Items.Add(new Item("flashlight", "flashlight"));
            CentralRoom.Items.Add(new Item("laptop", "laptop"));
            CentralRoom.Items.Add(new Item("booth", "Oh boy are you in for a ride now!"));

            CentralRoom.NeededItems.Add(new Item("jumpsuit", "jumpsuits are a jumpin")); //any jumpsuit as a base
            CentralRoom.NeededItems.Add(new Item("card", "card")); //from Med Lab
            
            MedLabDoor.NeededItems.Add(new Item("wristband", "wristband")); //from FacilitiesRoom

            MedLab.Items.Add(new Item("glov", "gloves"));
            MedLab.Items.Add(new Item("steth", "stethoscope"));
            MedLab.Items.Add(new Item("dep", "tongue depressors"));
            MedLab.Items.Add(new Item("card", "card"));
            MedLab.Items.Add(new Item("clip", "clip"));

            //establish rooms. Room has dictionary called Exits.
            EntranceTunnel.Exits.Add("n", AirlockTreatment);
            AirlockTreatment.Exits.Add("n", FacilitiesRoom);
            FacilitiesRoom.Exits.Add("n", CentralRoom);
            CentralRoom.Exits.Add("s", FacilitiesRoom);
            CentralRoom.Exits.Add("e", MedLabDoor);
            MedLabDoor.Exits.Add("e", MedLab);
            MedLabDoor.Exits.Add("w", CentralRoom);
            MedLab.Exits.Add("w", CentralRoom);

            Process myproc = new Process();
            myproc.StartInfo.FileName = @".\Project\Media\cmdmp3.exe";
            myproc.StartInfo.Arguments = @".\Project\Media\Songbird.mp3";
            //myproc.Start();

            CurrentRoom = EntranceTunnel;
            CurrentPlayer = new Project.Player();
        }

        public void Go(string direction)
        {
            //had this checking for special true which kep you from getting into the room
            if (CurrentRoom.Exits[direction].Locked != true)//CurrentRoom.Special != true && 
            {
                CurrentRoom = CurrentRoom.Exits[direction];
            }
            else
            {


                CurrentRoom = CurrentRoom.Exits[direction];
            }
        }

        public void Reset()
        {
            //call Setup? 
        }

        public bool UseItem(string itemName)
        {
            //first two statements (for & if) are to make sure item is either ininventory or in room

            int index = -1;
            Item roomItem = null;

            //See if current room has item
            for (int x = 0; x < CurrentRoom.Items.Count; x++)
            {
                if (CurrentRoom.Items[x].Name == itemName)
                {
                    roomItem = CurrentRoom.Items[x];
                    index = x;
                }
            }

            Item InvItem = null;

            //check if player has it in inventory
            int indexInv = -1;

            if (index == -1 && CurrentPlayer.Inventory.Count > 1)
            {
                for (int y = 0; y < CurrentPlayer.Inventory.Count; y++)
                {
                    if (CurrentPlayer.Inventory[y].Name == itemName)
                    {
                        InvItem = CurrentPlayer.Inventory[y];
                        indexInv = y;
                    }
                }
            }





            bool OK = false;
            int foundCount = 0;

            if (CurrentRoom.NeededItems.Count > 0)
            {
                //loop through needed items and check to see if Player has these items
                for (int z = 0; z < CurrentRoom.NeededItems.Count; z++)
                {
                    for(int i = 0; i < CurrentPlayer.Inventory.Count;i++)//loop through and see if anything matches
                    {
                        int tmp = CurrentPlayer.Inventory[i].Name.IndexOf(CurrentRoom.NeededItems[z].Name);

                        if(tmp >-1)
                        {
                            foundCount++;
                        }
                    }
                }
            }




            if(foundCount >=  CurrentRoom.NeededItems.Count)
            {
                OK = true;
            }
           
            if(OK && indexInv != -1)
            {
                CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);
                return CurrentRoom.UseItem(InvItem);
            }

            if(index > -1 && roomItem != null && OK == true)
            {
                //roomItem
                CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);
                return CurrentRoom.UseItem(roomItem);
            }

            return false;
        }

        public void TakeItem(string itemName)
        {
            int index = 0;

            for (int x = 0; x < CurrentRoom.Items.Count; x++)
            {
                if (CurrentRoom.Items[x].Name == itemName)
                {
                    index = x;
                }
            }

            if (CurrentPlayer.AddItem(CurrentRoom.Items[index]))
            {
                CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);

                // Console.WriteLine($"Your item scored upon is {CurrentRoom.Items[index].Name}");
                // Console.WriteLine($"Your score now has increased by {CurrentRoom.Items[index].Name.Length} points");
                // Console.WriteLine($"Your score now is {CurrentPlayer.Score}");
            }

        }

        public void Play()
        {
            //Probably move Program stuff here!
        }

        public void blu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

        }

        public void grn()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void ylw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void gry()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        public void ShowNameDesc()
        {
            Console.Clear();

            Console.WriteLine("");
            ylw();
            Console.WriteLine($"You are in the {CurrentRoom.Name}");
            grn();
            Console.WriteLine("");






            //It would be here that I need to check for Special Operations Etc
            //CurrentRoom.processDesc(description);

            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}