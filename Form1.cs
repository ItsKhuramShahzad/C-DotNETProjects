using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomDataaDridViewCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomCheckBoxColumn col = new CustomCheckBoxColumn();
            col.Width = 130;
            col.Label = "this is a test string";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.Columns.Add(col);
           
            
            CustomCheckBoxColumn col1 = new CustomCheckBoxColumn();
            col.Width = 130;
            col.Label = "this is a test string";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.Columns.Add(col1);
            CustomCheckBoxColumn col2 = new CustomCheckBoxColumn();
            col.Width = 130;
            col.Label = "this is a test string";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.Columns.Add(col2);
     
            this.dataGridView1.RowCount = 1;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                ((CustomCheckBoxCell)row.Cells[0]).Label = " test string";
                //((CustomCheckBoxCell)row.Cells[0]).Icon = Image.FromFile(@"D:\All EPOS's 2020\MABH-Comon-EPOS\Quantum-POS 08-Jan-2023\EPOS\Resources\ma icons.ico");
               
                ((CustomCheckBoxCell)row.Cells[1]).Label = "test string";
               // ((CustomCheckBoxCell)row.Cells[1]).Icon = Image.FromFile(@"D:\All EPOS's 2020\MABH-Comon-EPOS\Quantum-POS 08-Jan-2023\EPOS\Resources\ma icons.ico");
                ((CustomCheckBoxCell)row.Cells[2]).Label = "test string";
                //((CustomCheckBoxCell)row.Cells[2]).Icon = Image.FromFile(@"D:\All EPOS's 2020\MABH-Comon-EPOS\Quantum-POS 08-Jan-2023\EPOS\Resources\ma icons.ico");

                dataGridView1.Refresh();
            }
        }
        public class CustomCheckBoxColumn : DataGridViewCheckBoxColumn
        {
            private string label;

            public string Label
            {
                get { return label; }
                set { label = value; }
            }

            public override DataGridViewCell CellTemplate
            {
                get { return new CustomCheckBoxCell(); }
            }
        }

        public class CustomCheckBoxCell : DataGridViewCheckBoxCell
        {
            // checkbox string   
            private string label;

            public string Label
            {
                get { return label; }
                set { label = value; }
            }

            // checkbox icon  
            private Image icon;

            public Image Icon
            {
                get { return icon; }
                set { icon = value; }
            }

            // override Paint  
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {

                // the base Paint  
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

                // get the check box bounds  
                Rectangle contentBounds = this.GetContentBounds(rowIndex);

                // the string location  
                Point stringLocation = new Point();
                stringLocation.Y = cellBounds.Y + 10;
                stringLocation.X = cellBounds.X;


                // paint the string.  
                if (this.Label == null)
                {
                    CustomCheckBoxColumn col = (CustomCheckBoxColumn)this.OwningColumn;
                    this.label = col.Label;
                }

                graphics.DrawString(
                this.Label, Control.DefaultFont, System.Drawing.Brushes.Black, stringLocation);


                // the icon rectangel  
                Rectangle rectangle = new Rectangle(cellBounds.X + 15, cellBounds.Y + 2, 15, 15);
                // paint icon  
               //graphics.DrawImage(icon, rectangle);
            }
        }
    }
}
