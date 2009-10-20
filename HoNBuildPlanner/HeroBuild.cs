using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoNBuildPlanner
{
    class HeroBuild
    {
        private string m_BuildName;
        private Hero m_Hero;
        private LevelChoice[] m_Choices = new LevelChoice[26];
        private int m_curLevel = 0;
        private int m_maxLevel = 0;

        public HeroBuild(string BuildName, Hero Hero)
        {
            m_BuildName = BuildName;
            m_Hero = Hero;

            for (int i = 0; i < 26; i++) m_Choices[i] = LevelChoice.Nothing;
        }

        public string BuildName()
        {
            return m_BuildName;
        }

        public string Name()
        {
            return m_Hero.Name();
        }

        public string PrimaryAttribute()
        {
            return m_Hero.PrimaryAttribute();
        }
        public int Strength()
        {
            int attrboost = 0;

            for (int i = 0; i < m_curLevel; i++)
            {
                if (m_Choices[i] == LevelChoice.AttributeBooster) attrboost += 2;
            }

            return m_Hero.InitialStrength() + (int)((m_curLevel - 1) * StrengthPerLevel()) + attrboost;
        }
        public int Agility()
        {
            int attrboost = 0;

            for (int i = 0; i < m_curLevel; i++)
            {
                if (m_Choices[i] == LevelChoice.AttributeBooster) attrboost += 2;
            }

            return m_Hero.InitialAgility() + (int)((m_curLevel - 1) * AgilityPerLevel()) + attrboost;
        }
        public int Intelligence()
        {
            int attrboost = 0;

            for (int i = 0; i < m_curLevel; i++)
            {
                if (m_Choices[i] == LevelChoice.AttributeBooster) attrboost += 2;
            }

            return m_Hero.InitialIntelligence() + (int)((m_curLevel - 1) * IntelligencePerLevel()) + attrboost;
        }
        public float Strengthf()
        {
            int attrboost = 0;

            for (int i = 0; i < m_curLevel; i++)
            {
                if (m_Choices[i] == LevelChoice.AttributeBooster) attrboost += 2;
            }

            return m_Hero.InitialStrength() + ((m_curLevel - 1) * StrengthPerLevel()) + attrboost;
        }
        public float Agilityf()
        {
            int attrboost = 0;

            for (int i = 0; i < m_curLevel; i++)
            {
                if (m_Choices[i] == LevelChoice.AttributeBooster) attrboost += 2;
            }

            return m_Hero.InitialAgility() + ((m_curLevel - 1) * AgilityPerLevel()) + attrboost;
        }
        public float Intelligencef()
        {
            int attrboost = 0;

            for (int i = 0; i < m_curLevel; i++)
            {
                if (m_Choices[i] == LevelChoice.AttributeBooster) attrboost += 2;
            }

            return m_Hero.InitialIntelligence() + ((m_curLevel - 1) * IntelligencePerLevel()) + attrboost;
        }

        public int MovementSpeed()
        {
            return m_Hero.MovementSpeed();
        }
        public float StrengthPerLevel()
        {
            return m_Hero.StrengthPerLevel();
        }
        public float AgilityPerLevel()
        {
            return m_Hero.AgilityPerLevel();
        }
        public float IntelligencePerLevel()
        {
            return m_Hero.IntelligencePerLevel();
        }

        public float Armor()
        {
            return m_Hero.Armor() + Agility() * 0.14f;
        }
        public float DamageReduction()
        {
            //http://forums.heroesofnewerth.com/showthread.php?t=12545&highlight=Damage+Reduction
            //0.06*Armor/(1+0.06*Armor)
            return ((float)((int)(((0.06f * Armor()) / (1.0f + 0.06f * Armor())) * 1000))) / 1000.0f;
        }
        public float MagicArmor()
        {
            return m_Hero.MagicArmor();
        }
        public float MagicDamageReduction()
        {
            //http://forums.heroesofnewerth.com/showthread.php?t=12545&highlight=Damage+Reduction
            //0.06*Armor/(1+0.06*Armor)
            return (float)((int)(((0.06f * MagicArmor()) / (1.0f + 0.06f * MagicArmor()))*1000))/1000.0f;
        }

        public string AttackType()
        {
            return m_Hero.AttackType();
        }
        public int MinDamage()
        {
            switch (PrimaryAttribute())
            {
                case "Strength":
                    return m_Hero.MinDamage() + Strength();
                case "Agility":
                    return m_Hero.MinDamage() + Agility();
                case "Intelligence":
                    return m_Hero.MinDamage() + Intelligence();
            }

            return 0;
        }
        public int MaxDamage()
        {
            switch (PrimaryAttribute())
            {
                case "Strength":
                    return m_Hero.MaxDamage() + Strength();
                case "Agility":
                    return m_Hero.MaxDamage() + Agility();
                case "Intelligence":
                    return m_Hero.MaxDamage() + Intelligence();
            }

            return 0;
        }
        public int AttackRange()
        {
            return m_Hero.AttackRange();
        }
        public float AttackSpeed()
        {
            //http://dotatips.tipsabc.com/126/section-Dota/How-does-IAS-work.aspx/96
            //AttackSpeed = (1 + IAS)/BAT. BAT is 1.7 in almost heroes.
            return (float)((int)(((1.0f + IAS()) / m_Hero.BAT())*1000))/1000.00f;
        }

        public string Portrait()
        {
            return m_Hero.Portrait();
        }

        public void Level(int level)
        {
            m_curLevel = level;
        }
        public int Level()
        {
            return m_curLevel;
        }

        public int HP()
        {
            return m_Hero.InitialHP() + Strength() * 19;
        }
        public int Mana()
        {
            return m_Hero.InitialMana() + Intelligence() * 13;
        }
        public float HPRegen()
        {
            return 0.0f;
        }
        public float ManaRegen()
        {
            return 0.0f;
        }

        public string Choice(int level)
        {
            if (level < 1 || level > 25) return "UNDEF";

            switch (m_Choices[level-1])
            {
                case (LevelChoice.Nothing):
                    return "Level " + level + ": NOT SELECTED";
                case (LevelChoice.Skill1):
                    return "Level " + level + ": " + m_Hero.Skill(1).Name();
                case (LevelChoice.Skill2):
                    return "Level " + level + ": " + m_Hero.Skill(2).Name();
                case (LevelChoice.Skill3):
                    return "Level " + level + ": " + m_Hero.Skill(3).Name();
                case (LevelChoice.SkillUltimate):
                    return "Level " + level + ": " + m_Hero.Skill(4).Name();
                case (LevelChoice.AttributeBooster):
                    return "Level " + level + ": Attribute Booster";
            }

            return "UNDEF";
        }
        public void Choice(int level, LevelChoice c)
        {
            if (level < 1 || level > 25 || !CanChooseSkill(c)) return;
            m_Choices[level - 1] = c;
        }
        public void removeChoice(int level)
        {
            if (level < 1 || level > 25) return;
            m_Choices[level - 1] = LevelChoice.Nothing;
        }
        public LevelChoice getChoiceType(int level)
        {
            if (level < 1 || level > 25) return LevelChoice.Nothing;

            return m_Choices[level - 1];
        }

        public string SkillImage(int skillid)
        {
            if (skillid < 1 || skillid > 4) return "";

            return "./imgs/skills/" + m_Hero.Skill(skillid).getImage();
        }
        public string SkillGreyedImage(int skillid)
        {
            if (skillid < 1 || skillid > 4) return "";

            return "./imgs/skills/" + m_Hero.Skill(skillid).getGrayedOutImage();
        }

        public bool CanChooseSkill(LevelChoice c)
        {
            int count = 0;
            for (int i = 0; i < m_maxLevel; i++)
            {
                if (m_Choices[i] == c) count++;
            }

            if (c == LevelChoice.AttributeBooster && count < 10) return true;
            else if (c == LevelChoice.AttributeBooster && count >= 10) return false;

            if ((c == LevelChoice.Skill1 || c == LevelChoice.Skill2 || c == LevelChoice.Skill3) &&
               (count == 0 || (count == 1 && m_curLevel >= 3) || (count == 2 && m_curLevel >= 5) || (count == 3 && m_curLevel >= 7)))
                return true;
            else if (c == LevelChoice.SkillUltimate &&
                ((count == 0 && m_curLevel >= 6) || (count == 1 && m_curLevel >= 11) || (count == 2 && m_curLevel >= 16)))
                return true;

            return false;

        }

        public void LevelUp()
        {
            m_maxLevel++;
            if (m_maxLevel > 25) m_maxLevel = 25;
        }
        public int MaxLevel()
        {
            return m_maxLevel;
        }

        private float IAS()
        {
            return Agility() * 0.01f;
        }
    }
}
