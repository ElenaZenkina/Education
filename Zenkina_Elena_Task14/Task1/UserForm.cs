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
        private readonly bool createNewUser = true;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public List<Reward> RewardsList { get; set; }
        public List<Reward> listAllRewards;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(User user):this()
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;
            Age = user.Age;
            RewardsList = user.RewardsList;

            createNewUser = false;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (createNewUser)
            {
                Text = "Новый пользователь";
                // Список всех наград (их наименования)
                clbxReward.Items.AddRange(listAllRewards.Select(r => r.Title).ToArray());
            }
            else
            {
                Text = "Редактирование данных о пользователе";
                tbxUserFirstName.Text = FirstName;
                tbxUserLastName.Text = LastName;
                dtBirthDate.Value = Birthdate;
                tbxUserAge.Text = Age.ToString();

                // Список всех наград. Награды пользователя помечены "галочкой"
                for (int i = 0; i < listAllRewards.Count; i++)
                {
                    clbxReward.Items.Add(listAllRewards[i].Title);
                    if (RewardsList.Where(r => r.ID == listAllRewards[i].ID).Count() != 0)
                    {
                        clbxReward.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ctlErrorProvider.Clear();
            if (ValidateChildren())
            {
                RewardUser();
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void RewardUser()
        {
            RewardsList = new List<Reward>();
            foreach (var newReward in clbxReward.CheckedItems)
            {
                RewardsList.Add(listAllRewards.First(r => r.Title == newReward.ToString()));
            }
        }

        private void tbxUserFirstName_Validating(object sender, CancelEventArgs e)
        {
            string name = (sender as TextBox).Text.Trim();

            if (name.Length == 0 || name.Length > 50)
            {
                ctlErrorProvider.SetError((sender as TextBox), "Значение должно содержать от 1 до 50 символов.");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void tbxUserFirstName_Validated(object sender, EventArgs e)
        {
            FirstName = tbxUserFirstName.Text.Trim();
        }

        private void tbxUserLastName_Validated(object sender, EventArgs e)
        {
            LastName = tbxUserLastName.Text.Trim();
        }

        private void dtBirthDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Now.AddYears(-150) > dtBirthDate.Value || dtBirthDate.Value > DateTime.Now)
            {
                ctlErrorProvider.SetError((sender as DateTimePicker), $"Дата рождения должна быть в диапазоне от {DateTime.Now.AddYears(-150)} до {DateTime.Now}.");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void dtBirthDate_Validated(object sender, EventArgs e)
        {
            Birthdate = dtBirthDate.Value;
        }
    }
}
