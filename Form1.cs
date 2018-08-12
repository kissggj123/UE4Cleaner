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
            string ue4path = "当前登陆用户："+ System.Environment.UserName +"\r\n当前登陆电脑：" +Environment.MachineName;
            cachelocation.Text = ue4path;
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
            if (!System.IO.Directory.Exists(ue4path))
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
            label3.Text = "开始清理缓存";
            File.SetAttributes(ue4path, FileAttributes.Normal);
            //System.Diagnostics.Process.Start("del /f " + ue4path);
            Directory.Delete(ue4path, true);
            if (!System.IO.Directory.Exists(ue4path))
            {
                MessageBox.Show("清理完成 很干净","已完成操作");
                clean.Enabled = false;
                label3.Text = "清理成功";
            }
            else
            {
                MessageBox.Show("出现清理错误", "未完成错误的操作");
                clean.Enabled = true;
                label3.Text = "清理出错 检查是否有360等安全保护";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发@北斗家老司机", "Compare on UDK吧");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2018年8月12日\n\r1.移除缓存目录显示\r\n2.调整了界面\r\n3.修复了一点点的性能问题", "v1.4更新日志");
        }
    }
}

            
         
