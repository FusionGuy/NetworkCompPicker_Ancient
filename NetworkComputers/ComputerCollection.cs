using System;
using System.Collections;
using System.Runtime.Serialization;
namespace NetworkComputers
{
	/// <summary>
	/// Summary description for ArrayListCollectionClass.
	/// </summary>
	[Serializable()]
	public class ComputerCollection:ICollection,ISerializable
	{
		private ArrayList list;
		private CompEnum.ServerType serverType;
		public CompEnum.ServerType ServerType
		{
			get
			{
				return serverType;
			}
		}

		private string domainName;
		public string DomainName
		{
			get
			{
				return domainName;
			}
		}

		#region Constractors
		public ComputerCollection(CompEnum.ServerType serverType,string domainName)
		{
			//
			// TODO: Add constructor logic here
			//
			this.serverType=serverType;
			this.domainName=domainName;
			list=new ArrayList();
		}
		public ComputerCollection(SerializationInfo info, StreamingContext ctxt)
		{
			list=(ArrayList)info.GetValue("list", typeof(ArrayList));
		}
		#endregion

		#region ICollection Members

		public bool IsSynchronized
		{
			get
			{
				// TODO:  Add ArrayListCollectionClass.IsSynchronized getter implementation
				FillupComputers();
				return list.IsSynchronized;
			}
		}

		public int Count
		{
			get
			{
				// TODO:  Add ArrayListCollectionClass.Count getter implementation
				FillupComputers();
				return list.Count;
			}
		}

		public void CopyTo(Array array, int index)
		{
			// TODO:  Add ArrayListCollectionClass.CopyTo implementation
			FillupComputers();
			list.CopyTo(array,index);
		}

		public object SyncRoot
		{
			get
			{
				// TODO:  Add ArrayListCollectionClass.SyncRoot getter implementation
				FillupComputers();
				return list.SyncRoot;
			}
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			// TODO:  Add ArrayListCollectionClass.GetEnumerator implementation
			FillupComputers();
			return list.GetEnumerator();
		}

		#endregion

		#region ISerializable Members

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// TODO:  Add ArrayListCollectionClass.GetObjectData implementation
			FillupComputers();
			info.AddValue("list", list);
		}

		#endregion

		#region Public Method

		public bool Contains(NetworkComputers.Computer value)
		{
			FillupComputers();
			return list.Contains(value);
		}

		public NetworkComputers.Computer this[int index]
		{
			get 
			{
				FillupComputers();
				return (NetworkComputers.Computer)list[index]; 
			}
		}
		#endregion
		private void FillupComputers()
		{
			if (list.Count==0)
			{
				if (serverType==CompEnum.ServerType.SV_TYPE_SQLSERVER)
				{
					FillupSQLServers();
					return;
				}
				CompEnum ce;
				ce = new CompEnum(serverType, domainName);
				int numServer = ce.Length;
				if (ce.LastError.Length == 0)
				{
					IEnumerator enumerator = ce.GetEnumerator();
					int i = 0;
					Computer ctr;
					while (enumerator.MoveNext())
					{
						ctr=new Computer();
						ctr.Name=ce[i].Name;
						ctr.ServerType=serverType;
						list.Add(ctr);
						i++;
					}
				}
			}
		}
		private void FillupSQLServers()
		{
			SQLDMO.Application app = new SQLDMO.ApplicationClass();
			SQLDMO.NameList nameList = app.ListAvailableSQLServers();
			string srvName = "";
			Computer ctr;
			for (int i=0; i<nameList.Count; i++)
			{	
				srvName = nameList.Item(i + 1);
				ctr=new Computer();
				ctr.Name=srvName;
				ctr.ServerType=serverType;
				list.Add(ctr);
			}
		}
		public void Refresh()
		{
			list.Clear();
			FillupComputers();
		}
	}
}
