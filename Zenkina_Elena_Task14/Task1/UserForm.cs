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
            }
            else
            {
                Text = "Редактирование данных о пользователе";
                tbxUserFirstName.Text = user.FirstName;
                tbxUserLastName.Text = user.LastName;
                dtBirthDate.Value = user.Birthdate;
                tbxUserAge.Text = user.Age.ToString();
                if (user.RewardsList.Count != 0)
                {
                    foreach (var reward in user.RewardsList)
                    {
                        lbxRewardList.Items.Add(reward.Title);
                    }
                }

                bool a = listAllRewards.SequenceEqual(user.RewardsList);
                if (listAllRewards.Count > user.RewardsList.Count)
                {


                    /*foreach (var item in list1)
                    {
                        if (list2.Where(c => c.vopros == item.vopros).Count() == 0)
                        {
                            list3.Add(item);
                        }
                    }*/



                    //if ()
                    bool b = listAllRewards.SequenceEqual(user.RewardsList);
                }
                //cbxAddReward.Items.Add();
                //lbxRewardList.DataSource = user.RewardsList.ToList();
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
                }
                else
                {
                    user.FirstName = tbxUserFirstName.Text;
                    user.LastName = tbxUserLastName.Text;
                    user.Birthdate = dtBirthDate.Value;
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

    }
}
