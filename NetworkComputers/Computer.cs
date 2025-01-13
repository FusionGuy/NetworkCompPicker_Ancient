using System;

namespace NetworkComputers
{
	/// <summary>
	/// Summary description for Computer.
	/// </summary>
	public class Computer
	{
		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name=value;
			}
		}
		private CompEnum.ServerType serverType;
		public CompEnum.ServerType ServerType
		{
			get
			{
				return serverType;
			}
			set
			{
				serverType=value;
			}
		}
		public Computer()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
