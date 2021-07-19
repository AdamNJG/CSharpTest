using System;
using System.Collections.Generic;

namespace FTPLogger
{
    public class Log
	{
		public static long objectCount = 0;

		private readonly long id;

		private String metaData;

		private String dateUpdated;

		private String fileName;

		private String fullString;

		private bool folder;

		private bool error;

		public Log()
		{
			id = ++objectCount;
			folder = false;
			error = false;
			metaData = "";
		}

		public long GetId()
        {
			return id;
        }

		public String GetMetaData()
        {
			return metaData;
        }
		public String GetDateUpdated()
		{
			return dateUpdated;
		}
		public String GetFileName()
		{
			return fileName;
		}

		public String GetFullString()
        {
			return fullString;
        }

		public bool IsFolder()
        {
			return folder;
        }

		public void SetFileName(String value)
        {
			fileName = value;
        }

		public void SetMetaData(String value)
		{
			metaData = value;
		}

		public void SetDateUpdated(String value)
		{
			dateUpdated = value;
		}

		public void SetFullString(String value)
		{
			fullString = value;
		}

		public void SetFolder(bool value)
        {
			folder = value;
        }

		public bool IsError()
        {
			return error;
        }

		public void SetError(bool value)
        {
			error = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Log log &&
                   fullString == log.fullString;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(fullString);
        }

        public static bool operator ==(Log left, Log right)
        {
            return EqualityComparer<Log>.Default.Equals(left, right);
        }

        public static bool operator !=(Log left, Log right)
        {
            return !(left == right);
        }
    }
}