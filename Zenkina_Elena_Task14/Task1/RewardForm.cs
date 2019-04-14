using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class RewardForm : Form
    {
        public bool createNewReward = true;
        public Reward reward;
        public int maxID;

        public RewardForm()
        {
            InitializeComponent();
        }

        private void RewardForm_Load(object sender, EventArgs e)
        {
            if (createNewReward)
            {
                Text = "Новая награда";
            }
            else
            {
                Text = "Редактирование данных о награде";
                tbxTitle.Text = reward.Title;
                tbxDescription.Text = reward.Description;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ctlErrorProvider.Clear();
            try
            {
                if (createNewReward)
                {
                    reward = new Reward(maxID + 1, tbxTitle.Text, tbxDescription.Text);
                }
                else
                {
                    reward.Title = tbxTitle.Text;
                    reward.Description = tbxDescription.Text;
                }
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentOutOfRangeException error)
            {
                switch (error.ParamName)
                {
                    case "Title":
                        ctlErrorProvider.SetError(tbxTitle, error.Message);
                        break;
                    case "Description":
                        ctlErrorProvider.SetError(tbxDescription, error.Message);
                        break;
                    default:
                        break;
                }
                DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
