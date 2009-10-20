using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HoNBuildPlanner
{
    public partial class mainWindow : Form
    {

        public mainWindow()
        {
            InitializeComponent();
            HoNBP.loadHeroesFromFile("heroes.xml");
            this.pn_heroInfo.Visible = false;

            pbox_attrboost.Load("./imgs/other/attrboost.png");
        }

        private void mi_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mi_NewBuild_Click(object sender, EventArgs e)
        {
            newBuild newBuildWindow = new newBuild();

            newBuildWindow.ShowDialog();

            if (HoNBP.NewBuild() == null) return;

            //TODO: Save old build.
            this.pn_heroInfo.Visible = true;
            startNewBuild();
        }

        private void startNewBuild()
        {
            HoNBP.ActualBuild(HoNBP.NewBuild());

            HeroBuild build = HoNBP.ActualBuild();
            this.Text = "HoN Build Planner: " + build.BuildName();

            build.LevelUp();
            startHeroInfo();
            updateAllHero();
            changeBuildLevel(1);
            lbox_choices.SelectedIndex = 0;
            


        }

        private void updateAllHero()
        {
            updateAttributes();
            updateDetailedAttributes();
            updateDefenseInformation();
            updateBaseAttack();
            updateItems();
            updateLevelUp();
        }

        private void startHeroInfo()
        {
            HeroBuild build = HoNBP.ActualBuild();
            lb_HeroName.Text = build.Name();
            lb_PrimaryAttr.Text = build.PrimaryAttribute();

            pbox_hero.Load(build.Portrait());
        }
        private void updateAttributes()
        {
            HeroBuild build = HoNBP.ActualBuild();
            lb_AttrStr.Text = build.Strength().ToString();
            lb_AttrAgi.Text = build.Agility().ToString();
            lb_AttrInt.Text = build.Intelligence().ToString();
            lb_HP.Text = build.HP().ToString();
            lb_Mana.Text = build.Mana().ToString();
        }
        private void updateDetailedAttributes()
        {
            HeroBuild build = HoNBP.ActualBuild();
            lb_StrPerlLevel.Text = build.StrengthPerLevel().ToString();
            lb_AgiPerLevel.Text = build.AgilityPerLevel().ToString();
            lb_IntPerlLevel.Text = build.IntelligencePerLevel().ToString();
            lb_MovSpeed.Text = build.MovementSpeed().ToString();
        }
        private void updateDefenseInformation()
        {
            HeroBuild build = HoNBP.ActualBuild();
            lb_Armor.Text = build.Armor().ToString();
            lb_DmgReduction.Text = ((float)(build.DamageReduction() * 100)).ToString() + "%";
            lb_MagicArmor.Text = build.MagicArmor().ToString();
            lb_MagicDmgReduction.Text = ((float)(build.MagicDamageReduction() * 100)).ToString() + "%";
        }
        private void updateBaseAttack()
        {
            HeroBuild build = HoNBP.ActualBuild();
            lb_AttackType.Text = build.AttackType();
            lb_Damage.Text = build.MinDamage() + " - " + build.MaxDamage();
            lb_Range.Text = build.AttackRange().ToString();
            lb_AttacksSec.Text = build.AttackSpeed().ToString();
        }
        private void updateItems()
        {
        }
        private void updateLevelUp()
        {
            HeroBuild build = HoNBP.ActualBuild();

            lbox_choices.Items.Clear();
            for (int i = 1; i <= build.MaxLevel(); i++)
            {
                lbox_choices.Items.Add(build.Choice(i));
            }

            if (build.getChoiceType(build.Level()) == LevelChoice.Nothing)
            {
                if (build.CanChooseSkill(LevelChoice.Skill1)) turnonSkill1();
                else turnoffSkill1();

                if (build.CanChooseSkill(LevelChoice.Skill2)) turnonSkill2();
                else turnoffSkill2();

                if (build.CanChooseSkill(LevelChoice.Skill3)) turnonSkill3();
                else turnoffSkill3();

                if (build.CanChooseSkill(LevelChoice.SkillUltimate)) turnonSkillUlt();
                else turnoffSkillUlt();

                if (build.CanChooseSkill(LevelChoice.AttributeBooster)) turnonAttrBoost();
                else turnoffAttrBoost();
            }
            else
            {
                turnoffAttrBoost();
                turnoffSkill1();
                turnoffSkill2();
                turnoffSkill3();
                turnoffSkillUlt();

                switch (build.getChoiceType(build.Level()))
                {
                    case LevelChoice.Skill1:
                        turnonSkill1();
                        break;
                    case LevelChoice.Skill2:
                        turnonSkill2();
                        break;
                    case LevelChoice.Skill3:
                        turnonSkill3();
                        break;
                    case LevelChoice.SkillUltimate:
                        turnonSkillUlt();
                        break;
                    case LevelChoice.AttributeBooster:
                        turnonAttrBoost();
                        break;
                }
            }

            lbox_choices.SelectedIndex = build.Level() - 1;
        }

        private void changeBuildLevel(int level)
        {
            HeroBuild build = HoNBP.ActualBuild();

            if (level == build.Level()) return;

            if (level == 26) level = 25;
            lb_CurrentLevel.Text = level.ToString();
            build.Level(level);


            updateAllHero();
        }
        private void buildLevelUp(LevelChoice c)
        {
            HeroBuild build = HoNBP.ActualBuild();

            build.Choice(build.Level(), c);
            if (build.Level() == build.MaxLevel())
            {
                build.LevelUp();
                changeBuildLevel(build.Level() + 1);
            }
            else
            {
                updateAllHero();
            }

        }
        private bool isActualChoice(LevelChoice c)
        {
            HeroBuild build = HoNBP.ActualBuild();

            if (build.getChoiceType(build.Level()) == c) return true;
            else return false;
        }
        private void removeChoice()
        {
            HeroBuild build = HoNBP.ActualBuild();

            build.removeChoice(build.Level());
            updateAllHero();
        }
        private void removeAllChoices()
        {
            HeroBuild build = HoNBP.ActualBuild();

            for (int i = 1; i <= build.MaxLevel(); i++) build.removeChoice(i);
            updateAllHero();
        }

        private void turnonSkill1()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill1.Load(build.SkillImage(1));
            pbox_skill1.Enabled = true;
        }
        private void turnoffSkill1()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill1.Load(build.SkillGreyedImage(1));
            pbox_skill1.Enabled = false;
        }
        private void turnonSkill2()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill2.Load(build.SkillImage(2));
            pbox_skill2.Enabled = true;
        }
        private void turnoffSkill2()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill2.Load(build.SkillGreyedImage(2));
            pbox_skill2.Enabled = false;
        }
        private void turnonSkill3()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill3.Load(build.SkillImage(3));
            pbox_skill3.Enabled = true;
        }
        private void turnoffSkill3()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill3.Load(build.SkillGreyedImage(3));
            pbox_skill3.Enabled = false;
        }
        private void turnonSkillUlt()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill4.Load(build.SkillImage(4));
            pbox_skill4.Enabled = true;
        }
        private void turnoffSkillUlt()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_skill4.Load(build.SkillGreyedImage(4));
            pbox_skill4.Enabled = false;
        }
        private void turnonAttrBoost()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_attrboost.Load("./imgs/other/attrboost.png");
            pbox_attrboost.Enabled = true;
        }
        private void turnoffAttrBoost()
        {
            HeroBuild build = HoNBP.ActualBuild();
            pbox_attrboost.Load("./imgs/other/attrboost_g.png");
            pbox_attrboost.Enabled = false;
        }

        private void lbox_choices_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeBuildLevel(lbox_choices.SelectedIndex + 1);
        }

        private void pbox_skill1_Click(object sender, EventArgs e)
        {
            if (isActualChoice(LevelChoice.Skill1))
            {
                removeChoice();
            }
            else
            {
                buildLevelUp(LevelChoice.Skill1);
            }
        }
        private void pbox_skill2_Click(object sender, EventArgs e)
        {
            if (isActualChoice(LevelChoice.Skill2))
            {
                removeChoice();
            }
            else
            {
                buildLevelUp(LevelChoice.Skill2);
            }
        }
        private void pbox_skill3_Click(object sender, EventArgs e)
        {
            if (isActualChoice(LevelChoice.Skill3))
            {
                removeChoice();
            }
            else
            {
                buildLevelUp(LevelChoice.Skill3);
            }
        }
        private void pbox_skill4_Click(object sender, EventArgs e)
        {
            if (isActualChoice(LevelChoice.SkillUltimate))
            {
                removeChoice();
            }
            else
            {
                buildLevelUp(LevelChoice.SkillUltimate);
            }
        }
        private void pbox_attrboost_Click(object sender, EventArgs e)
        {
            if (isActualChoice(LevelChoice.AttributeBooster))
            {
                removeChoice();
            }
            else
            {
                buildLevelUp(LevelChoice.AttributeBooster);
            }
        }

        private void btn_resetAll_Click(object sender, EventArgs e)
        {
            removeAllChoices();
        }
    }
}
