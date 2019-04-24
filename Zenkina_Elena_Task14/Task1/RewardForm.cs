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
        private readonly bool createNewReward = true;

        public string Title { get; private set; }
        public string Description { get; private set; }

        public RewardForm()
        {
            InitializeComponent();
        }

        public RewardForm(Reward reward): this ()
        {
            Title = reward.Title;
            Description = reward.Description;
            createNewReward = false;
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
                tbxTitle.Text = Title;
                tbxDescription.Text = Description;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ctlErrorProvider.Clear();
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbxTitle_Validating(object sender, CancelEventArgs e)
        {
            string title = tbxTitle.Text.Trim();

            if (title.Length == 0 || title.Length > 50)
            {
                ctlErrorProvider.SetError(tbxTitle, "Наименование должно содержать от 1 до 50 символов.");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void tbxTitle_Validated(object sender, EventArgs e)
        {
            Title = tbxTitle.Text.Trim();
        }

        private void tbxDescription_Validating(object sender, CancelEventArgs e)
        {
            string description = tbxDescription.Text.Trim();

            if (description.Length > 250)
            {
                ctlErrorProvider.SetError(tbxDescription, "Описание должно содержать не более 250 символов.");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void tbxDescription_Validated(object sender, EventArgs e)
        {
            Description = tbxDescription.Text.Trim();
        }
    }
}
