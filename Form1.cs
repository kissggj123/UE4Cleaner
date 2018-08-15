using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace UE4Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string []subkeyNames;
            string ue4pathcache = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UnrealEngine\\Common\\DerivedDataCache";
            string ue4path = "当前登陆用户："+ System.Environment.UserName +"\r\n当前登陆电脑：" +Environment.MachineName;
            cachelocation.Text = ue4path;
            label4.Text = "";
            /*RegistryKey key = Registry.LocalMachine;
            RegistryKey ue4key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "");
            string ue4version = "SOFTWARE\\EpicGames\\Unreal Engine";
            RegistryKey UE4KEY = ue4key.OpenSubKey(ue4version);
            String[] keyNameArray = UE4KEY.GetValueNames();
            foreach (String keyName in keyNameArray)
            {
                string keyValue = (string)UE4KEY.GetValue(keyName);
            }*/
            //注释代码功能作废
            if (!System.IO.Directory.Exists(ue4pathcache))
            {
                //System.IO.Directory.CreateDirectory(ue4path);//不存在就锁定功能
                clean.Enabled = false;
                label3.Text = "不存在缓存 无法清理";
            }
            else
            {
                clean.Enabled = true;
                label3.Text = "已检测到缓存 工具准备就绪";
            }

        }

        private void clean_Click(object sender, EventArgs e)
        {
            string ue4path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UnrealEngine\\Common\\DerivedDataCache";
            label3.Text = "";
            label4.Text = "开始清理缓存";
            try
            {
                File.SetAttributes(ue4path, FileAttributes.Normal);
                //System.Diagnostics.Process.Start("del /f " + ue4path);
                Directory.Delete(ue4path, true); 
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!System.IO.Directory.Exists(ue4path))
                {
                    label4.Text = "操作已成功";
                    MessageBox.Show("清理完成 很干净", "已完成操作", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    clean.Enabled = false;
                    label3.Text = "清理成功";
                    
                }
                else
                {
                    label4.Text = "操作出错";
                    MessageBox.Show("出现清理错误", "未完成错误的操作", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clean.Enabled = true;
                    label3.Text = "清理出错 请检查错误信息";
                    
                }
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            Form AboutBox1 = new AboutBox1();
            AboutBox1.ShowDialog();
        }

    }
}

            
         
