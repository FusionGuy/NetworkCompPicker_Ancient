using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Reflection;
namespace NetworkComputers
{
	/// <summary>
	/// Summary description for ArrayListCollectionClass.
	/// </summary>
	[Serializable()]
	public class DomainCollection:ICollection,ISerializable
	{
		private ArrayList list;
		#region Constractors
		public DomainCollection()
		{
			//
			// TODO: Add constructor logic here
			//
			list=new ArrayList();
			
		}
		public DomainCollection(SerializationInfo info, StreamingContext ctxt)
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
				FillupDomainList();
				return list.IsSynchronized;
			}
		}

		public int Count
		{
			get
			{
				// TODO:  Add ArrayListCollectionClass.Count getter implementation
				FillupDomainList();
				return list.Count;
			}
		}

		public void CopyTo(Array array, int index)
		{
			// TODO:  Add ArrayListCollectionClass.CopyTo implementation
			FillupDomainList();
			list.CopyTo(array,index);
		}

		public object SyncRoot
		{
			get
			{
				// TODO:  Add ArrayListCollectionClass.SyncRoot getter implementation
				FillupDomainList();
				return list.SyncRoot;
			}
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			// TODO:  Add ArrayListCollectionClass.GetEnumerator implementation
			FillupDomainList();
			return list.GetEnumerator();
		}

		#endregion

		#region ISerializable Members

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// TODO:  Add ArrayListCollectionClass.GetObjectData implementation
			FillupDomainList();
			info.AddValue("list", list);
		}

		#endregion

		#region Public Method

		public bool Contains(NetworkComputers.Domain value)
		{
			FillupDomainList();
			return list.Contains(value);
		}

		public NetworkComputers.Domain this[int index]
		{
			get 
			{
				FillupDomainList();
				return (NetworkComputers.Domain)list[index]; 
			}
		}
		public void Refresh()
		{
			list.Clear();
			FillupDomainList();
		}
		#endregion

		#region Private Members
		private void FillupDomainList()
		{
			if (list.Count==0)
			{
				CompEnum ce;
				ce = new CompEnum(0x80000000, null);
				Domain myDomain;
				for (int i=0; i<ce.Length; i++)
				{
					myDomain=new Domain(ce[i].Name);
					list.Add(myDomain);
				}
			}
		}
		
		#endregion
		
	}
}
