using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andre_BrandaoTeodoro_Sec003_Exercise02
{
    public partial class BaseballManipulation : Form
    {
        public BaseballManipulation()
        {
            InitializeComponent();
        }
        private BaseballDb.BaseballEntities dbContext = new BaseballDb.BaseballEntities();
        private void BaseballManipulation_Load(object sender, EventArgs e)
        {
            LoadDatabase();
        }
        private void LoadDatabase()
        {
            try
            {
                // fetch all players ordering by first, then last name
                dbContext.Players
                    .OrderBy(player => player.FirstName)
                    .ThenBy(player => player.LastName)
                    .Load();
                // display
                playersBindingSource.DataSource = dbContext.Players.Local;
                // moves to first position in the grid
                playersBindingSource.MoveFirst();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private void searchByIdButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(searchByIdTextBox.Text);
                if (searchByIdTextBox.Text != "")
                {
                    //define query for searchById
                    var byIdQuery =
                            from player in dbContext.Players
                            where player.PlayerID == id
                            orderby player.LastName, player.FirstName
                            select player;
                    // display
                    playersBindingSource.DataSource = byIdQuery.ToList();
                    // moves to first position in the grid
                    playersBindingSource.MoveFirst();
                }
                else
                {
                    throw new Exception("Please enter Id");
                };
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void showHighBattingAvgButton_Click(object sender, EventArgs e)
        {
            try
            {
                //define query for Highest Batting Average
                var highestBattingAvg =
                        from player in dbContext.Players
                        orderby player.BattingAverage descending
                        select new { player.LastName, player.FirstName, player.BattingAverage } ;
                // display
                playersBindingSource.DataSource = highestBattingAvg.First();
                MessageBox.Show($"{highestBattingAvg.First().FirstName} {highestBattingAvg.First().LastName} has the highest batting average","Highest Batting Average",MessageBoxButtons.OK,MessageBoxIcon.Information);
                // moves to first position in the grid
                playersBindingSource.MoveFirst();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
