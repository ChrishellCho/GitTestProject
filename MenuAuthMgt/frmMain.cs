using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAuthMgt
{
	public partial class frmMain : Form
	{
		string userID;

		public frmMain(string userID)
		{
			InitializeComponent();
			this.userID = userID;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			//아이디로 접근할 수 있는 메뉴 동적 바인딩
			MenuDAC db = new MenuDAC();
			DataTable dtMenu = db.GetUserMenuList(this.userID);

			DrawMenuStrip(dtMenu);
			DrawMenuPanel(dtMenu);
		}

		private void DrawMenuPanel(DataTable dtMenu)
		{
			DataView dv1 = new DataView(dtMenu);
			dv1.RowFilter = "menu_level=1";
			dv1.Sort = "menu_sort";
			for (int i = 0; i < dv1.Count; i++)
			{
				ToolStripMenuItem p_menu = new ToolStripMenuItem();
				p_menu.Name = $"p_menu{dv1[i]["menu_id"].ToString()}";
				p_menu.Text = dv1[i]["menu_name"].ToString();
				p_menu.Size = new Size(180, 22);

				DataView dv2 = new DataView(dtMenu);
				dv2.RowFilter = "menu_level = 2 and pnt_menu_id=" + dv1[i]["pnt_menu_id"].ToString();
				dv2.Sort = "menu_sort";

				for (int k = 0; k < dv1.Count; k++)
				{
					Button

					this.button1.Dock = System.Windows.Forms.DockStyle.Top;
					this.button1.Location = new System.Drawing.Point(0, 0);
					this.button1.Margin = new System.Windows.Forms.Padding(0);
					this.button1.Name = "button1";
					this.button1.Size = new System.Drawing.Size(196, 36);
					this.button1.TabIndex = 0;
					this.button1.Tag = "0";
					this.button1.Text = "button1";
					this.button1.UseVisualStyleBackColor = true;
					this.button1.Click += new System.EventHandler(this.button1_Click);
				}

			}

			private void DrawMenuStrip(DataTable dtMenu)
			{
				DataView dv1 = new DataView(dtMenu);
				dv1.RowFilter = "menu_level=1";
				dv1.Sort = "menu_sort";
				for (int i = 0; i < dv1.Count; i++)
				{
					ToolStripMenuItem p_menu = new ToolStripMenuItem();
					p_menu.Name = $"p_menu{dv1[i]["menu_id"].ToString()}";
					p_menu.Text = dv1[i]["menu_name"].ToString();
					p_menu.Size = new Size(180, 22);

					DataView dv2 = new DataView(dtMenu);
					dv2.RowFilter = "menu_level = 2 and pnt_menu_id=" + dv1[i]["pnt_menu_id"].ToString();
					dv2.Sort = "menu_sort";

					for (int k = 0; k < dv1.Count; k++)
					{
						ToolStripMenuItem c_menu = new ToolStripMenuItem();
						p_menu.Name = $"p_menu{dv1[i]["menu_id"].ToString()}";
						p_menu.Text = dv1[i]["menu_name"].ToString();
						p_menu.Size = new Size(180, 22);

						p_menu.DropDownItems.Add(c_menu);
					}

					this.menuStrip1.Items.Add(p_menu);
				}
			}

			private void button1_Click(object sender, EventArgs e)
			{
				Button btn = (Button)sender;
				flowLayoutPanel1.Controls.SetChildIndex(panel1, Convert.ToInt32(btn.Tag) + 1);
				flowLayoutPanel1.Invalidate();
			}

		}
	}
}