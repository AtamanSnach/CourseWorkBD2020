using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BDCourseWork
{
    public partial class Form1 : Form
    {
        int IndexTableNow;
        Label[] labels = new Label[5];
        ComboBox[] comboxes = new ComboBox[4];
        Query A = new Query();
        bool Transact = false;
        List<int> IDsCandit = new List<int>();
        List<int> IDsComp = new List<int>();
        List<int> IDsVacan = new List<int>();
        List<int> IDsCanditFirstTab = new List<int>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            comboBox6.KeyPress += (s, e) => e.Handled = true;
            comboBox7.KeyPress += (s, e) => e.Handled = true;
            comboBox14.KeyPress += (s, e) => e.Handled = true;
            comboBox1.KeyPress += (s, e) => e.Handled = true;
            comboBox6.KeyPress += (s, e) => e.Handled = true;
            comboBox9.KeyPress += (s, e) => e.Handled = true;
            comboBox11.KeyPress += (s, e) => e.Handled = true;
            comboBoxTables3.KeyPress += (s, e) => e.Handled = true;



            textBox4.KeyDown += (s, e) => { if (!(Char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Back)) e.Handled = true; };
            textBox9.KeyDown += (s, e) => { if (!(Char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Back)) e.Handled = true; };
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "База роботоит";
        }
        #region ВКЛАДКА 1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labels[0] = label7;
            labels[1] = label4;
            labels[2] = label5;
            labels[3] = label6;
            labels[4] = label3;
            comboxes[0] = comboBox2;
            comboxes[1] = comboBox3;
            comboxes[2] = comboBox4;
            comboxes[3] = comboBox5;
            button1.Enabled = true;
            button2.Enabled = true;

            for (int i = 0; i < comboxes.Length; i++)
            {
                comboxes[i].Text = "";

            }

            numericUpDown1.Value = 0;
            string qTs = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    qTs = "SELECT * FROM Candidate_info";
                    break;
                case 1:
                    qTs = "SELECT * FROM Vacancy_info";
                    break;
                case 2:
                    qTs = "SELECT * FROM Log_info";
                    break;
                case 3:
                    qTs = "SELECT * FROM experience_info";
                    break;
                default:
                    break;

            }
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = A.SomeSelect(qTs);
           

            //comboxes = { comboBox2, comboBox3, comboBox4, comboBox5 };
            IndexTableNow = comboBox1.SelectedIndex;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = true;
            }
            for (int i = 0; i < comboxes.Length; i++)
            {
                comboxes[i].Visible = true;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    for (int i = 3; i < labels.Length; i++)
                    {
                        labels[i].Visible = false;
                    }
                    for (int i = 3; i < comboxes.Length; i++)
                    {
                        comboxes[i].Visible = false;
                    }
                    labels[4].Visible = false;
                    numericUpDown1.Visible = false;
                    break;
                case 1:
                    for (int i = 0; i < labels.Length; i++)
                    {
                        labels[i].Visible = true;
                    }
                    for (int i = 0; i < comboxes.Length; i++)
                    {
                        comboxes[i].Visible = true;
                    }
                    numericUpDown1.Visible = true;
                    break;
                case 2:
                   
                    for (int i = 1; i < labels.Length; i++)
                    {
                        labels[i].Visible = false;
                    }
                    for (int i = 1; i < comboxes.Length; i++)
                    {
                        comboxes[i].Visible = false;
                    }
                    labels[4].Visible = false;
                    numericUpDown1.Visible = false;
                    break;
                case 3:

                    for (int i = 2; i < labels.Length; i++)
                    {
                        labels[i].Visible = false;
                    }
                    for (int i = 2; i < comboxes.Length; i++)
                    {
                        comboxes[i].Visible = false;
                    }
                    labels[4].Visible = true;
                    numericUpDown1.Visible = true;
                    break;
                default:
                    break;

            }
            
            for (int i = 0; i < comboxes.Length; i++)
            {
                comboxes[i].Items.Clear();
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        label7.Text = "По образованию";
                        label4.Text = "По желаемой должности";
                        label5.Text = "По состоянию";
                        DataTable buf1 = new DataTable();
                        buf1 = A.SomeSelect("SELECT Level_of_education_name FROM Education");
                        int RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox2.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        buf1 = A.SomeSelect("SELECT Position_name FROM Position");
                        RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox3.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        buf1 = A.SomeSelect("SELECT State_name FROM State");
                        RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox4.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        break;
                    }
                case 1:
                    {
                        label7.Text = "По состоянию";
                        label4.Text = "По типу вакансии";
                        label5.Text = "По должности";
                        label6.Text = "По компании";
                        label3.Text = "По зарплате";
                        DataTable buf1 = new DataTable();
                        buf1 = A.SomeSelect("SELECT State_name FROM State");
                        int RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox2.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        buf1 = A.SomeSelect("SELECT Vacancy_type_name FROM Vacancy_type");
                        RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox3.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        buf1 = A.SomeSelect("SELECT Position_name FROM Position");
                        RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox4.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        buf1 = A.SomeSelect("SELECT Company_name FROM Company");
                        RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox5.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }

                        break;
                    }
                case 2:
                    {
                        label7.Text = "По должности";
                        DataTable buf1 = new DataTable();
                        buf1 = A.SomeSelect("SELECT Position_name FROM Position");
                        int RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox2.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }
                        break;
                    }
                case 3:
                    {
                        label7.Text = "По кандидату";
                        label4.Text = "По должности";
                        label3.Text = "Месяцев больше чем";
                        DataTable buf1 = new DataTable();
                        buf1 = A.SomeSelect("SELECT Position_name FROM Position");
                        int RowsCont = buf1.Rows.Count;
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox3.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                        }                       
                        buf1 = A.SomeSelect("SELECT CONCAT(Name, \" \", Surname, \" \", Middle_name) AS Candidate__, ID_of_candidate FROM Candidate");
                        RowsCont = buf1.Rows.Count;
                        IDsCanditFirstTab = new List<int>();
                        for (int i = 0; i < RowsCont; i++)
                        {
                            comboBox2.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
                            IDsCanditFirstTab.Add((int)buf1.Rows[i].ItemArray[1]);
                        }
                        break;
                    }
                default:
                    break;

            }
        }

        private void ApplyButton(object sender, EventArgs e)
        {
            string ApplyQuery = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ApplyQuery = $"SELECT * FROM Candidate_info WHERE Level_of_education_name LIKE \"{comboBox2.Text}%\" AND Position_name LIKE \"{comboBox3.Text}%\" AND State_name LIKE \"{comboBox4.Text}%\";";
                    dataGridView1.DataSource = A.SomeSelect(ApplyQuery);
                    break;
                case 1:
                    ApplyQuery = "SELECT * FROM Vacancy_info  WHERE ";
                    string partV1 = "";
                    string partV2 = "";
                    string partV3 = "";
                    string partV4 = "";
                    string partV5 = "";                      
                    if (comboBox2.SelectedItem != null)
                    {
                        partV1 = "State_name Like \"" + comboBox2.SelectedItem.ToString() + "\" AND ";


                    }
                    if (comboBox3.SelectedItem != null)
                    {
                        partV2 = "Vacancy_type_name LIKE \"" + comboBox3.SelectedItem.ToString() + "\" AND ";


                    }
                    if (comboBox4.SelectedItem != null)
                    {
                        partV3 = "Position_name LIKE \"" + comboBox4.SelectedItem.ToString() + "\" AND ";


                    }
                    if (comboBox5.SelectedItem != null)
                    {
                        partV4 = "Company_name LIKE \"" + comboBox5.SelectedItem.ToString() + "\" AND ";


                    }
                    partV5 = "Salary > " + numericUpDown1.Value;

                    ApplyQuery += partV1 + partV2+ partV3 + partV4 + partV5 + ";";
                    dataGridView1.DataSource = A.SomeSelect(ApplyQuery);

                    break;
                case 2:
                    ApplyQuery = $"SELECT * FROM Log_info WHERE Position_name LIKE \"{comboBox2.Text}%\";";
                    dataGridView1.DataSource = A.SomeSelect(ApplyQuery);
                    break;
                case 3:
                    ApplyQuery = $"SELECT * FROM Experience_info WHERE Candidate__ LIKE \"%{comboBox2.Text}\" AND Position_name LIKE \"%{comboBox3.Text}\" AND Experience_in_month > {numericUpDown1.Value};";
                    dataGridView1.DataSource = A.SomeSelect(ApplyQuery);
                    break;
                default:
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            comboBox1_SelectedIndexChanged(sender,e);    
        }
        private void tabControl1_Enter(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        #endregion
        #region ВКЛАДКА 2
        private void buttonAddLog_Click(object sender, EventArgs e)
        {
            string query = $"CALL AddLogRecord({IDsCandit[comboBox6.SelectedIndex]}, {IDsVacan[comboBox7.SelectedIndex]});";
            A.AnotherQuery(query);
            comboBox6.Text = "";
            comboBox7.Text = "";
            button3.Enabled = false;
            tabPage2_Enter(sender, e);
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            foreach (var C in tabPage2.Controls)
            {
                if (C is ComboBox) (C as ComboBox).Items.Clear();
            }
            DataTable buf1; // кандидаты активные
            buf1 = A.SomeSelect("SELECT ID_of_candidate,Name,Surname,Middle_name FROM Candidate WHERE ID_of_state = 1 ORDER BY ID_of_candidate");
            comboBox6.Items.Clear();
            comboBox11.Items.Clear();
            int RowsCont = buf1.Rows.Count;
            IDsCandit = new List<int>();
            for (int i = 0; i < RowsCont; i++)
            {
                comboBox6.Items.Add(buf1.Rows[i].ItemArray[1].ToString() + " " + buf1.Rows[i].ItemArray[2].ToString() + " " + buf1.Rows[i].ItemArray[3].ToString());
                IDsCandit.Add((int)buf1.Rows[i].ItemArray[0]);
                comboBox11.Items.Add(buf1.Rows[i].ItemArray[1].ToString() + " " + buf1.Rows[i].ItemArray[2].ToString() + " " + buf1.Rows[i].ItemArray[3].ToString());
            }
            // вакансии активные
            buf1 = A.SomeSelect("SELECT Vacancy.ID_of_vacancy, Company.Company_name, Vacancy_type.Vacancy_type_name, Position.Position_name FROM Vacancy INNER JOIN Company ON Vacancy.ID_of_company = Company.ID_of_company INNER JOIN Vacancy_type ON Vacancy.ID_of_vacancy_type = Vacancy_type.ID_of_vacancy_type INNER JOIN Position ON Vacancy.ID_of_position = Position.ID_of_position");
            RowsCont = buf1.Rows.Count;
            IDsVacan = new List<int>();
            comboBox7.Items.Clear();
            for (int i = 0; i < RowsCont; i++)
            {
                comboBox7.Items.Add(buf1.Rows[i].ItemArray[1].ToString() + ", " + buf1.Rows[i].ItemArray[2].ToString() + ": " + buf1.Rows[i].ItemArray[3].ToString());
                IDsVacan.Add((int)buf1.Rows[i].ItemArray[0]);
            }
            // компании
            buf1 = A.SomeSelect("Select ID_of_company, Company_name FROM Company ORDER BY ID_of_company");
            RowsCont = buf1.Rows.Count;
            IDsComp = new List<int>();
            comboBox9.Items.Clear();
            for (int i = 0; i < RowsCont; i++)
            {
                comboBox9.Items.Add(buf1.Rows[i].ItemArray[1].ToString());
                IDsComp.Add((int)buf1.Rows[i].ItemArray[0]);
            }
            // типы вакансий
            buf1 = A.SomeSelect("Select * FROM Vacancy_type ORDER BY ID_of_vacancy_type");
            RowsCont = buf1.Rows.Count;
            comboBox8.Items.Clear();
            for (int i = 0; i < RowsCont; i++)
            {
                comboBox8.Items.Add(buf1.Rows[i].ItemArray[1].ToString());
            }
            // должности
            buf1 = A.SomeSelect("Select * FROM Position ORDER BY ID_of_position");
            RowsCont = buf1.Rows.Count;
            comboBox10.Items.Clear();
            comboBox12.Items.Clear();
            comboBox13.Items.Clear();
            for (int i = 0; i < RowsCont; i++)
            {
                comboBox10.Items.Add(buf1.Rows[i].ItemArray[1].ToString());
                comboBox12.Items.Add(buf1.Rows[i].ItemArray[1].ToString());
                comboBox13.Items.Add(buf1.Rows[i].ItemArray[1].ToString());
            }
            // уровни образования
            buf1 = A.SomeSelect("Select * FROM education ORDER BY ID_level_of_education");
            RowsCont = buf1.Rows.Count;
            comboBox14.Items.Clear();
            for (int i = 0; i < RowsCont; i++)
            {
                comboBox14.Items.Add(buf1.Rows[i].ItemArray[1].ToString());
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && comboBox7.Text != "")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
            //DataTable buf1 = new DataTable();
            //buf1 = A.SomeSelect($"SELECT Name, Surname, Middle_name FROM Candidate WHERE ID_of_candidate ={comboBox6.Text};");
            //label21.Text = buf1.Rows[0].ItemArray[0] + " " + buf1.Rows[0].ItemArray[1] + " " + buf1.Rows[0].ItemArray[2];
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && comboBox7.Text != "")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
            //DataTable buf1 = new DataTable();
            //buf1 = A.SomeSelect($"SELECT Company.Company_name, Vacancy_type.Vacancy_type_name, Position.Position_name, Vacancy.ID_of_vacancy FROM Vacancy INNER JOIN Company ON Vacancy.ID_of_company = Company.ID_of_company INNER JOIN Vacancy_type ON Vacancy.ID_of_vacancy_type = Vacancy_type.ID_of_vacancy_type INNER JOIN Position ON Vacancy.ID_of_position = Position.ID_of_position INNER JOIN State ON Vacancy.ID_of_state = State.ID_of_state WHERE ID_of_vacancy = {comboBox7.Text};");
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable buf1 = new DataTable();
            //buf1 = A.SomeSelect($"SELECT Name, Surname, Middle_name FROM Candidate WHERE ID_of_candidate ={comboBox11.Text};");
            //label37.Text = buf1.Rows[0].ItemArray[0] + " " + buf1.Rows[0].ItemArray[1] + " " + buf1.Rows[0].ItemArray[2];
            if (comboBox11.Text != "" && comboBox12.Text != "" && textBox9.Text != "")
                button6.Enabled = true;
            else
                button6.Enabled = false;
        }

        private void buttonAddCompanyClick(object sender, EventArgs e)
        {
            A.AnotherQuery($"INSERT INTO Company(Company_name, Company_telephone, Company_address) VALUES(\"{textBox5.Text}\",\"{textBox7.Text}\",\"{textBox8.Text}\")");
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            button5.Enabled = false;
            tabPage2_Enter(sender, e);
        }

        private void CheckEnabledCompany(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable buf1 = new DataTable();
            //buf1 = A.SomeSelect($"SELECT Company_name FROM Company WHERE ID_of_company = {comboBox9.Text};");
            //textBox6.Text = buf1.Rows[0].ItemArray[0] + "";
            if (comboBox8.Text.Length > 0 && comboBox9.Text.Length > 0 && comboBox10.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
                buttonInVacancy.Enabled = true;
            else
                buttonInVacancy.Enabled = false;
        }
        private void CheckEnableVacancy(object sender, KeyEventArgs e)
        {
            if (comboBox8.Text.Length > 0 && comboBox9.Text.Length > 0 && comboBox10.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
                buttonInVacancy.Enabled = true;
            else
                buttonInVacancy.Enabled = false;
        }

        private void CheckEnableVacancy(object sender, EventArgs e)
        {
            if (comboBox8.Text.Length > 0 && comboBox9.Text.Length > 0 && comboBox10.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
                buttonInVacancy.Enabled = true;
            else
                buttonInVacancy.Enabled = false;
        }

        private void buttonInVacancy_Click(object sender, EventArgs e)
        {
            string query = $"CALL InsertVacancy(\"{textBox1.Text}\", \"{textBox2.Text}\", \"{textBox3.Text}\", \"{comboBox8.Text}\", \"{comboBox10.Text}\", \"{textBox4.Text}\", \"{IDsComp[comboBox9.SelectedIndex]}\");";
            A.AnotherQuery(query);
            tabPage2_Enter(sender, e);
            buttonInVacancy.Enabled = false;
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void CheckEnabledStaj(object o, KeyEventArgs e)
        {
            if (comboBox11.Text != "" && comboBox12.Text != "" && textBox9.Text != "")
                button6.Enabled = true;
            else
                button6.Enabled = false;
        }

        private void CheckEnabledStaj(object sender, EventArgs e)
        {
            if (comboBox11.Text != "" && comboBox12.Text != "" && textBox9.Text != "")
                button6.Enabled = true;
            else
                button6.Enabled = false;
        }

        private void AddExperience_Click(object sender, EventArgs e)
        {
            string query = $"CALL AddExperienceRecord({IDsCandit[comboBox11.SelectedIndex]}, \"{comboBox12.Text}\", {textBox9.Text});";
            A.AnotherQuery(query);
            tabPage2_Enter(sender, e);
            button6.Enabled = false;
            comboBox11.Text = "";
            comboBox12.Text = "";
            textBox9.Text = "";
        }

        private void CheackEnabledCandidate(object sender, KeyEventArgs e)
        {
            if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && comboBox13.Text != "" && comboBox14.Text != "")
                button7.Enabled = true;
            else
                button7.Enabled = false;
        }
        private void CheackEnabledCandidate(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && comboBox13.Text != "" && comboBox14.Text != "")
                button7.Enabled = true;
            else
                button7.Enabled = false;
        }

        private void AddCandidate_Click(object sender, EventArgs e)
        {
            string query = $"CALL InsertCandidate(\"{textBox10.Text}\", \"{textBox11.Text}\", \"{textBox12.Text}\", \"{textBox13.Text}\", \"{textBox14.Text}\", \"{comboBox13.Text}\", {comboBox14.SelectedIndex+1});";
            A.AnotherQuery(query);
            tabPage2_Enter(sender, e);
            button7.Enabled = false;
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            comboBox13.Text = "";
            comboBox14.Text = "";
        }

        private void CheckEnableLog(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && comboBox7.Text != "")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }
        #endregion
        #region ВКЛАДКА 3
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            if (!Transact)
            {
                button8.Enabled = true;
            }
            
            foreach(var C in tabPage3.Controls)
            {
                if (C is ComboBox) (C as ComboBox).Items.Clear();
            }
            DataTable buf1;
            int RowsCont;
            buf1 = A.SomeSelect("SHOW TABLES;");
            RowsCont = buf1.Rows.Count;
            for (int i = 0; i < RowsCont; i++)
            {
                comboBoxTables3.Items.Add(buf1.Rows[i].ItemArray[0].ToString());
            }
            comboBoxTables3.SelectedIndex = 0;
        }

        private void comboBoxTables3_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataGridView2.Columns.Clear();
            if ((comboBoxTables3.Text.EndsWith("position") || comboBoxTables3.Text.EndsWith("vacancy_type") || comboBoxTables3.Text.EndsWith("education") || comboBoxTables3.Text.EndsWith("state")) && Transact)
            {
                textBox15.Enabled = true;
                button4.Enabled = true;
                label39.Text = "";
            }
            else
            {
                textBox15.Enabled = false;
                button4.Enabled = false;
                label39.Text = "Добавление в эту таблицу возможно только во вкладке 2";
            }

            //////////////////////////////////////////////////
            ///

            string query = "";
            bool isNoInfo = true;
            switch (comboBoxTables3.Text)
            {
                case "candidate":
                    query = "SELECT Candidate.ID_of_candidate, Candidate.Name,Candidate.Surname,Candidate.Middle_name, Candidate.Candidates_address, Candidate.Candidates_telephone, Education.Level_of_education_name, Position.Position_name, State.State_name FROM Candidate INNER JOIN Education ON Candidate.ID_level_of_education = Education.ID_level_of_education INNER JOIN Position ON Candidate.ID_of_position = Position.Id_of_position INNER JOIN State ON Candidate.ID_of_state = State.ID_of_state ORDER BY ID_of_candidate; ";
                    break;
                case "vacancy":
                    query = "SELECT Vacancy.ID_of_vacancy, Vacancy.Requirements, Vacancy.Duties, Vacancy.Work_schedule, Vacancy.Salary, Company.Company_name,  Vacancy_type.Vacancy_type_name,Position.Position_name, State.State_Name, Vacancy.Posting_date FROM Vacancy INNER JOIN Company ON Vacancy.ID_of_company = Company.ID_of_company INNER JOIN Vacancy_type ON Vacancy.ID_of_vacancy_type = Vacancy_type.ID_of_vacancy_type INNER JOIN Position ON Vacancy.ID_of_position = Position.ID_of_position INNER JOIN State ON Vacancy.ID_of_state = State.ID_of_state;";
                    break;
                case "company":
                    query = "SELECT ID_of_company, Company_name, Company_telephone, Company_address FROM Company;";
                    break;
                case "education":
                    query = "SELECT ID_level_of_education,Level_of_education_name FROM Education";
                    break;
                case "experience":
                    query = "SELECT Experience.ID_of_experience_record, Position.Position_name, CONCAT(Candidate.Name,\" \", Candidate.Surname,\" \" ,Candidate.Middle_name) AS \"Candidate__\", Experience.Experience_in_month FROM Candidate INNER JOIN Experience ON Candidate.ID_of_candidate = Experience.ID_of_candidate INNER JOIN Position ON Experience.ID_of_position = Position.ID_of_position;";
                    break;
                case "log":
                    query = "SELECT Log.ID_of_record, CONCAT(Candidate.Name,\" \", Candidate.Surname,\" \" ,Candidate.Middle_name) AS \"Candidate__\", Position.Position_name, Vacancy.Posting_date, Log.Record_date FROM Candidate INNER JOIN Log ON Candidate.ID_of_candidate = Log.ID_of_candidate INNER JOIN Vacancy ON Log.ID_of_vacancy = Vacancy.ID_of_vacancy INNER JOIN Position ON Vacancy.ID_of_position = Position.ID_of_position; ";
                    break;
                case "position":
                    query = "SELECT ID_of_position, Position_name FROM Position";
                    break;
                case "state":
                    query = "SELECT ID_of_state, State_name FROM state";
                    break;
                case "vacancy_type":
                    query = "SELECT ID_of_vacancy_type, Vacancy_type_name FROM vacancy_type;";
                    break;
                default:
                    query = $"SELECT * FROM {comboBoxTables3.Text};";
                    isNoInfo = false;
                    break;
            }
            dataGridView2.DataSource = A.SomeSelect(query);
            if (isNoInfo)
            {
                dataGridView2.Columns[0].Visible = false;
            }

            if (comboBoxTables3.Text.EndsWith("info"))
            {
                comboBoxRed1.Enabled = false;
                buttonDel.Enabled = false;
                buttonRed.Enabled = false;
            }
            else
            {
                if (Transact)
                {
                    comboBoxRed1.Enabled = true;
                    buttonDel.Enabled = true;
                    buttonRed.Enabled = true;

                }
            }


        }
        
        private void buttonDel_Click(object sender, EventArgs e)
        {
            string query = "";
            if (comboBoxTables3.Text == "experience")
            {
                query = $"DELETE FROM experience WHERE ID_of_experience_record = {dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()};";
            }
            else if(comboBoxTables3.Text == "log")
            {
                query = $"DELETE FROM log WHERE ID_of_record = {dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()};";
            }
            else
            {
                query = $"DELETE FROM {comboBoxTables3.Text} WHERE {dataGridView2.Columns[0].Name} = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";                        
            }
            A.TransactQuery(query);   
            comboBoxTables3_SelectedIndexChanged(comboBoxTables3, e);
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            string query = "";


            switch (comboBoxTables3.Text)
            {
                case "candidate":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            query = $"UPDATE candidate SET ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{comboBoxRed1.Text}\") WHERE ID_of_Position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_candidate = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        case "Level_of_education_name":
                            query = $"UPDATE candidate SET ID_level_of_education = (SELECT ID_level_of_education FROM Education WHERE Level_of_education_name = \"{comboBoxRed1.Text}\") WHERE ID_level_of_education = (SELECT ID_level_of_education FROM Education WHERE Level_of_education_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_candidate = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        case "State_name":
                            query = $"UPDATE candidate SET ID_of_state = (SELECT ID_of_state FROM State WHERE State_name = \"{comboBoxRed1.Text}\") WHERE ID_of_state = (SELECT ID_of_state FROM State WHERE State_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_candidate = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        default:
                            query = $"UPDATE {comboBoxTables3.Text} SET {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{comboBoxRed1.Text}\" WHERE {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{dataGridView2.CurrentCell.Value.ToString()} AND ID_of_candidate = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};\";";
                            break;
                    }
                    break;
                case "vacancy":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            query = $"UPDATE vacancy SET ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{comboBoxRed1.Text}\") WHERE ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_vacancy = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        case "Company_name":
                            query = $"UPDATE vacancy SET ID_of_company = (SELECT ID_of_company FROM Company WHERE Company_name = \"{comboBoxRed1.Text}\") WHERE Company_name = (SELECT ID_of_company FROM Company WHERE Company_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_vacancy = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        case "State_name":
                            query = $"UPDATE vacancy SET ID_of_state = (SELECT ID_of_state FROM State WHERE State_name = \"{comboBoxRed1.Text}\") WHERE State_name = (SELECT ID_of_state FROM State WHERE ID_of_state = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_vacancy = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        case "Vacancy_type_name":
                            query = $"UPDATE vacancy SET ID_of_vacancy_type = (SELECT ID_of_vacancy_type FROM Vacancy_type WHERE Vacancy_type_name = \"{comboBoxRed1.Text}\") WHERE ID_of_vacancy_type = (SELECT ID_of_vacancy_type FROM Vacancy_type WHERE Vacancy_type_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_vacancy = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                        default:
                            query = $"UPDATE {comboBoxTables3.Text} SET {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{comboBoxRed1.Text}\" WHERE {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{dataGridView2.CurrentCell.Value.ToString()}\" AND ID_of_vacancy = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                            break;
                    }
                    break;
                case "experience":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            query = $"UPDATE experience SET ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{comboBoxRed1.Text}\") WHERE ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_experience_record = {dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()};";
                            break;
                        case "Candidate__":
                            string[] Candmas = comboBoxRed1.Text.Split(' ');
                            string[] Candmas2 = dataGridView2.CurrentCell.Value.ToString().Split();
                            string NameRed = Candmas[0];
                            string SurnameRed = Candmas[1];
                            string Middle_nameRed = Candmas[2];
                            query = $"UPDATE experience SET ID_of_candidate = (SELECT ID_of_candidate FROM CANDIDATE WHERE NAME = \"{NameRed}\" AND Surname = \"{SurnameRed}\" AND Middle_name = \"{Middle_nameRed}\") WHERE ID_of_candidate = (SELECT ID_of_candidate FROM CANDIDATE WHERE NAME = \"{Candmas2[0]}\" AND Surname = \"{Candmas2[1]}\" AND Middle_name = \"{Candmas2[2]}\")  AND ID_of_experience_record = {dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()};";
                            break;
                        default:
                            query = $"UPDATE {comboBoxTables3.Text} SET {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{comboBoxRed1.Text}\" WHERE {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{dataGridView2.CurrentCell.Value.ToString()}\" AND ID_of_experience_record = \"{dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()}\";";
                            break;
                    }
                    break;
                case "log":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            query = $"UPDATE position SET ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{comboBoxRed1.Text}\") WHERE ID_of_position = (SELECT ID_of_position FROM Position WHERE Position_name = \"{dataGridView2.CurrentCell.Value.ToString()}\") AND ID_of_record = {dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()};";
                            break;
                        case "Candidate__":
                            string[] Candmas = comboBoxRed1.Text.Split(' ');
                            string[] Candmas2 = dataGridView2.CurrentCell.Value.ToString().Split();
                            string NameRed = Candmas[0];
                            string SurnameRed = Candmas[1];
                            string Middle_nameRed = Candmas[2];
                            query = $"UPDATE log SET ID_of_candidate = (SELECT ID_of_candidate FROM CANDIDATE WHERE NAME = \"{NameRed}\" AND Surname = \"{SurnameRed}\" AND Middle_name = \"{Middle_nameRed}\") WHERE ID_of_candidate = (SELECT ID_of_candidate FROM CANDIDATE WHERE NAME = \"{Candmas2[0]}\" AND Surname = \"{Candmas2[1]}\" AND Middle_name = \"{Candmas2[2]}\")  AND ID_of_record = {dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()} ;";
                            break;
                        default:
                            query = $"UPDATE {comboBoxTables3.Text} SET {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{comboBoxRed1.Text}\" WHERE {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{dataGridView2.CurrentCell.Value.ToString()}\" AND ID_of__record = \"{dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()}\";";
                            break;
                    }
                    break;
                default:
                    query = $"UPDATE {comboBoxTables3.Text} SET {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{comboBoxRed1.Text}\" WHERE {dataGridView2.SelectedCells[0].OwningColumn.HeaderText} = \"{dataGridView2.CurrentCell.Value.ToString()}\" AND {dataGridView2.Columns[0].Name} = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value};";
                    break;
            }


           int some1 = A.TransactQuery(query);
            comboBoxTables3_SelectedIndexChanged(comboBoxTables3, e);
            comboBoxRed1.Text = "";
        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            A.TransactQuery("SET AUTOCOMMIT = 0; START TRANSACTION;");
            button8.Enabled = false;
            button9.Enabled = true;
            button10.Enabled = true;
            Transact = true;
            comboBoxTables3_SelectedIndexChanged(sender, e);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            A.TransactQuery("COMMIT;");
            button8.Enabled = true;
            button9.Enabled = false;
            button10.Enabled = false;
            Transact = false;
            tabPage3_Enter(sender,e);

            textBox15.Enabled = false;
            button4.Enabled = false;
            comboBoxRed1.Enabled = false;
            buttonDel.Enabled = false;
            buttonRed.Enabled = false;
            comboBoxTables3_SelectedIndexChanged(comboBoxTables3, e);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            A.TransactQuery("ROLLBACK;");
            button8.Enabled = true;
            button9.Enabled = false;
            button10.Enabled = false;
            Transact = false;
            tabPage3_Enter(sender, e);

            textBox15.Enabled = false;
            button4.Enabled = false;
            comboBoxRed1.Enabled = false;
            buttonDel.Enabled = false;
            buttonRed.Enabled = false;
            comboBoxTables3_SelectedIndexChanged(comboBoxTables3, e);
        }

        private void buttonAdd(object sender, EventArgs e)
        {
            string query = "";
            query = $"INSERT INTO {comboBoxTables3.Text} ({dataGridView2.Columns[1].HeaderText})\nVALUES(\"{textBox15.Text}\");";
            A.TransactQuery(query);
            textBox15.Text = "";
            comboBoxTables3_SelectedIndexChanged(sender, e);
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            if (Transact)
            {
                button10_Click(sender, e);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxRed1.Items.Clear();
            string ComboQuery = "";
            DataTable bufRed = new DataTable();
            int RowsRed;
            switch (comboBoxTables3.Text)
            {
                case "candidate":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT position_name FROM Position";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "Level_of_education_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT level_of_education_name FROM Education";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "State_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT state_name FROM State";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "vacancy":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT position_name FROM Position";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "Company_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT company_name FROM Company";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "State_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT state_name FROM State";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "Vacancy_type_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT vacancy_type_name FROM Vacancy_type";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "experience":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT position_name FROM Position";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "Candidate__":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT CONCAT(Name,\" \",Surname,\" \",Middle_name) AS Candidate__ FROM Candidate";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "log":
                    switch (dataGridView2.SelectedCells[0].OwningColumn.HeaderText)
                    {
                        case "Position_name":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT position_name FROM Position";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        case "Candidate__":
                            comboBoxRed1.Items.Clear();
                            ComboQuery = "SELECT CONCAT(Name,\" \",Surname,\" \",Middle_name) AS Candidate__ FROM Candidate";
                            bufRed = A.SomeSelect(ComboQuery);
                            RowsRed = bufRed.Rows.Count;
                            for (int i = 0; i < RowsRed; i++)
                            {
                                comboBoxRed1.Items.Add(bufRed.Rows[i].ItemArray[0].ToString());
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}