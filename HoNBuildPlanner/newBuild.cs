using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HoNBuildPlanner
{
    public partial class newBuild : Form
    {
        Hero selectedHero = null;
        bool b_flag = false;

        public newBuild()
        {
            InitializeComponent();
            ArrayList heroesList = HoNBP.listOfHeroes();
            heroesList.Sort();

            tbox_buildname.Text = "My New Build";

            cbox_heroes.Items.AddRange(heroesList.ToArray());
            cbox_heroes.SelectedIndex = 0;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (tbox_buildname.Text == "")
            {
                MessageBox.Show("Please entar a build name.", "Ooops!");
                return;
            }

            HeroBuild newBuild = new HeroBuild(tbox_buildname.Text, selectedHero);

            HoNBP.NewBuild(newBuild);
            b_flag = true;
            this.Close();
        }

        private void cbox_heroes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string heroName = cbox_heroes.Items[cbox_heroes.SelectedIndex].ToString();

            selectedHero = HoNBP.getHeroByName(heroName);

            if (selectedHero != null)
            {
                pbox_hero.Load(selectedHero.Portrait());
            }
        }

        private void newBuild_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(b_flag == false) HoNBP.NewBuild(null);
        }

    }
}
