using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using NetworkComputers;
namespace ComputerCollectionTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView tvComputerList;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tvComputerList = new System.Windows.Forms.TreeView();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// tvComputerList
			// 
			this.tvComputerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvComputerList.ImageIndex = -1;
			this.tvComputerList.Location = new System.Drawing.Point(0, 0);
			this.tvComputerList.Name = "tvComputerList";
			this.tvComputerList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					   new System.Windows.Forms.TreeNode("Searching computers and servers in your network. Please wait.")});
			this.tvComputerList.SelectedImageIndex = -1;
			this.tvComputerList.Size = new System.Drawing.Size(344, 286);
			this.tvComputerList.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 286);
			this.Controls.Add(this.tvComputerList);
			this.Name = "Form1";
			this.Text = "Computer List";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private DomainCollection myDomains;
		private void Form1_Load(object sender, System.EventArgs e)
		{
			Thread th=new Thread(new ThreadStart(LoadComputerList));
			th.IsBackground=true;
			th.Start();
		}
		private void LoadComputerList()
		{
			Mutex loadMutex=new Mutex(false,"NetworkComputer");
			loadMutex.WaitOne();
			myDomains=new DomainCollection();
			myDomains.Refresh();
			for (int i=0;i<myDomains.Count;i++)
			{
				myDomains[i].DialinServers.Refresh();
				myDomains[i].DomainControllers.Refresh();
				myDomains[i].PrintServers.Refresh();
				myDomains[i].TerminalServers.Refresh();
				myDomains[i].TimeServers.Refresh();
				myDomains[i].Workstations.Refresh();
				myDomains[i].SQLServers.Refresh();
			}
			loadMutex.ReleaseMutex();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Mutex loadMutex=new Mutex(false,"NetworkComputer");
			if(loadMutex.WaitOne(0,false)==true)
			{
				timer1.Enabled=false;
				tvComputerList.Nodes.Clear();
				for (int i=0;i<myDomains.Count;i++)
				{
					System.Windows.Forms.TreeNode domainNode=new TreeNode(myDomains[i].Name);
					tvComputerList.Nodes.Add(domainNode);
					if (myDomains[i].DialinServers.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("Dial In Servers");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].DialinServers.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].DialinServers[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
					if (myDomains[i].DomainControllers.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("Domain Controllers");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].DomainControllers.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].DomainControllers[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
					if (myDomains[i].PrintServers.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("Print Servers");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].PrintServers.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].PrintServers[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
					if (myDomains[i].TerminalServers.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("Terminal Servers");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].TerminalServers.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].TerminalServers[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
					if (myDomains[i].TimeServers.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("Time Servers");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].TimeServers.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].TimeServers[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
					if (myDomains[i].Workstations.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("Workstations");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].Workstations.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].Workstations[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
					if (myDomains[i].SQLServers.Count>0)
					{
						System.Windows.Forms.TreeNode serversNode=new TreeNode("SQL Servers");
						domainNode.Nodes.Add(serversNode);
						for (int j=0;j<myDomains[i].SQLServers.Count;j++)
						{
							System.Windows.Forms.TreeNode computerNode=new TreeNode(myDomains[i].SQLServers[j].Name);
							serversNode.Nodes.Add(computerNode);
						}
					}
				}
				loadMutex.ReleaseMutex();
			}
		}
	}
}
