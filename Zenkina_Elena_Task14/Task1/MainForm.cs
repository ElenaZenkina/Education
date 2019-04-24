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
    public partial class MainForm : Form
    {
        enum SortOrder { Asceding, Desceding };
        SortOrder[] userSortOrder = new SortOrder[6];
        SortOrder[] rewardSortOrder = new SortOrder[3];

        private BindingList<User> userList = new BindingList<User>();
        private BindingList<Reward> rewardList = new BindingList<Reward>();

        public MainForm()
        {
            InitializeComponent();
            userList.Add(new User(1, "Иван", "Иванов", new DateTime(2000, 7, 12)));
            userList.Add(new User(2, "Петр", "Петров", new DateTime(2001, 4, 28), new List<Reward> { new Reward(1, "Нобелевская премия")}));
            userList.Add(new User(3, "Василий", "Сидоров", new DateTime(2002, 10, 2)));
            userList.Add(new User(4, "Павел", "Васильев", new DateTime(2003, 11, 1), new List<Reward> { new Reward(1, "Нобелевская премия"), new Reward(2, "Шнобелевская премия") }));
            userList.Add(new User(5, "Иван", "Павлов", new DateTime(2004, 1, 12), new List<Reward> { new Reward(1, "Нобелевская премия"), new Reward(2, "Шнобелевская премия"), new Reward(3, "премия Дарвина") }));
            ctlUserGrid.DataSource = userList;
            ctlUserGrid.Columns[1].HeaderText = "Имя";
            ctlUserGrid.Columns[2].HeaderText = "Фамилия";
            ctlUserGrid.Columns[3].HeaderText = "Дата рождения";
            ctlUserGrid.Columns[4].HeaderText = "Возраст";
            ctlUserGrid.Columns[5].HeaderText = "Список наград";

            rewardList.Add(new Reward(1, "Нобелевская премия"));
            rewardList.Add(new Reward(2, "Шнобелевская премия", "Полностью бесполезная фигня"));
            rewardList.Add(new Reward(3, "премия Дарвина"));
            ctlRewardGrid.DataSource = rewardList;
            ctlRewardGrid.Columns[1].HeaderText = "Наименование";
            ctlRewardGrid.Columns[2].HeaderText = "Описание";
            
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctlUserGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null) { return; }

            if (grid.DataSource == userList)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (userSortOrder[0] == SortOrder.Asceding)
                        {
                            userList = new BindingList<User>(userList.OrderByDescending(u => u.ID).ToList());
                            userSortOrder[0] = SortOrder.Desceding;
                        }
                        else
                        {
                            userList = new BindingList<User>(userList.OrderBy(u => u.ID).ToList());
                            userSortOrder[0] = SortOrder.Asceding;
                        }
                        break;
                    case 1:
                        if (userSortOrder[1] == SortOrder.Asceding)
                        {
                            userList = new BindingList<User>(userList.OrderByDescending(u => u.FirstName).ToList());
                            userSortOrder[1] = SortOrder.Desceding;
                        }
                        else
                        {
                            userList = new BindingList<User>(userList.OrderBy(u => u.FirstName).ToList());
                            userSortOrder[1] = SortOrder.Asceding;
                        }
                        break;
                    case 2:
                        if (userSortOrder[2] == SortOrder.Asceding)
                        {
                            userList = new BindingList<User>(userList.OrderByDescending(u => u.LastName).ToList());
                            userSortOrder[2] = SortOrder.Desceding;
                        }
                        else
                        {
                            userList = new BindingList<User>(userList.OrderBy(u => u.LastName).ToList());
                            userSortOrder[2] = SortOrder.Asceding;
                        }
                        break;
                    case 3:
                        if (userSortOrder[3] == SortOrder.Asceding)
                        {
                            userList = new BindingList<User>(userList.OrderByDescending(u => u.Birthdate).ToList());
                            userSortOrder[3] = SortOrder.Desceding;
                        }
                        else
                        {
                            userList = new BindingList<User>(userList.OrderBy(u => u.Birthdate).ToList());
                            userSortOrder[3] = SortOrder.Asceding;
                        }
                        break;
                    case 4:
                        if (userSortOrder[4] == SortOrder.Asceding)
                        {
                            userList = new BindingList<User>(userList.OrderByDescending(u => u.Age).ToList());
                            userSortOrder[4] = SortOrder.Desceding;
                        }
                        else
                        {
                            userList = new BindingList<User>(userList.OrderBy(u => u.Age).ToList());
                            userSortOrder[4] = SortOrder.Asceding;
                        }
                        break;
                    case 5:
                        if (userSortOrder[5] == SortOrder.Asceding)
                        {
                            userList = new BindingList<User>(userList.OrderByDescending(u => u.ListRewardsToString).ToList());
                            userSortOrder[5] = SortOrder.Desceding;
                        }
                        else
                        {
                            userList = new BindingList<User>(userList.OrderBy(u => u.ListRewardsToString).ToList());
                            userSortOrder[5] = SortOrder.Asceding;
                        }
                        break;
                    default:
                        break;
                }
                grid.DataSource = userList;
            }

            if (grid.DataSource== rewardList)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (rewardSortOrder[0] == SortOrder.Asceding)
                        {
                            rewardList = new BindingList<Reward>(rewardList.OrderByDescending(u => u.ID).ToList());
                            rewardSortOrder[0] = SortOrder.Desceding;
                        }
                        else
                        {
                            rewardList = new BindingList<Reward>(rewardList.OrderBy(u => u.ID).ToList());
                            rewardSortOrder[0] = SortOrder.Asceding;
                        }
                        break;
                    case 1:
                        if (rewardSortOrder[1] == SortOrder.Asceding)
                        {
                            rewardList = new BindingList<Reward>(rewardList.OrderByDescending(u => u.Title).ToList());
                            rewardSortOrder[1] = SortOrder.Desceding;
                        }
                        else
                        {
                            rewardList = new BindingList<Reward>(rewardList.OrderBy(u => u.Title).ToList());
                            rewardSortOrder[1] = SortOrder.Asceding;
                        }
                        break;
                    case 2:
                        if (rewardSortOrder[2] == SortOrder.Asceding)
                        {
                            rewardList = new BindingList<Reward>(rewardList.OrderByDescending(u => u.Description).ToList());
                            rewardSortOrder[2] = SortOrder.Desceding;
                        }
                        else
                        {
                            rewardList = new BindingList<Reward>(rewardList.OrderBy(u => u.Description).ToList());
                            rewardSortOrder[2] = SortOrder.Asceding;
                        }
                        break;
                    default:
                        break;
                }
                grid.DataSource = rewardList;
            }
        }

        private void tsmiAddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void tsmiEditUser_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void tsmiDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void tsmiAddReward_Click(object sender, EventArgs e)
        {
            AddReward();
        }

        private void tsmiEditReward_Click(object sender, EventArgs e)
        {
            EditReward();
        }

        private void tsmiDeleteReward_Click(object sender, EventArgs e)
        {
            DeleteReward();
        }

        private void ctlUserGrid_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }

        private void ctlRewardGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditReward();
        }


        private void AddUser()
        {
            var userForm = new UserForm();
            userForm.listAllRewards = rewardList.ToList();
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                var user = new User(userList.Count == 0 ? 0 : userList.Max(u => u.ID) + 1, userForm.FirstName, userForm.LastName, userForm.Birthdate, userForm.RewardsList);
                userList.Add(user);
            }
        }

        private void EditUser()
        {
            if (ctlUserGrid.SelectedCells.Count != 0)
            {
                var user = userList.First(u => u.ID == SelectedEntityID(ctlUserGrid));
                var userForm = new UserForm(user);
                userForm.listAllRewards = rewardList.ToList();
                if (userForm.ShowDialog() == DialogResult.OK)
                {
                    user.FirstName = userForm.FirstName;
                    user.LastName = userForm.LastName;
                    user.Birthdate = userForm.Birthdate;
                    user.RewardsList = userForm.RewardsList;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteUser()
        {
            if (ctlUserGrid.SelectedCells.Count != 0)
            {
                User user = userList.First(u => u.ID == SelectedEntityID(ctlUserGrid));

                if (MessageBox.Show($"Вы действительно хотите удалить пользователя {user.FirstName} {user.LastName}?", "Подтверждение",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userList.Remove(user);
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали пользователя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddReward()
        {
            var rewardForm = new RewardForm();
            if (rewardForm.ShowDialog() == DialogResult.OK)
            {
                var reward = new Reward(rewardList.Count == 0 ? 0 : rewardList.Max(u => u.ID) + 1, rewardForm.Title, rewardForm.Description);
                rewardList.Add(reward);
            }
        }

        private void EditReward()
        {
            if (ctlRewardGrid.SelectedCells.Count != 0)
            {
                var reward = rewardList.First(r => r.ID == SelectedEntityID(ctlRewardGrid));
                var rewardForm = new RewardForm(reward);
                if (rewardForm.ShowDialog() == DialogResult.OK)
                {
                    reward.Title = rewardForm.Title;
                    reward.Description = rewardForm.Description;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали награду для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteReward()
        {
            if (ctlRewardGrid.SelectedCells.Count != 0)
            {
                Reward reward = rewardList.First(r => r.ID == SelectedEntityID(ctlRewardGrid));
                if (MessageBox.Show($"Вы действительно хотите удалить награду {reward.Title}?", "Подтверждение",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Удаление выбранной награды у пользователей (у которых она есть)
                    foreach (var user in userList)
                    {
                        if (user.RewardsList.Count != 0)
                        {
                            user.RewardsList.RemoveAll(r => r.ID == reward.ID);
                        }
                    }
                    rewardList.Remove(reward);
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали награду для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Возвращает ID (значение из первого поля) выбранной строки
        private int SelectedEntityID(DataGridView grid)
        {
            var rowIndex = grid.SelectedCells[0].RowIndex;
            return (int)grid.Rows[rowIndex].Cells[0].Value;
        }
    }
}
