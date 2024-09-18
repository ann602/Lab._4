using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab._4
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }


        private void fMain_Load(object sender, EventArgs e)
        {
            gvTablets.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "brand";
            column.Name = "Бренд";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "price";
            column.Name = "Ціна, грн";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "weight";
            column.Name = "Вага, г";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "color";
            column.Name = "Колір";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "screendiagonal";
            column.Name = "Діагональ екрана, ''";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CPUfrequency";
            column.Name = "Частота процесора, ГГц";
            gvTablets.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "isthereasimcard";
            column.Name = "Sim-карта";
            column.Width = 60;
            gvTablets.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "isthereamemorycardslot";
            column.Name = "Слот для карти пам'яті";
            column.Width = 60;
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DiscountedPrice";
            column.Name = "Ціна зі знижкою 30%, грн";
            gvTablets.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DiscountWithRegularCustomerCard";
            column.Name = "Ціна зі знижкою 30% та знижкою постійного клієнта, грн";
            gvTablets.Columns.Add(column);


            bindSrcTablets.Add(new Tablet("Acer", 20000, 540, "Black", 9.8, 2.1, true, true, 14000, 13300));
            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tablet tablet = new Tablet();

            fTablet ft = new fTablet(tablet);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablets.Add(tablet);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Tablet tablet = (Tablet)bindSrcTablets.List[bindSrcTablets.Position];

            fTablet ft = new fTablet(tablet);
            if (ft.ShowDialog() ==DialogResult.OK) 
            {
                bindSrcTablets.List[bindSrcTablets.Position] = tablet;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcTablets.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcTablets.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0); 
        }
    }
}
