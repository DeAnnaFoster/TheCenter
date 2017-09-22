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
            Room EntranceTunnel = new Room("EntranceTunnel", "The door behind you slams shut as you hear the tumblers lock securely. You don’t recall what just happened aside from bright lights and a loud humming in your ears. Matter of fact. You can’t even remember what you’re doing here.You sense an elevation of humidity in the air. You’re in a long hallway. The hallway extends north for nearly 100’. You see a heavy door at the end of the hallway. There is nothing else of interest here.");

            Room AirlockTreatment = new Room("AirlockTreatment", "You enter a small room through a heavy door that looks to be built for an air-tight seal. On the north side of the room is another similar door. There are benches along the walls here. There are small canvas bags on the wall near you that appear to be carrying individual masks of some sort. The door automatically closes behind you and locks as before. An alarm pierces the veil of silence and spins you around as a flashing red light is triggered. You hear over the noise a countdown sequence… 60 seconds remaining.");

            Room Facilities = new Room("Facilities", "You enter through the last airlock. As normal the heavy door shuts and locks behind you without any help from you. You’re in a larger room. A bit bigger than the last but with lockers and individual showers available. Must be some sort of changing room after the flea fog you just went through…or whatever it was. Fumigation? But against what? You notice coveralls of different colors hanging in various racks with generic badges of some sort on them. Each one also has a TLD. A Thermoluminescent Dosimeter. Great. Radiation monitoring. But what do the colors mean? You see blue, black, red and army green coveralls. You see a hallway to the north.");

            Room CentralRoom = new Room("CentralRoom", "You enter what appears to be the world’s largest living room. Lots of seating. People dressed in various overalls are seated leisurely all around you in couches, individual seats, chairs and small booths that appear to be setup for mini-conferencing with a type of drawn shade or partition that can be used to obscure the meeting. Not bad. As you take a moment to observe your surroundings you notice activity in a booth. One of the two people draw the shade and for a moment you see a shift in the lighting in that booth. Odd. You pay no attention per se until not a minute later you see the shade in that very booth being retracted automatically revealing an empty booth! A quick mental check verifies there were people in that booth a moment ago… until they drew the partition down. OK. Officially weird. As you take a seat you watch those booths and sure enough, people that go into the booths and draw the partition down disappear. You also notice people do not use the booths otherwise. You see a hallway to the east.");

            Room MedLab = new Room("MedLab", "You enter a well lit room obviously meant for medical needs. There are cabinets and drawers, display cases and exam areas for up to 4 patients. One cabinet is marked with “Defibrillator” and you see other pieces of equipment such as blood pressure bands, oxygen systems with masks, stethoscopes, clipboards, resuscitation bag and mask, a small autoclave, a computer, small water system, refrigerator for medical use of course and the obligatory gloves, tongue depressors, sharps container and so on. There are no other exits other than the one you walked through from the west.");

            //establish rooms. Room has dictionary called Exits.
            EntranceTunnel.Exits.Add("n", AirlockTreatment);
            AirlockTreatment.Exits.Add("n", Facilities);
            Facilities.Exits.Add("n", CentralRoom);
            CentralRoom.Exits.Add("e", MedLab);
            MedLab.Exits.Add("w", CentralRoom);

            AirlockTreatment.Items.Add(new Item("Mask", "Old and stinky gas mask in a canvas bag. Crude but usable."));

            Facilities.Items.Add(new Item("Black Coveralls", "Black Coveralls"));
            Facilities.Items.Add(new Item("Green Coveralls", "Green Coveralls"));
            Facilities.Items.Add(new Item("Blue Coveralls", "Blue Coveralls"));
            Facilities.Items.Add(new Item("Red Coveralls", "Red Coveralls"));
            Facilities.Items.Add(new Item("M Tools", "Maintenance Tools"));
            Facilities.Items.Add(new Item("T Tools", "Tech Tools"));

            CentralRoom.Items.Add(new Item("Flashlight", "Flashlight"));
            CentralRoom.Items.Add(new Item("Laptop", "Laptop"));

            MedLab.Items.Add(new Item("gloves", "gloves"));
            MedLab.Items.Add(new Item("stethoscope", "stethoscope"));
            MedLab.Items.Add(new Item("tongue depressors", "tongue depressors"));
            
            CurrentRoom = EntranceTunnel;
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
            for(int x = 0; x < CurrentRoom.Items.Count; x++)
            {
                if(CurrentRoom.Items[0].Name == itemName)
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
    }
}