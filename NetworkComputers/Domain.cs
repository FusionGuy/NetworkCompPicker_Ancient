using System;

namespace NetworkComputers
{
	/// <summary>
	/// Summary description for Domain.
	/// </summary>
	public class Domain
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
		private ComputerCollection workstations;
		public ComputerCollection Workstations
		{
			get
			{
				return workstations;
			}
		}
		private ComputerCollection domainControllers;
		public ComputerCollection DomainControllers
		{
			get
			{
				return domainControllers;
			}
		}
		private ComputerCollection terminalServers;
		public ComputerCollection TerminalServers
		{
			get
			{
				return terminalServers;
			}
		}
		private ComputerCollection timeServers;
		public ComputerCollection TimeServers
		{
			get
			{
				return timeServers;
			}
		}
		private ComputerCollection printServers;
		public ComputerCollection PrintServers
		{
			get
			{
				return printServers;
			}
		}
		private ComputerCollection dialinServers;
		public ComputerCollection DialinServers
		{
			get
			{
				return dialinServers;
			}
		}

		private ComputerCollection sQLServers;
		public ComputerCollection SQLServers
		{
			get
			{
				return sQLServers;
			}
		}


		public Domain(string name)
		{
			//
			// TODO: Add constructor logic here
			//
			this.name=name;
			workstations=new ComputerCollection(CompEnum.ServerType.SV_TYPE_WORKSTATION,name);
			domainControllers=new ComputerCollection(CompEnum.ServerType.SV_TYPE_DOMAIN_CTRL,name);
			terminalServers=new ComputerCollection(CompEnum.ServerType.SV_TYPE_TERMINALSERVER,name);
			timeServers=new ComputerCollection(CompEnum.ServerType.SV_TYPE_TIME_SOURCE,name);
			printServers=new ComputerCollection(CompEnum.ServerType.SV_TYPE_PRINTQ_SERVER,name);
			dialinServers=new ComputerCollection(CompEnum.ServerType.SV_TYPE_DIALIN_SERVER,name);
			sQLServers=new ComputerCollection(CompEnum.ServerType.SV_TYPE_SQLSERVER,name);
		}
		

	}
}
