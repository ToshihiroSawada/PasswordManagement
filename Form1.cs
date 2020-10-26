using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace PasswordManagement
{
    public partial class Form1 : Form
    {
        public int dispHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        public int dispWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

        public Form1()
        {
            InitializeComponent();
            Trace.WriteLine("\n" + dispHeight + "\n" + dispWidth);
            Databse();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string character = "abcdefghijklmnopqrstuvwxyz";
            int randInt = 0;
            string cachestring = "";

            if (radioButton1.Checked == true)
            {
                character += "0123456789";
            }

            if (textBox4.Text != null)
            {
                character += textBox4.Text;
            }
            //character += "!"#$%&\'()*+,-./:;<=>?@[\]^_`{|}~"
            if (radioButton3.Checked == true)
            {
                character += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                Random rand = new Random();
                randInt = rand.Next(0, character.Length);
                cachestring += character[randInt];
            }

            textBox5.Text = cachestring;
            //Trace.WriteLine(cachestring);
            //Trace.WriteLine(character.ToUpper());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Insert();
        }


        public SQLiteConnectionStringBuilder sqlConnection = new SQLiteConnectionStringBuilder { DataSource = "data.db" };

        private void Databse()
        {
            //SQliteのテーブルを作成する(既に存在する場合はスキップしてくれるらしい)
            using (var DB = new SQLiteConnection(sqlConnection.ToString()))
            {
                DB.Open();
                using (var command = new SQLiteCommand(DB))
                {
                    //テーブル作成
                    //IF NOT EXISTSでテーブルが存在しているか確認して、存在していなければ作成する
                    command.CommandText = "CREATE TABLE IF NOT EXISTS data( no INTEGER NOT NULL PRIMARY KEY, id TEXT NOT NULL, pass TEXT NOTNULL )";
                }
                DB.Close();
            }
        }

        private void Insert()
        {
            //DBとのコネクションの作成
            using (var connection = new SQLiteConnection(sqlConnection.ToString()))
            {
                //コネクションをオープンする
                connection.Open();
                SQLiteTransaction transaction = null;
                try
                {
                    //トランザクションの開始
                    transaction = connection.BeginTransaction();

                    //コマンドの生成
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO data( Id, Pass ) VALUES ( '{textBox1.Text}', '{textBox5.Text}' )";
                        command.ExecuteNonQuery();

                        //コミットする
                        transaction.Commit();
                    }
                }
                catch (Exception e) 
                {
                    Trace.WriteLine(e);
                }
            }
        }


    }
}
