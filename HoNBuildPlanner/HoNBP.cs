using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

namespace HoNBuildPlanner
{
    class HoNBP
    {
        static private Hashtable Heroes;
        static private mainWindow m_mainWindow;

        static private HeroBuild m_actualBuild;
        static private HeroBuild m_newBuild;


        static public void loadHeroesFromFile(string fileName)
        {
            Heroes = new Hashtable();
            Hero newHero;
            Skill[] heroSkills;
           
            string temp;
            string temp2;

            //Hero attributes:
            string heroName;
            string heroPortrait;
            
            HeroPrimaryAttr heroPrim;
            int heroInitialHP;
            int heroInitialMana;
            float heroInitialHPRegen;
            float heroInitialManaRegen;

            int heroIStr;
            int heroIAgi;
            int heroIInt;
            
            int heroMovS;
            float heroStrPerLevel;
            float heroAgiPerLevel;
            float heroIntPerLevel;

            float heroArmor;
            float heroMagicArmor;

            HeroAttackType heroAttackType;
            int heroMinDamage;
            int heroMaxDamage;
            int heroAttackRange;
            float heroBAT;            


            XmlReader reader = XmlReader.Create(fileName);

            reader.ReadStartElement("HoNBuildPlanner");

            while (reader.IsStartElement("Hero"))
            {
                heroSkills = new Skill[4];


                reader.ReadStartElement("Hero");


                reader.ReadStartElement("Name");
                heroName = reader.ReadString();
                reader.ReadEndElement();


                reader.ReadStartElement("PrimaryAttribute");
                temp = reader.ReadString();
                reader.ReadEndElement();

                switch (temp)
                {
                    case "Strength":
                        heroPrim = HeroPrimaryAttr.Strength;
                        break;
                    case "Agility":
                        heroPrim = HeroPrimaryAttr.Agility;
                        break;
                    case "Intelligence":
                        heroPrim = HeroPrimaryAttr.Intelligence;
                        break;
                    default:
                        heroPrim = HeroPrimaryAttr.Strength;
                        break;
                }




                reader.ReadStartElement("InitialHP");
                heroInitialHP = int.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("InitialHPRegen");
                heroInitialHPRegen = float.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("InitialMana");
                heroInitialMana = int.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("InitialManaRegen");
                heroInitialManaRegen = float.Parse(reader.ReadString());
                reader.ReadEndElement();




                reader.ReadStartElement("InitialAttirbutes");

                reader.ReadStartElement("Strength");
                heroIStr = int.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("Agility");
                heroIAgi = int.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("Intelligence");
                heroIInt = int.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadEndElement();



                reader.ReadStartElement("MovementSpeed");
                heroMovS = int.Parse(reader.ReadString());
                reader.ReadEndElement();



                reader.ReadStartElement("PerLevel");

                reader.ReadStartElement("Strength");
                heroStrPerLevel = float.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("Agility");
                heroAgiPerLevel = float.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadStartElement("Intelligence");
                heroIntPerLevel = float.Parse(reader.ReadString());
                reader.ReadEndElement();

                reader.ReadEndElement();


                reader.ReadStartElement("Armor");
                heroArmor = float.Parse(reader.ReadString());
                reader.ReadEndElement();


                reader.ReadStartElement("MagicArmor");
                heroMagicArmor = float.Parse(reader.ReadString());
                reader.ReadEndElement();


                reader.ReadStartElement("AttackType");
                temp = reader.ReadString();
                reader.ReadEndElement();

                switch (temp)
                {
                    case "Melee":
                        heroAttackType = HeroAttackType.Melee;
                        break;
                    case "Ranged":
                        heroAttackType = HeroAttackType.Ranged;
                        break;
                    default:
                        heroAttackType = HeroAttackType.Melee;
                        break;
                }



                reader.ReadStartElement("MinDamage");
                heroMinDamage = int.Parse(reader.ReadString());
                reader.ReadEndElement();


                reader.ReadStartElement("MaxDamage");
                heroMaxDamage = int.Parse(reader.ReadString());
                reader.ReadEndElement();


                reader.ReadStartElement("Range");
                heroAttackRange = int.Parse(reader.ReadString());
                reader.ReadEndElement();


                reader.ReadStartElement("BAT");
                heroBAT = float.Parse(reader.ReadString());
                reader.ReadEndElement();


                reader.ReadStartElement("Skills");

                for (int i = 0; i < 4; i++)
                {
                    reader.ReadStartElement("Skill");

                    reader.ReadStartElement("Name");
                    temp = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Lore");
                    temp2 = reader.ReadString();
                    reader.ReadEndElement();
                    heroSkills[i] = new Skill(temp, temp2);

                    reader.ReadStartElement("normalimage");
                    temp = reader.ReadString();
                    reader.ReadEndElement();

                    heroSkills[i].setImage(temp);

                    reader.ReadEndElement();
                }

                reader.ReadEndElement();

                reader.ReadStartElement("portrait");
                heroPortrait = reader.ReadString();
                reader.ReadEndElement();



                reader.ReadEndElement();

                newHero = new Hero(heroName, heroPrim, heroIStr, heroIAgi, heroIInt, heroInitialHP, heroInitialHPRegen,
                                    heroInitialMana, heroInitialManaRegen,  heroMovS, heroStrPerLevel, heroAgiPerLevel,
                                    heroIntPerLevel, heroArmor, heroMagicArmor, heroAttackType,
                                    heroMinDamage, heroMaxDamage, heroAttackRange, heroBAT,
                                    heroSkills[0], heroSkills[1], heroSkills[2], heroSkills[3]);

                newHero.Portrait(heroPortrait);

                Heroes.Add(heroName, newHero);
            }

            reader.ReadEndElement();

            return;

        }

        static public ArrayList listOfHeroes()
        {
            return new ArrayList(Heroes.Keys);
        }

        static public Hero getHeroByName(string heroName)
        {
            if (Heroes.ContainsKey(heroName))
            {
                return (Hero)Heroes[heroName];
            }
            else return null;
        }

        static public void setMainWindow(mainWindow win)
        {
            m_mainWindow = win;
        }
        static public mainWindow getMainWindow()
        {
            return m_mainWindow;
        }

        static public void NewBuild(HeroBuild newBuild)
        {
            m_newBuild = newBuild;
        }
        static public HeroBuild NewBuild()
        {
            return m_newBuild;
        }
        static public void ActualBuild(HeroBuild actualBuild)
        {
            m_actualBuild = actualBuild;
        }
        static public HeroBuild ActualBuild()
        {
            return m_actualBuild;
        }

        static public void LoadHeroFromFile(String filepath)
        {
        }

        static public void SaveHeroToFile(String filepath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            XmlWriter writer = XmlWriter.Create(filepath, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("HoNBuildPlanner");
            writer.WriteStartElement("Build");

            writer.WriteElementString("Name", m_actualBuild.BuildName());
            writer.WriteElementString("Hero", m_actualBuild.Name());

            writer.WriteStartElement("Choices");

            for (int i = 1; i <= 25; i++)
            {
                writer.WriteElementString("Level" + i, m_actualBuild.getChoiceType(i).ToString());
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.Flush();
            writer.Close();
        }
    }
}
