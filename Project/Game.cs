using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheCenter.Project
{
    public class Game : IGame
    {
        Warning countdown = new Warning(4);
        public Room CurrentRoom { get; set; }

        public Player CurrentPlayer { get; set; }

        Process myproc = new Process();

        public bool running = false;

        public void Setup()
        {
            Room EntranceTunnel = new Room("EntranceTunnel", "The door behind you slams shut as you hear the tumblers lock securely.\r\nYou don’t recall what just happened aside from bright lights and a \r\nloud humming in your ears.\r\n\r\nMatter of fact, you can’t even remember what you’re doing here.\r\n\r\nYou sense greater humidity in the air. You’re in a long hallway.\r\nThe hallway extends (N)orth for nearly 100’.\r\nYou see a heavy door at the end of the hallway.\r\n\r\nThere is nothing else of interest here.", false, new Item("", ""), false);

            Room AirlockTreatment = new Room("AirlockTreatment Room", "You enter this small room through a heavy door that looks to be built \r\nto maintain an air-tight seal. An audible warning starts beeping.\r\nOn the north side of the room is \r\nanother similar door. There are benches along the walls here. \r\n\r\nThere are small canvas bags on the wall near you that appear to be \r\ncarrying individual (mask)s of some sort. The door automatically closes \r\nbehind you and locks as before. A painful reminder of being trapped \r\nfills your mind. \r\n\r\nAn alarm pierces the veil of silence and spins you around as a \r\nflashing red light pierces your mind with painful intent. \r\n\r\nYou hear over the noise a countdown sequence. . .  \r\n60 seconds   59    58     57", true, new Item("", ""), true);

            Room FacilitiesRoom = new Room("Facilities Room", "You enter through the last airlock. The heavy door again shuts and locks \r\nbehind you with an evil intent. \r\n\r\nYou’re in a very large room. \r\n\r\nImagine a huge room with lockers and individual showers available. \r\nMust be some sort of changing room after the flea fog you just went \r\nthrough. . . or whatever it was. Fumigation? But against what? \r\n\r\nYou notice jumpsuits of different colors hanging in various racks with \r\ngeneric ID badges of some sort on them. Each one has a TLD. . . \r\n\r\nA Thermoluminescent Dosimeter. Great. Radiation monitoring . . . but what is the source of radiation though? And what do the colors mean? \r\n\r\nYou see (bluejumpsuit)s, (blackjumpsuit)s, (redjumpsuit)s and army (greenjumpsuit)s. \r\nThere are also a few sets of (whitejumpsuit)s, each have a white (wristband) \r\npinned to them in addition to the TLD and ID. \r\n\r\nYou see a hallway to the (N)orth.", false, new Item("", ""), false);

            Room CentralRoom = new Room("Central Room", "You enter what appears to be the world’s largest living room. \r\nLots of seating. \r\n\r\nPeople dressed in various jumpsuits are seated leisurely all around \r\nyou in couches, individual seats, chairs and small booths that \r\nappear to be setup for mini-conferencing. These booths have a type of \r\nshade or partition that can be used to obscure the meeting. Not bad. \r\nYou decide to sit in a comfortable, high-walled but seemingly normal \r\nbooth. Something catches your attention . . .  was it a sound, \r\na (flashlight), a (laptop), or a motion at the fancy booths to the north. . .\r\n\r\nWhile you take a moment to focus on the distraction you notice activity \r\nin one of the fancy booths on the north wall. One of the two people in the booth draw the shade and you see a shift \r\nin the lighting in that (booth). Odd. \r\n\r\nYou pay no attention per se until not a minute later you see the shade \r\nin that very booth being retracted automatically, only to reveal . . .  \r\n\r\nan empty booth! \r\n\r\nA quick mental check - YEP! there were people in that booth just a few \r\nmoments ago until . . .\r\n\r\nthey drew the partition down! \r\n\r\nOK. Officially weird. \r\n\r\nAs you take a seat, you watch those booths and sure enough, people that \r\ngo into the booths and draw the partition down disappear. \r\n\r\nYou also notice people do not use the booths otherwise. \r\n\r\nYou see a hallway to the (E)ast and of course the door you originally \r\ncame through from the (S)outh.", true, new Item("", ""), false);

            Room MedLabDoor = new Room("Central Room East Hallway", "You are at a frosted glass door, facing (E)ast, with the words “MedLab” \r\nin black etched into the glass. The door is locked but there is no \r\ndoorknob or keyhole. \r\n\r\nYou notice a very small pad on the wall on the side where you would \r\nexpect a doorknob.  Just then, a sliding wall extends behind you, \r\nblocking your ability to go back! \r\n\r\nYou're Trapped!\r\n", true, new Item("", ""), true);

            Room MedLab = new Room("MedLab", "You enter a well lit room obviously meant for medical needs. \r\nThere are cabinets and drawers, display cases and exam areas \r\nfor up to 4 patients. \r\n\r\nOne cabinet is marked with “Defibrillator” and you see other \r\npieces of equipment such as blood pressure bands, oxygen \r\nsystems with masks, (steth)oscopes, (clip)boards, resuscitation \r\nbag and mask, a small autoclave, a computer on a desk \r\nwith typical desk items around including an odd looking small \r\nplastic (card) next to the computer, a small water system \r\nwith small drink cups, refrigerator for medical use and the \r\nobligatory (glov)es, tongue (dep)ressors, sharps container etc. \r\n\r\nThere are no other exits other than the one you walked through \r\nfrom the (W)est.", false, new Item("", ""), false);

            AirlockTreatment.Items.Add(new Item("mask", "\r\nYou grab the closest canvas bag and pull the mask out…It’s a \r\ngas mask!!! You don the mask quickly, checking for a tight \r\nfit as you pull the straps to snug it up. The canisters are \r\nthankfully already in place and new . . . 15, 14, 13 the \r\ncountdown completes as you finish all of your checks. You \r\nthink . . . I hope these are the right filters just as you \r\nhear gas venting into the chamber. A cloud forms all around \r\nyou…but you’re breathing is fine albeit a bit labored from \r\nthe excitement. \r\n\r\nThe alarm ceases. Finally. \r\n\r\nThe gas has stopped and you hear another countdown start \r\nas the room seems to start clearing! 60 seconds. 59, 58 . . . \r\nA minute later the room is cleared. A voice gives you some \r\ninstructions to remove the mask and place it into the metal \r\nchute you see next to the north door. \r\n\r\nYou follow the instructions and head for the (N)orth door."));

            FacilitiesRoom.Items.Add(new Item("blackjumpsuit", "Ah yes, the feel of the ultimate in synthetic material! Once you've had black. . . "));
            FacilitiesRoom.Items.Add(new Item("whitejumpsuit", "Ah yes, the feel of the ultimate in synthetic material! I always looked great in white!"));
            FacilitiesRoom.Items.Add(new Item("greenjumpsuit", "Ah yes, the feel of the ultimate in synthetic material!\r\nGreen with envy."));
            FacilitiesRoom.Items.Add(new Item("bluejumpsuit", "Ah yes, the feel of the ultimate in synthetic material!\r\nA lovely shade really."));
            FacilitiesRoom.Items.Add(new Item("redjumpsuit", "Ah yes, the feel of the ultimate in synthetic material!\r\nI'm dangerous in Red!"));

            // FacilitiesRoom.Items.Add(new Item("mtools", "Maintenance Tools description stuff"));
            // FacilitiesRoom.Items.Add(new Item("ttools", "Tech Tools description stuff"));
            FacilitiesRoom.Items.Add(new Item("wristband", "You take the wristband out and swipe it across the pad. You hear a \r\ndigital voice say 'Confirmed' as the sound of mechanical interlocks \r\nshift, buzz and whirrrr.\r\n\r\nYou may now proceed (E)ast into the MedLab or go (W)est into\r\nthe Central Room."));

            CentralRoom.Items.Add(new Item("flashlight", "flashlight"));
            CentralRoom.Items.Add(new Item("laptop", "laptop"));

            CentralRoom.Items.Add(new Item("booth", "Oh boy are you in for a ride now!"));

            CentralRoom.NeededItems.Add(new Item("jumpsuit", "jumpsuits are a jumpin")); //any jumpsuit as a base
            CentralRoom.NeededItems.Add(new Item("card", "card")); //from Med Lab

            MedLabDoor.NeededItems.Add(new Item("wristband", "wristband")); //from FacilitiesRoom

            MedLab.Items.Add(new Item("glov", ""));
            MedLab.Items.Add(new Item("steth", ""));
            MedLab.Items.Add(new Item("dep", ""));
            MedLab.Items.Add(new Item("card", ""));
            MedLab.Items.Add(new Item("clip", ""));

            //establish rooms. Room has dictionary called Exits.
            EntranceTunnel.Exits.Add("n", AirlockTreatment);
            AirlockTreatment.Exits.Add("n", FacilitiesRoom);
            FacilitiesRoom.Exits.Add("n", CentralRoom);
            CentralRoom.Exits.Add("s", FacilitiesRoom);
            CentralRoom.Exits.Add("e", MedLabDoor);
            MedLabDoor.Exits.Add("e", MedLab);
            MedLabDoor.Exits.Add("w", CentralRoom);
            MedLab.Exits.Add("w", CentralRoom);
            myproc.StartInfo.FileName = @".\Project\Media\cmdmp3.exe";
            myproc.StartInfo.Arguments = @".\Project\Media\AWA.mp3";
            // myproc.Start();
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

        public bool UseItem(string itemName)
        {
            int index = -1;
            Item roomItem = null;

            if (itemName == "mask")
            {
                countdown.stop();
                //int timeElapsed = stopwatch.Elapsed.Seconds;
                int timeElapsed = countdown.GetSeconds();

                if (timeElapsed > 10)
                {
                    Console.Clear();
                    countdown.Countdown = 0;
                    countdown = new Warning(4);
                    YouDied();
                }
            }

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
                    for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)//loop through and see if anything matches
                    {
                        int tmp = CurrentPlayer.Inventory[i].Name.IndexOf(CurrentRoom.NeededItems[z].Name);

                        if (tmp > -1)
                        {
                            foundCount++;
                        }
                    }
                }
            }

            if (foundCount >= CurrentRoom.NeededItems.Count)
            {
                OK = true;
            }

            if (OK && indexInv != -1)
            {
                if (CurrentRoom.usedItems.Count > 0)
                {
                    if (!CurrentRoom.usedItems.Contains(InvItem.Name))
                    {
                        CurrentPlayer.IncreaseScore(CurrentPlayer.Inventory[indexInv].Name.Length);
                        CurrentRoom.usedItems.Add(InvItem.Name);
                        return CurrentRoom.UseItem(InvItem);
                    }
                }
                else
                {
                    return CurrentRoom.UseItem(InvItem);
                }
            }

            if (index > -1 && roomItem != null && OK == true)
            {
                if (itemName == "booth")
                { 
                    if (CurrentPlayer.Score >= 25)
                    {
                        CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);
                        CurrentRoom.UseItem(roomItem);
                        Console.Clear();
                        if (running)
                        {
                            myproc.Kill();
                            running = false;
                        }
                        Console.WriteLine("You've Won! This Level is COMPLETED.");
                        Console.WriteLine("Enjoy the ride down. The next level won't be so easy!");
                        Console.WriteLine("");

                        Console.WriteLine("Want to Play again? Y/N");
                        string action = Console.ReadLine().ToLower();

                        if (action.Contains("y"))
                        {
                            Restart();
                        }
                        else
                        {
                            Console.WriteLine("I'll take that as a 'NO'");
                            Quit();
                        }
                    }
                }
                else if (itemName == "wristband" && CurrentRoom.Name != "MedLabDoor")
                {
                    return false;
                }
                else
                {

                    if (CurrentRoom.usedItems.Count > 0)
                    {
                        if (!CurrentRoom.usedItems.Contains(CurrentRoom.Items[index].Name))
                        {

                            CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);

                            CurrentRoom.usedItems.Add(CurrentRoom.Items[index].Name);

                            return CurrentRoom.UseItem(CurrentRoom.Items[index]);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You've already used that item here. Nice try.");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);

                        CurrentRoom.usedItems.Add(CurrentRoom.Items[index].Name);
                        return CurrentRoom.UseItem(CurrentRoom.Items[index]);
                    }
                }
            }

            return false;
        }

        public void TakeItem(string itemName)
        {
            if (itemName == "booth")//hack for now. need to change booth to a room type
            {
                Console.WriteLine("Seriously!? \r\nYou notice people looking at you funny. . . \r\nLike. . . YOU LOST . . .and then. . . ");

                Console.WriteLine("");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadKey();

                Restart();
                Item fakeitem = null;
                CurrentPlayer.AddItem(fakeitem);
            }

            int index = -1; //0
            Item myitem = null;

            for (int x = 0; x < CurrentRoom.Items.Count; x++)
            {
                if (CurrentRoom.Items[x].Name == itemName)
                {
                    index = x;
                    myitem = CurrentRoom.Items[x];
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("");
                Console.WriteLine($"Take what {itemName}?");
                Console.WriteLine("");
                return;
            }

            if (CurrentPlayer.AddItem(CurrentRoom.Items[index]))
            {
                CurrentPlayer.IncreaseScore(CurrentRoom.Items[index].Name.Length);

                //check for unique items and remove.
                if (CurrentRoom.Name == "Central Room" && CurrentRoom.Description.Contains(CurrentRoom.Items[index].Name))
                {
                    string tmp = CurrentRoom.Description.Replace("a (" + CurrentRoom.Items[index].Name + "), ", "");
                    CurrentRoom.Description = tmp;
                }

                if (CurrentRoom.Name == "Central Room" && CurrentRoom.Items.Contains(CurrentRoom.Items[index]))
                {
                    CurrentRoom.Items.RemoveAt(index);

                    //redraw description
                    DisplayRoom();
                }
            }
        }

        public void Play()
        {
            bool GameContinue = true;

            while (GameContinue)
            {
                Console.Clear();
                //Console.Beep(); //Where the Beep is that!? ;)
                Console.WriteLine("");
                ylw();
                Console.WriteLine($"You are in the {CurrentRoom.Name}");
                grn();
                Console.WriteLine("");

                //It would be here that I need to check for Special Operations Etc
                CurrentRoom.processDesc(CurrentRoom.Description);

                if (CurrentRoom.Name == "AirlockTreatment Room")
                {
                    countdown.start();
                    countdown.warningBeep();
                }

                if (CurrentRoom.Name == "Central Room")
                {
                    countdown.stop();
                    if (!running)
                    {
                        myproc.Start();
                        running = true;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("");

                bool repeatQuestion = true;

                while (repeatQuestion)
                {
                    ylw();
                    Console.WriteLine("");
                    Console.Write("What would you like to do?: ");
                    grn();
                    string action = Console.ReadLine().ToLower();

                    if (action.StartsWith("t ") || action.StartsWith("u ") || action.StartsWith("i") || action.StartsWith("d") || action.StartsWith("?")) //dr is for drop
                    {
                        int index = action.IndexOf(" ");
                        string actualItem = action.Substring(index + 1);

                        if (action.StartsWith("u "))
                        {
                            //works nicely as a trap
                            if (CurrentRoom.Locked == true)
                            {
                                //maybe add timer here for 30 seconds
                                CurrentRoom.Locked = !UseItem(actualItem);
                            }
                            else
                            {
                                UseItem(actualItem);
                            }
                        }
                        else if (action.StartsWith("t "))
                        {
                            TakeItem(actualItem);
                        }
                        else if (action.StartsWith("i"))//inventory & score
                        {
                            ShowInventory();
                        }
                        else if (action.StartsWith("?") || action.StartsWith("d"))//Show Description - ???????  or d
                        {
                            DisplayRoom();
                        }

                        repeatQuestion = true;
                    }
                    else if (action == "n" || action == "s" || action == "e" || action == "w" || action.StartsWith("dwn") || action.StartsWith("up"))
                    {
                        if (CurrentRoom.Locked == false && CurrentRoom.Exits.ContainsKey(action))
                        {
                            Go(action);
                            repeatQuestion = false;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("That is not possible right now.");
                            Console.WriteLine("");
                            repeatQuestion = true;
                        }
                    }
                    else if (action == "quit" || action == "restart" || action == "help")
                    {
                        if (action == "quit")
                        {
                            Quit();
                        }

                        if (action == "restart")
                        {
                            Restart();
                        }

                        if (action == "help")
                        {
                            Help();
                        }
                    }
                    else
                    {
                        repeatQuestion = true;
                    }
                }
            }
        }

        public void DisplayRoom()
        {
            Console.Clear();
            Console.WriteLine("");
            ylw();
            Console.WriteLine($"You are in the {CurrentRoom.Name}");
            grn();
            Console.WriteLine("");

            CurrentRoom.processDesc(CurrentRoom.Description);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Every Room description has highlighted words and letters.\r\nEach signify an actionable item.\r\nSome items can be put in your inventory \r\nby using 't ' followed by the item name as highlighted.\r\nSome items can be used locally using 'u ' followed by the \r\nitem name as highlighted.\r\n\r\nKeywords available are: 'help' 'quit' 'restart' \r\n\r\nYou can also use '?' or 'd' to show the room description again. \r\n\r\nAlso available for use is 'i' which shows your inventory \r\nand current score. \r\n\r\nGood Luck!");
        }

        public void ShowInventory()
        {
            Console.WriteLine();

            if (CurrentPlayer.Inventory.Count > 0)
            {
                Console.WriteLine("You have the following items:");

                for (int s = 0; s < CurrentPlayer.Inventory.Count; s++)
                {
                    Console.WriteLine("{0,2}--{1,2}", null, CurrentPlayer.Inventory[s].Name);
                }
            }
            else
            {
                Console.WriteLine("You currently have no items in your inventory.");
            }

            Console.WriteLine();
            Console.WriteLine($"Your current score is: {CurrentPlayer.Score}");
            Console.WriteLine();
        }

        public void Quit()
        {
            if (running)
            {
                myproc.Kill();
                running = false;
            }
            Console.Clear();
            Environment.Exit(0);
        }

        public void YouDied()
        {
            Console.Clear();

            if (running)
            {
                myproc.Kill();
                running = false;
            }

            if (CurrentRoom.Name == "AirlockTreatment Room")
            {
                Console.WriteLine(". . . you realize it takes some time to properly put on a gas mask.\r\n\r\n");
            }

            Console.WriteLine("The good news . . .\r\nyou don't have to worry about anything . . .EVER.\r\nThe bad news is . . . \r\n\r\nYOU DIED!\r\n\r\nPress Enter...");
            string res = Console.ReadLine();
            Console.Clear();
            Restart();
        }

        public void Restart()
        {
            if (running)
            {
                myproc.Kill();
                running = false;
            }

            Console.Clear();
            CurrentPlayer.Inventory.Clear();
            CurrentPlayer.Score = 0;
            Setup();
            Play();
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
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}