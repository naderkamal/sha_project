using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        //lists
        Leader leader;
        Tmember mem;
        ListViewItem v;
        int ch;
        List<Task> tasks = new List<Task>();
        List<Tmember> members = new List<Tmember>();
        List<Leader> leaders = new List<Leader>();
        functions f = new functions();
        
        public Form1()
        {
            InitializeComponent();
            panelmember_list.Visible = false;
            panelleaderlist.Visible = false;
            panelsign_in.Visible = false;
            panelfree.Visible = false;
            paneladdtask.Visible = false;
            panelassign.Visible = false;
            paneledittask.Visible = false;
            paneleditmember2.Visible = false;
            panelsigin_leader.Visible = false;
            panelfreelader.Visible = false;
            listView2.Visible = false;
            listView1.Visible = false;
            paneldelete.Visible = false;
            paneladdtask.Visible = false;
            /*Fill lists*/
            f.fill_tasklist(tasks);
            f.fill_member(members);
            f.fill_leader(leaders);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  panelsign_in.Visible = false;
        }

        //member button
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            panelsign_in.Visible = true;
            panelsigin_leader.Visible = false;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }


        private void Leaderbtn_Click(object sender, EventArgs e)
        {
            panelsign_in.Visible = false;
            panelsigin_leader.Visible = true;
        }

        //close buttom
        //closing 
        private void button3_Click(object sender, EventArgs e){this.Close();}
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you want to Save?", "Closing", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;

                case DialogResult.Yes:
                    f.writemembers(members);
                    f.writleaders(leaders);
                    f.writetasks(tasks);
                    break;

                default:
                    break;
            }
             
        }

        //log in members
        private void loginbtn_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text.ToString();
            string s2 = textBox2.Text.ToString();
            Tmember m1 = new Tmember(s1, s2);
            if(f.findmember(m1,members)==true)
            {

                mem = m1;
                //
                textBox1.Text = "";
                textBox2.Text = "";

                panelmember_list.Visible = true;
                listView1.Visible = false;
                panelsign_in.Visible = false;
                labelmyown.Visible = false;
                labeltasks.Visible = false;
                panelfree.Visible = true;
            }
            else
            {

                MessageBox.Show("not exist");
                textBox1.Text = "";
                textBox2.Text = "";
                Returnbtn_Click(sender,e);
            }
            
        }
        //return from sign in member
        private void Returnbtn_Click(object sender, EventArgs e)
        {
            panelsign_in.Visible = false;   
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            panelsigin_leader.Visible = false;
        }
        //close 
        private void button9_Click(object sender, EventArgs e){this.Close();}

        private void button10_Click(object sender, EventArgs e){ this.Close(); }
        //close done 
        
            
        // حاجات مش مهمة 
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        //done مش مهم
        //sign in eader
        private void button_lognin_leader_Click(object sender, EventArgs e)
        {
            string s1 = leader_username.Text.ToString();
            string s2 = leader_pass.Text.ToString();
            Leader l = new Leader(s1, s2);
            if (f.findleader(l, leaders) == true)
            {
                leader = l;
                leader_username.Text = "";
                leader_pass.Text = "";
                panelsigin_leader.Visible = false;
                panelleaderlist.Visible = true;
                panelfreelader.Visible = true;
                label25.Visible = false;
                label26.Visible = false;
            }
            else
            {

                MessageBox.Show("not exist");
                leader_username.Text = "";
                leader_pass.Text = "";
                panelsigin_leader.Visible = false;
            }
        }

        private void paneledittask_Paint(object sender, PaintEventArgs e)
        {

        }

        //edit button on list
        private void button11_Click(object sender, EventArgs e)
        {
            panelleaderlist.Visible = true;
            panelfreelader.Visible = true;
            paneldelete.Visible = false;
            paneladdtask.Visible = false;
            panelassign.Visible = false;
            listView2.Visible = false;
            paneledittask.Visible = true;
            list_taskscombo.Items.Clear();
            textbox_edit.Text = "";
            comboBox_edit.Text = "";
            date_edit.Text = "";
            for (int i=0;i<tasks.Count();i++)
            {
                list_taskscombo.Items.Add(tasks[i].name);
            }
        }

        //choose button to display data to edit (leader)
        private void button_choose_Click(object sender, EventArgs e)
        {

            string str = list_taskscombo.SelectedItem.ToString();
            for (int i = 0; i < tasks.Count(); i++)
            {
                if(str==tasks[i].name)
                {
                    ch = i;
                    textbox_edit.Text = tasks[i].name;
                    date_edit.Text = tasks[i].deadline.ToString();
                    comboBox_edit.Text = tasks[i].statues;
                }
            }

        }
        //save edit 
        private void save_edit_Click(object sender, EventArgs e)
        {
            tasks[ch].name = textbox_edit.Text.ToString();
            tasks[ch].statues = comboBox_edit.SelectedItem.ToString();
            tasks[ch].deadline = Convert.ToDateTime(date_edit.Text.ToString());

            textbox_edit.Text = "";
            comboBox_edit.Text = "";
            date_edit.Text="";
        }

        //show add task panel
        private void button15_Click(object sender, EventArgs e)
        {

            panelleaderlist.Visible = true;
            panelfreelader.Visible = true;
            paneldelete.Visible = false;
            paneladdtask.Visible = true;
            paneledittask.Visible = false;
            panelassign.Visible = false;
            listView2.Visible = false;
            taskname.Text="";
            taskdeadline.Text = "";
            comboBox1.Text="";

        }

        //add new task 
        private void addtaskbutton_Click(object sender, EventArgs e)
        {
            bool ex = false;
            for(int i=0;i<tasks.Count();i++)
            {
                if(tasks[i].name== taskname.Text.ToString())
                {
                    MessageBox.Show("it's already exist!");
                    ex= true;
                    break;
                }
            }
            if(ex==false)
            {
                Task t = new Task(taskname.Text.ToString(), Convert.ToDateTime(taskdeadline.Text.ToString()), comboBox1.SelectedItem.ToString(), null);
                tasks.Add(t);
                taskname.Text = "";
                taskdeadline.Text = "";
                comboBox1.Text = "";
            }
        }

        //Leader Assign and unassign tasks (buttom first)
        private void button14_Click(object sender, EventArgs e)
        {
            panelleaderlist.Visible = true;
            panelfreelader.Visible = true;
            paneldelete.Visible = false;
            paneledittask.Visible = false;
            listView2.Visible = false;

            
            paneladdtask.Visible = false;
            memberslist.Items.Clear();
            tasks_assign.Items.Clear();
            panelassign.Visible = true;
            for(int i=0;i<members.Count();i++)
            {
                memberslist.Items.Add(members[i].get_username());
            }

            for (int i = 0; i < tasks.Count(); i++)
            {
                tasks_assign.Items.Add(tasks[i].name);
            }
            
        }

        //save asign and unassign
        private void saveassign_Click(object sender, EventArgs e)
        {
            string str1 = memberslist.SelectedItem.ToString();
            string str2 = tasks_assign.SelectedItem.ToString();
            string str3 = memberassign.SelectedItem.ToString();
            string str4 = leaderassign.SelectedItem.ToString();
            int count=0;
            
            if (str2 != null || str2 != "")
            {
                for (int i = 0; i < tasks.Count(); i++)
                {
                    if (tasks[i].name == str2)
                    {
                        count = i;
                        if (tasks[i].employees == null)
                            tasks[i].employees = new List<string>();
                        if (str3 == "Assign" && tasks[count].employees.Contains(str1)==false)
                            tasks[count].employees.Add(str1);
                        if (str4 == "Assign" && tasks[count].employees.Contains(str4) == false)
                            tasks[count].employees.Add(leader.get_username());
                        break;
                    }
                }
            }
            if (str3 == "Unassign")
                tasks[count].employees.Remove(str1);
            if (str4 == "Unassign")
                tasks[count].employees.Remove(leader.get_username());
            
            
            memberslist.Text="";
            tasks_assign.Text = "";
            memberassign.Text = "";
            leaderassign.Text = "";
            

        }

        //show panel edit for user
        private void button8_Click(object sender, EventArgs e)
        {
            panelfree.Visible = true;
            listView1.Visible = false;
            labelmyown.Visible = false;
            labeltasks.Visible = false;
            label41.Visible = true;

            comboBox22.Items.Clear();
            checkBox1.Checked = false;
            comboBox22.Text = "";
            paneleditmember2.Visible = true;
            mem.getmytasks(tasks);
            
            for (int i = 0; i < mem.A_Tasks.Count(); i++)
            {
                comboBox22.Items.Add(mem.A_Tasks[i].name);
            }
            
        }
        string done;

        //save tasks to done
        private void button2_Click(object sender, EventArgs e)
        {
           

        }
        private void button16_Click(object sender, EventArgs e)
        {
            string str = comboBox22.SelectedItem.ToString();
            done = checkBox1.Text.ToString();
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < tasks.Count(); i++)
                {
                    if (tasks[i].name == str)
                        tasks[i].statues = "Done";
                    mem.A_Tasks.Remove(tasks[i]);
                }
            }
            checkBox1.Checked = false;
            comboBox22.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //Browse for member 
        private void button6_Click(object sender, EventArgs e)
        {
            panelfree.Visible = true;
            paneleditmember2.Visible = false;
            labeltasks.Visible = true;
            listView1.Visible = true;
            labelmyown.Visible = false;
            label41.Visible = false;
            listView1.Items.Clear();
            for (int i = 0; i < tasks.Count(); i++)
            {
                if (tasks[i].employees == null)
                {
                    tasks[i].employees = new List<string>();
                }
                v = new ListViewItem(new []{ tasks[i].name, tasks[i].deadline.ToString(),
                    tasks[i].statues, tasks[i].employees.Count().ToString()});
                listView1.Items.Add(v);
            }
        }
        //filter to member
        private void button7_Click(object sender, EventArgs e)
        {
            label41.Visible = false;
            listView1.Items.Clear();
            panelfree.Visible = true;
            panelmember_list.Visible = true;
            listView1.Visible = true;
            labelmyown.Visible = true;
            labeltasks.Visible = false;
            paneleditmember2.Visible = false;
            mem.getmytasks(tasks);
            for (int i = 0; i < mem.A_Tasks.Count(); i++)
            {
                if (mem.A_Tasks[i].statues == "Done")
                    continue;
                v = new ListViewItem(new[] { mem.A_Tasks[i].name, mem.A_Tasks[i].deadline.ToString(),
                    mem.A_Tasks[i].statues, mem.A_Tasks[i].employees.Count().ToString() });
                listView1.Items.Add(v);
            }
        }
        //Browse leader
        private void button13_Click(object sender, EventArgs e)
        {
            panelfreelader.Visible = true;
            panelleaderlist.Visible = true;
            paneldelete.Visible = false;
            panelassign.Visible = false;
            paneledittask.Visible = false;
            paneladdtask.Visible = false;
            listView2.Visible = true;
            label25.Visible = false;
            label26.Visible = true;
            listView2.Items.Clear();
            
            
            for (int i = 0; i < tasks.Count(); i++)
            {
                if(tasks[i].employees==null)
                {
                    tasks[i].employees = new List<string>();
                }
                v = new ListViewItem(new[]{ tasks[i].name, tasks[i].deadline.ToString(),
                tasks[i].statues, tasks[i].employees.Count().ToString()});
                listView2.Items.Add(v);
            }
            
        }
        //filter leader
        private void button12_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            panelfreelader.Visible = true;
            panelleaderlist.Visible = true;
            panelassign.Visible = false;
            paneledittask.Visible = false;
            paneladdtask.Visible = false;
            listView2.Visible = true;
            label25.Visible = true;
            label26.Visible = false;
            paneldelete.Visible = false;
            leader.getmytasks(tasks);
            for (int i = 0; i < leader.A_Tasks.Count(); i++)
            {

                v = new ListViewItem(new[] { leader.A_Tasks[i].name, leader.A_Tasks[i].deadline.ToString(),
                    leader.A_Tasks[i].statues, leader.A_Tasks[i].employees.Count().ToString() });
                listView2.Items.Add(v);
            }
        }

        private void labeltasks_Click(object sender, EventArgs e)
        {

        }
        //panel delete 
        private void button_deletelist_Click(object sender, EventArgs e)
        {
            
            panelleaderlist.Visible = true;
            panelfreelader.Visible=true;
            paneldelete.Visible = true;
            paneledittask.Visible = false;
            
            paneladdtask.Visible = false;
            panelassign.Visible = false;
            listView2.Visible = false;
            comboBox4.Items.Clear();
            for (int i = 0; i < tasks.Count(); i++)
            {
                comboBox4.Items.Add(tasks[i].name);
            }
        }
        //delete from tasks list
        private void buttondelete_Click(object sender, EventArgs e)
        {
            string str = comboBox4.SelectedItem.ToString();
            done = checkbox.Text.ToString();
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < tasks.Count(); i++)
                {
                    if (tasks[i].name == str)
                    {
                        tasks.Remove(tasks[i]);
                        break;
                    }
                }
            }
            comboBox4.Text = "";
            checkBox2.Checked = false;

        }

        private void panelassign_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelfree_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
