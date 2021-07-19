using System;


namespace FTPLogger
{
	public class Log
	{
		private long id;

		private String metaData;

		private String DateUpdated;

		private String fileName;

		private bool isFolder;

		public Log()
		{
			this.id = System.Guid.NewGuid();
			
		}

		public long getId()
        {
			return id;
        }
	}
}
