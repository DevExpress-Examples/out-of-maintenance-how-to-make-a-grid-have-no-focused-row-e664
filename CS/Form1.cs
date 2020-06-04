using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NoFocusedRow
{
    public partial class Form1 : XtraForm
    {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            gridView1.FocusInvalidRow();
        }
        private void Form1_Load(object sender, System.EventArgs e) {
            gridControl1.DataSource = GetData();
        }

        DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ItemName");
            for (int i = 1; i <= 5; i++)
                table.Rows.Add(new object[] { i, "Item " + i.ToString() });
            table.AcceptChanges();
            return table;
        }
    }
}
