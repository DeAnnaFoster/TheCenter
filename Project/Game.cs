using System;
using System.Collections.Generic;

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
            Room EntranceTunnel = new Room("EntranceTunnel", "The door behind you slams shut as you hear the tumblers lock securely.\r\nYou don’t recall what just happened aside from bright lights and a \r\nloud humming in your ears.\r\n\r\nMatter of fact. You can’t even remember what you’re doing here.\r\n\r\nYou sense greater humidity in the air. You’re in a long hallway.\r\nThe hallway extends (N)orth for nearly 100’.\r\nYou see a heavy door at the end of the hallway.\r\n\r\nThere is nothing else of interest here.", false);

            Room AirlockTreatment = new Room("AirlockTreatment Room", "You enter a small room through a heavy door that looks to be built \r\nto maintain an air-tight seal. On the north side of the room is \r\nanother similar door. There are benches along the walls here. \r\n\r\nThere are small canvas bags on the wall near you that appear to be \r\ncarrying individual (mask)s of some sort. The door automatically closes \r\nbehind you and locks as before. A painful reminder of being trapped \r\nfills your mind. \r\n\r\nAn alarm pierces the veil of silence and spins you around as a \r\nflashing red light pierces your mind with painful intent. \r\n\r\nYou hear over the noise a countdown sequence. . .  \r\n60 seconds   59    58     57", false);

            Room FacilitiesRoom = new Room("Facilities Room", "You enter through the last airlock. The heavy door again shuts and locks \r\nbehind you with an evil intent. \r\n\r\nYou’re in a very large room. \r\n\r\nImagine a huge locker room with lockers and individual showers available. \r\nMust be some sort of changing room after the flea fog you just went \r\nthrough. . . or whatever it was. Fumigation? But against what? \r\n\r\nYou notice coveralls of different colors hanging in various racks with \r\ngeneric badges of some sort on them. Each one has a TLD. . . \r\n\r\nA Thermoluminescent Dosimeter. Great. Radiation monitoring badges. . .what is the source of radiation though? And what do the colors mean? \r\n\r\nYou see (blue) coveralls, (black), (red) and army (green) coveralls. \r\nThere are also two sets of (white) coveralls that have a white (band) pinned \r\nto them in addition to the TLD and (badge). \r\n\r\nYou see a hallway to the (N)orth.", false);

            Room CentralRoom = new Room("Central Room", "You enter what appears to be the world’s largest living room. \r\nLots of seating. \r\n\r\nPeople dressed in various overalls are seated leisurely all around \r\nyou in couches, individual seats, chairs and small booths that \r\nappear to be setup for mini-conferencing. These booths have a type of \r\n shade or partition that can be used to obscure the meeting. Not bad. \r\n\r\nAs you take a moment to observe your surroundings you notice activity \r\nin a booth. One of the two people draw the shade and you see a shift \r\nin the lighting in that (booth). Odd. \r\n\r\nYou pay no attention per se until not a minute later you see the shade in that very booth being retracted automatically only to reveal . . .  \r\n\r\nan empty booth! \r\n\r\nA quick mental check verifies there were people in that booth a moment ago\r\n\r\n. . . until. . .  \r\n\r\nthey drew the partition down. OK. Officially weird. \r\n\r\nAs you take a seat, you watch those booths and sure enough, people that \r\ngo into the booths and draw the partition down disappear. \r\n\r\nYou also notice people do not use the booths otherwise. \r\n\r\nYou see a hallway to the (E)ast and of course the door you originally \r\ncame through from the (S)outh.", true);

            Room MedLabDoor = new Room("Central Room East Hallway", "You are at a frosted glass door, facing (E)ast, with the words “MedLab” \r\nin black etched into the glass. The door is locked but there is no \r\ndoorknob or keyhole. \r\n\r\nYou notice a very small pad on the wall on the side where you would \r\nexpect a doorknob.  \r\n\r\nYou can go back (W)est to the Central Room ", true);  //or continue (E)ast into the MedLab

            Room MedLab = new Room("MedLab", "You enter a well lit room obviously meant for medical needs. \r\nThere are cabinets and drawers, display cases and exam areas \r\nfor up to 4 patients. \r\n\r\nOne cabinet is marked with “Defibrillator” and you see other \r\npieces of equipment such as blood pressure bands, oxygen \r\nsystems with masks, (steth)oscopes, (clip)boards, resuscitation \r\nbag and mask, a small autoclave, a computer on a desk \r\nwith typical desk items around including an odd looking small \r\nplastic (card) next to the computer, a small water system \r\nwith small drink cups, refrigerator for medical use and the \r\nobligatory (glov)es, tongue (dep)ressors, sharps container etc. \r\n\r\nThere are no other exits other than the one you walked through \r\nfrom the (W)est.", false);



            //establish rooms. Room has dictionary called Exits.
            EntranceTunnel.Exits.Add("n", AirlockTreatment);
            AirlockTreatment.Exits.Add("n", FacilitiesRoom);
            FacilitiesRoom.Exits.Add("n", CentralRoom);
            CentralRoom.Exits.Add("s", FacilitiesRoom);
            CentralRoom.Exits.Add("e", MedLabDoor);
            MedLabDoor.Exits.Add("e", MedLab);
            MedLabDoor.Exits.Add("w", CentralRoom);
            MedLab.Exits.Add("w", CentralRoom);

            AirlockTreatment.Items.Add(new Item("Mask", "Old and stinky gas mask in a canvas bag. Crude but usable."));

            FacilitiesRoom.Items.Add(new Item("Black Coveralls", "Black Coveralls"));
            FacilitiesRoom.Items.Add(new Item("White Coveralls", "White Coveralls"));
            FacilitiesRoom.Items.Add(new Item("Green Coveralls", "Green Coveralls"));
            FacilitiesRoom.Items.Add(new Item("Blue Coveralls", "Blue Coveralls"));
            FacilitiesRoom.Items.Add(new Item("Red Coveralls", "Red Coveralls"));
            FacilitiesRoom.Items.Add(new Item("M Tools", "Maintenance Tools"));
            FacilitiesRoom.Items.Add(new Item("T Tools", "Tech Tools"));
            FacilitiesRoom.Items.Add(new Item("Wristband", "Wristband"));

            CentralRoom.Items.Add(new Item("Flashlight", "Flashlight"));
            CentralRoom.Items.Add(new Item("Laptop", "Laptop"));
            CentralRoom.NeededItems.Add(new Item("Blue Coveralls", "Blue Coveralls")); //any coveralls as a base
            CentralRoom.NeededItems.Add(new Item("Optical Card", "Card")); //from Med Lab

            MedLabDoor.NeededItems.Add(new Item("Wristband", "Wristband"));

            MedLab.Items.Add(new Item("gloves", "gloves"));
            MedLab.Items.Add(new Item("stethoscope", "stethoscope"));
            MedLab.Items.Add(new Item("tongue depressors", "tongue depressors"));
            MedLab.Items.Add(new Item("card", "card"));

            CurrentRoom = EntranceTunnel;

            CurrentPlayer = new Project.Player();
        }

        public void Go(string direction)
        {
            CurrentRoom = CurrentRoom.Exits[direction];
        }

        public void Reset()
        {
            //call Setup? 
        }

        public void UseItem(string itemName)
        {
            int index = 0;
            for (int x = 0; x < CurrentRoom.Items.Count; x++)
            {
                if (CurrentRoom.Items[0].Name == itemName)
                {
                    index = x;
                }
            }

            //int ind = CurrentRoom.Items.IndexOf(itemName);
            Item itm = CurrentRoom.Items[index];
            //Item newItem = CurrentRoom.Items[itemName];
            CurrentRoom.UseItem(itm);
        }

        public void Play()
        {

        }

        public void blu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

        }

        public void grn()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void gry()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void processDesc(string desc)
        {
            foreach (char ch in desc)
            {
                if (ch == '(')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                if (ch == ')')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    continue;
                }

                Console.Write(ch);
            }
        }
    }
}