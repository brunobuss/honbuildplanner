using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoNBuildPlanner
{
    class Skill
    {
        private string m_Name;
        private string m_Lore;

        private string m_imageFileName = "";

        public Skill(string Name, string Lore)
        {
            m_Name = Name;
            m_Lore = Lore;
        }

        public string Name()
        {
            return m_Name;
        }
        public string Lore()
        {
            return m_Lore;
        }

        public void setImage(string imageFileName)
        {
            m_imageFileName = imageFileName;
        }
        public string getImage()
        {
            return m_imageFileName + ".jpeg";
        }
        public string getGrayedOutImage()
        {
            return m_imageFileName + "_g.jpeg";
        }
    }
}
