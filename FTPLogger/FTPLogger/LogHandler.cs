using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPLogger
{
	public class LogHandler
	{
		public List<Log> directories = new List<Log>();
		public List<Log> checkedDir = new List<Log>();
		public List<Log> toCheck = new List<Log>();

		public async void WriteToFile(String content, String path)
        {
			String checkedPath = (String.IsNullOrEmpty(path) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : path);

			await File.WriteAllTextAsync(checkedPath + "\\log.txt", content);
        }

		public List<Log> ConnectFtp(String host, String user, String password)
        {
			List<Log> tempLogs = new List<Log>();
			try
			{
				
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" +host + "/");
				request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

				request.Credentials = new NetworkCredential(user, password);

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();

				Stream responseStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(responseStream);
				

				string line = reader.ReadLine();
				
				while (!string.IsNullOrEmpty(line))
				{
					Log log = LogFactory(line, false);
					tempLogs.Add(log);
					line = reader.ReadLine();
				} 
				reader.Close();

				return tempLogs;

			}
			catch (WebException webEx)
			{
				Log errorLog = LogFactory(webEx.Message, true); 
				tempLogs.Add(errorLog);
				foreach (Log log in tempLogs)
				{
					Debug.WriteLine(log.GetFullString());
				}
				return tempLogs;
			}
			catch (Exception ex)
			{
				Log errorLog = LogFactory(ex.Message, true);
				tempLogs.Add(errorLog);
				return tempLogs;
			}
			
		}

		public String ListPrinter(String prev)
        {
			StringBuilder sb = new StringBuilder(prev);
			foreach (Log log in directories)
			{
				sb.Append(log.GetFullString());
				sb.Append(Environment.NewLine);
			}
			directories = new List<Log>();
			
			sb.Append("-- " + System.DateTime.Now + " --");
			sb.Append(Environment.NewLine);
			return sb.ToString();

        }

		public void ListBuilder(String host, String username, String password)
        {
			toCheck = ConnectFtp(host,username,password);
			List<Log> tempList = new List<Log>();
			List<String> newHosts = new List<String>();

			foreach (Log log in toCheck)
			{
				if(checkedDir.Count() > 1)
                {
					List<Log> tempChecked = new List<Log>();
 					foreach (Log check in checkedDir)
						{
							if (log.GetFullString() != check.GetFullString())
							{
								directories.Add(log);
							    tempChecked.Add(log);
								if (log.GetMetaData().Contains("drwxr-xr-x"))
									{
										String[] arr = log.GetFullString().Split(" ");
										log.SetFolder(true);
										String newHost = host + "/" + arr[21];
										newHosts.Add(newHost);
										tempList.Add(log);
									}
							}
						}
				
					checkedDir.Add(tempChecked[tempChecked.Count() - 1]);
				}
				else
				{
					checkedDir.Add(log);
					directories.Add(log);
					if (log.GetMetaData().Contains("drwxr-xr-x"))
					{
						String[] arr = log.GetFullString().Split(" ");
						log.SetFolder(true);
						String newHost = host + "/" + arr[21];
						newHosts.Add(newHost);
						tempList.Add(log);
					}
				}
			}



			if (newHosts.Count() > 0)
            {
				NextList(newHosts, username, password);
            }
		}

		public String host;

		public void NextList(List<String> hostList, String username, String password)
		{
			List<Log> tempList = new List<Log>();

			List<String> newHosts = new List<String>();

		
			foreach (String currentHost in hostList)
			{
				tempList.AddRange(ConnectFtp(currentHost, username, password));
				host = currentHost;
			}
			hostList.Remove(host);


			List<Log> tempCheck = new List<Log>();

			foreach (Log log in tempList)
			{
						foreach (Log check in checkedDir)
						{
					
							if (!log.Equals(check))
							{
								directories.Add(log);
								tempCheck.Add(log);

							if (log.GetMetaData().Contains("drwxr-xr-x"))
							{
								String[] arr = log.GetFullString().Split(" ");
								log.SetFolder(true);
								String newHost = host + "/" + arr[21];
								foreach (String checkHost in hostList)
									{
										if (newHost != checkHost)
									{
									newHosts.Add(newHost);
								}
							}	

						}
					}

				}	
				checkedDir.Add(log);
			}

			foreach(Log log in directories)
            {
				Debug.WriteLine(log.GetFileName());
            }

			toCheck = tempCheck;
			
			if (toCheck.Count() > 0)
			{
				NextList(newHosts, username, password);
			}
		}


		public Log LogFactory(String value, bool error)
        {

			String[] split = value.Split(" ");
			Log log = new Log();
			if (split.Length > 1 && !error)
			{
				if (split[0].Contains("drwxr-xr-x"))
				{
					log.SetFolder(true);
				}
				StringBuilder sb = new StringBuilder(log.GetMetaData());
				for (int i = 0; i < 10; i++)
				{
					sb.Append(split[i]);
				}
				log.SetMetaData(sb.ToString());
				log.SetFileName(split[21]);
				log.SetError(error);
				log.SetFullString(value);
				log.SetDateUpdated(split[18] + split[19] + split[20]);
			}
			else { 
				log.SetFullString(value);
				log.SetError(error);
			}

            
			return log;
        }

	}


}
