using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Player
    {
        public string Name { get; set; } // the name of the player
        public Bitmap ProfilePicture { get; set; } // the player's profile picture

        public Player()
        {
            
        }

        public Player(string name, Bitmap profilePicture)
        {
            Name = name;
            ProfilePicture = profilePicture;
        }
    }
}
