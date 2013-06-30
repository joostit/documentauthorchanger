using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DocumentAuthorChanger
{
	public partial class MainForm : Form
	{
		private string newAuthorName = "";
		private BackgroundWorker processor;
		List<string> allFiles;
		private string fileFolder;
		int errors = 0;
		int nDone = 0;
		bool cancelled = false;

		Boolean keepLastModified = true;

		public MainForm()
		{
			InitializeComponent();
		}

		private void selectDirButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog diag = new FolderBrowserDialog();

			if (fileFolder != null)
			{
				diag.SelectedPath = fileFolder;
			}
			if (diag.ShowDialog() == DialogResult.OK)
			{
				fileFolder = diag.SelectedPath;
				allFiles = getDocfiles(fileFolder);
				folderBox.Text = fileFolder;
				countLabel.Text = allFiles.Count.ToString() + " files found.";
				if (allFiles.Count > 0)
				{
					applyButton.Enabled = true;
				}
				else
				{
					applyButton.Enabled = false;
				}
			}
			diag.Dispose();
		}


		/// <summary>
		/// Gets all doc files
		/// </summary>
		/// <returns></returns>
		private List<string> getDocfiles(string folder)
		{
			List<string> retVal = new List<string>();
			string[] docFiles = Directory.GetFiles(folder, "*.doc");

			foreach (string file in docFiles)
			{
				bool isReadOnly = ((File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
				bool isHidden = ((File.GetAttributes(file) & FileAttributes.Hidden) == FileAttributes.Hidden);
				bool isSystem = ((File.GetAttributes(file) & FileAttributes.System) == FileAttributes.System);

				if (!isReadOnly && !isHidden && !isSystem)
				{
					string extension = Path.GetExtension(file);
					if ((extension == ".doc") || (extension == ".docx"))
					{
						retVal.Add(file);
					}
				}
			}


			return retVal;
		}

		private void keepLastModifiedBox_CheckedChanged(object sender, EventArgs e)
		{
			keepLastModified = keepLastModifiedBox.Checked;
		}


		private void authorBox_TextChanged(object sender, EventArgs e)
		{
			newAuthorName = authorBox.Text;
		}

		private void applyButton_Click(object sender, EventArgs e)
		{
			string msg = "This will set the Author property of all documents to '" + newAuthorName + "'. Are you sure you want to continue?\n\n" + "(Make sure you have a backup of all files, in case something goes wrong!)";

			if (MessageBox.Show(msg, "Apply author?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
			{
				return;
			}

			if (allFiles == null)
			{
				MessageBox.Show("No files to process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (allFiles.Count == 0)
			{
				MessageBox.Show("The selected directory doesn't contain any files.", "No files to process", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			startProcessing();
		}



		private void startProcessing()
		{
			processor = new BackgroundWorker();
			processor.DoWork += new DoWorkEventHandler(processor_DoWork);
			processor.ProgressChanged += new ProgressChangedEventHandler(processor_ProgressChanged);
			processor.WorkerSupportsCancellation = true;
			processor.RunWorkerCompleted += new RunWorkerCompletedEventHandler(processor_RunWorkerCompleted);
			processor.WorkerReportsProgress = true;
			indicateWorking(true);
			logBox.Clear();
			processor.RunWorkerAsync();
		}

		void processor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (cancelled)
			{
				MessageBox.Show("The operation has been cancelled. " + nDone.ToString() + " files have already been changed. Please review the log for info", "Done", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				MessageBox.Show(nDone + " files have been processed. Errors: " + errors.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			indicateWorking(false);
		}


		private void indicateWorking(bool working)
		{
			progressBar.Visible = working;
			folderGroup.Enabled = !working;
			applyButton.Enabled = !working;
			keepLastModifiedBox.Enabled = !working;
			cancelButton.Visible = working;
			cancelButton.Enabled = true;
		}


		void processor_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar.Value = e.ProgressPercentage;
		}

		void processor_DoWork(object sender, DoWorkEventArgs e)
		{
			cancelled = false;
			nDone = 0;
			errors = 0;

			foreach (String file in allFiles)
			{
				if (processor.CancellationPending)
				{
					cancelled = true;
					return;
				}

				processor.ReportProgress((int)Math.Round((((double)nDone) / allFiles.Count) * 100.0));

				addLogTxt("Processing file '" + Path.GetFileName(file) + "'... ");
				try
				{
					setAuthorForDocument(file, newAuthorName, keepLastModified);
					addLogTxt("Done.\r\n");

				}
				catch (Exception exc)
				{
					errors++;
					addLogTxt("Error: " + exc.Message + "\r\n");
				}
				nDone++;
			}

			processor.ReportProgress(100);
		}


		private void addLogTxt(string txt)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(delegate()
				{
					addLogTxt(txt);
				}));
				return;
			}

			logBox.AppendText(txt);
			logBox.SelectionStart = logBox.TextLength;
			logBox.ScrollToCaret();

		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			if (processor != null)
			{
				cancelButton.Enabled = false;
				processor.CancelAsync();
			}
		}


		private void setAuthorForDocument(string filePath, string newAuthor, Boolean keepLastModifiedState)
		{

			object fileName = filePath;
			object missing = System.Reflection.Missing.Value;
			DateTime lastModified = File.GetLastWriteTime(filePath);
			Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
			Microsoft.Office.Interop.Word.Document aDoc = null;
			try
			{
				DateTime toDay = DateTime.Now;

				object readOnly = false;
				object isVisible = false;

				wordApp.Visible = false;

				aDoc = wordApp.Documents.Open(ref fileName, ref missing,
					ref readOnly, ref missing, ref missing, ref missing,
					ref missing, ref missing, ref missing, ref missing,
					ref missing, ref missing, ref missing, ref missing,
					ref missing, ref missing);

				aDoc.Activate();

				object BuiltInProps;
				BuiltInProps = aDoc.BuiltInDocumentProperties;

				Type TypeBuiltingProp = BuiltInProps.GetType();
				string Prop = "Author";
				string PropValue;
				object AuthorProp = TypeBuiltingProp.InvokeMember("item", BindingFlags.Default | BindingFlags.GetProperty, null, BuiltInProps, new Object[] { Prop });
				Type TypeAuthorProp = AuthorProp.GetType();

				PropValue = TypeAuthorProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, AuthorProp, new Object[] { }).ToString();
				TypeAuthorProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.SetProperty, null, AuthorProp, new Object[] { newAuthor });
			}
			finally
			{
				try
				{
					aDoc.Save();
					aDoc.Close();
					wordApp.Quit();
				}
				catch { }
			}

			if (keepLastModifiedState)
			{
				File.SetLastWriteTime(filePath, lastModified);
			}

		}
	}
}
