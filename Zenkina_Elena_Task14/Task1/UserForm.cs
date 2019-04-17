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
    public partial class UserForm : Form
    {
        public bool createNewUser = true;
        public BindingList<Reward> listAllRewards;
        public User user;
        public int maxID;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (createNewUser)
            {
                Text = "Новый пользователь";
                // Список всех доступных наград
                cbxAddReward.Items.AddRange(listAllRewards.Select(r => r.Title).ToArray());
            }
            else
            {
                Text = "Редактирование данных о пользователе";
                tbxUserFirstName.Text = user.FirstName;
                tbxUserLastName.Text = user.LastName;
                dtBirthDate.Value = user.Birthdate;
                tbxUserAge.Text = user.Age.ToString();

                // Список наград пользователя
                lbxRewardList.DataSource = user.RewardsList;
                lbxRewardList.DisplayMember = "Title";
                lbxRewardList.ValueMember = "Id";

                // Список наград, которых нет у пользователя
                foreach (var reward in listAllRewards)
                {
                    if (user.RewardsList.Where(r => r.ID == reward.ID).Count() == 0)
                    {
                        cbxAddReward.Items.Add(reward.Title);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ctlErrorProvider.Clear();
            try
            {
                if (createNewUser)
                {
                    user = new User(maxID + 1, tbxUserFirstName.Text, tbxUserLastName.Text, dtBirthDate.Value);
                    RewardUser();
                }
                else
                {
                    user.FirstName = tbxUserFirstName.Text;
                    user.LastName = tbxUserLastName.Text;
                    user.Birthdate = dtBirthDate.Value;
                    RewardUser();
                }
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentOutOfRangeException error)
            {
                switch (error.ParamName)
                {
                    case "FirstName":
                        ctlErrorProvider.SetError(tbxUserFirstName, error.Message);
                        break;
                    case "LastName":
                        ctlErrorProvider.SetError(tbxUserLastName, error.Message);
                        break;
                    case "Birthdate":
                        ctlErrorProvider.SetError(dtBirthDate, error.Message);
                        break;
                    default:
                        break;
                }
                DialogResult = DialogResult.None;
            }
            /*if (this.ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void RewardUser()
        {
            var newReward = cbxAddReward.SelectedItem;
            if (newReward != null)
            {
                user.RewardsList.Add(listAllRewards.First(r => r.Title == newReward.ToString()));
            }
            //var b = newReward ?? user.RewardsList.Find(r => r.Title == newReward.ToString());
        }

    }
}
