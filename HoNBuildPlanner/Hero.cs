using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoNBuildPlanner
{


    class Hero
    {
        private string m_Name;

        private HeroPrimaryAttr m_PrimaryAttr;
        private int m_InitialHP;
        private float m_InitialHPRegen;
        private int m_InitialMana;
        private float m_InitialManaRegen;

        private int m_InitialStr;
        private int m_InitialAgi;
        private int m_InitialInt;

        private int m_MovementSpeed;
        private float m_StrPerLevel;
        private float m_AgiPerLevel;
        private float m_IntPerLevel;

        private float m_Armor;
        private float m_MagicArmor;

        private HeroAttackType m_AttackType;
        private int m_MinDamage;
        private int m_MaxDamage;
        private int m_AttackRange;
        private float m_BAT;

        private Skill[] m_Skills = new Skill[4];
        private string m_PortraitFileName = "";

        //Mass constructor =]
        public Hero(string Name, HeroPrimaryAttr PrimaryAttr, int InitialStr, int InitialAgi, int InitialInt,
                    int InitialHP, float InitialHPRegen, int InitialMana, float InitialManaRegen,
                    int MovementSpeed, float StrPerLevel, float AgiPerLevel, float IntPerLevel,
                    float Armor, float MagicArmor, HeroAttackType AttackType, int MinDamage, int MaxDamage,
                    int AttackRange, float BAT, Skill FirstSkill, Skill SecondSkill, Skill ThirdSkill, Skill UltimateSkill)
        {
            m_Name = Name;
            
            m_PrimaryAttr = PrimaryAttr;
            m_InitialHP = InitialHP;
            m_InitialHPRegen = InitialHPRegen;
            m_InitialMana = InitialMana;
            m_InitialManaRegen = InitialManaRegen;

            m_InitialStr = InitialStr;
            m_InitialAgi = InitialAgi;
            m_InitialInt = InitialInt;

            m_MovementSpeed = MovementSpeed;
            m_StrPerLevel = StrPerLevel;
            m_AgiPerLevel = AgiPerLevel;
            m_IntPerLevel = IntPerLevel;

            m_Armor = Armor;
            m_MagicArmor = MagicArmor;

            m_AttackType = AttackType;
            m_MinDamage = MinDamage;
            m_MaxDamage = MaxDamage;
            m_AttackRange = AttackRange;
            m_BAT = BAT;

            m_Skills[0] = FirstSkill;
            m_Skills[1] = SecondSkill;
            m_Skills[2] = ThirdSkill;
            m_Skills[3] = UltimateSkill;
        }


        public string Name()
        {
            return m_Name;
        }

        public string PrimaryAttribute()
        {
            switch (m_PrimaryAttr)
            {
                case HeroPrimaryAttr.Strength:
                    return "Strength";
                case HeroPrimaryAttr.Agility:
                    return "Agility";
                case HeroPrimaryAttr.Intelligence:
                    return "Intelligence";
            }

            return "UNDEF";
        }
        public int InitialStrength()
        {
            return m_InitialStr;
        }
        public int InitialAgility()
        {
            return m_InitialAgi;
        }
        public int InitialIntelligence()
        {
            return m_InitialInt;
        }

        public int MovementSpeed()
        {
            return m_MovementSpeed;
        }
        public float StrengthPerLevel()
        {
            return m_StrPerLevel;
        }
        public float AgilityPerLevel()
        {
            return m_AgiPerLevel;
        }
        public float IntelligencePerLevel()
        {
            return m_IntPerLevel;
        }

        public float Armor()
        {
            return m_Armor;
        }
        public float MagicArmor()
        {
            return m_MagicArmor;
        }

        public string AttackType()
        {
            switch (m_AttackType)
            {
                case HeroAttackType.Melee:
                    return "Melee";
                case HeroAttackType.Ranged:
                    return "Ranged";
            }

            return "UNDEF";
        }
        public int MinDamage()
        {
            return m_MinDamage;
        }
        public int MaxDamage()
        {
            return m_MaxDamage;
        }
        public int AttackRange()
        {
            return m_AttackRange;
        }
        public float BAT()
        {
            return m_BAT;
        }

        public void Portrait(string imageFileName)
        {
            m_PortraitFileName = imageFileName;
        }
        public string Portrait()
        {
            return "./imgs/heroes/" + m_PortraitFileName + ".jpeg";
        }

        public Skill Skill(int number)
        {
            if (number < 1 || number > 4) return null;
            return m_Skills[number-1];
        }

        public int InitialHP()
        {
            return m_InitialHP;
        }
        public float InitialHPRegen()
        {
            return m_InitialHPRegen;
        }
        public int InitialMana()
        {
            return m_InitialMana;
        }
        public float InitialManaRegen()
        {
            return m_InitialManaRegen;
        }
    }
}
